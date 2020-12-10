using Anlaysis_Infrastructure.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAPP.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        private bool _isLoad = false;
        private int sharePage = 1;
        public RelayCommand LoadCommandAsync { get; set; }

        private ObservableCollection<ModuleCountViewModel> modules;
        public ObservableCollection<ModuleCountViewModel> Modules
        {
            get { return modules; }
            set
            {
                modules = value;
                RaisePropertyChanged(nameof(Modules));
            }
        }

        private ObservableCollection<ShareViewModel> shTops;
        public ObservableCollection<ShareViewModel> ShTops
        {
            get { return shTops; }
            set
            {
                shTops = value;
                RaisePropertyChanged(nameof(ShTops));
            }
        }

        private ObservableCollection<ShareViewModel> shLasts;
        public ObservableCollection<ShareViewModel> ShLasts
        {
            get { return shLasts; }
            set
            {
                shLasts = value;
                RaisePropertyChanged(nameof(ShLasts));
            }
        }

        private ObservableCollection<ShareViewModel> szTops;
        public ObservableCollection<ShareViewModel> SzTops
        {
            get { return szTops; }
            set
            {
                szTops = value;
                RaisePropertyChanged(nameof(SzTops));
            }
        }

        private ObservableCollection<ShareViewModel> szLasts;
        public ObservableCollection<ShareViewModel> SzLasts
        {
            get { return szLasts; }
            set
            {
                szLasts = value;
                RaisePropertyChanged(nameof(SzLasts));
            }
        }

        private ObservableCollection<NewsViewModel> news;
        public ObservableCollection<NewsViewModel> News
        {
            get { return news; }
            set
            {
                news = value;
                RaisePropertyChanged(nameof(News));
            }
        }

        private bool loading;
        public bool Loading
        {
            get { return loading; }
            set
            {
                loading = value;
                RaisePropertyChanged(nameof(Loading));
            }
        }
        public MainPageViewModel()
        {
            Modules = new ObservableCollection<ModuleCountViewModel>();
            News = new ObservableCollection<NewsViewModel>();
            LoadCommandAsync = new RelayCommand(Load);
        }


        private async void Load()
        {
            try
            {
                if (!_isLoad)
                {
                    Loading = true;
                    var Sh01 = new ModuleCountViewModel() { Name = "上证指数", Code = Const.SH01ZS };
                    var Sh02 = new ModuleCountViewModel() { Name = "深证成指", Code = Const.SZ01ZS };
                    var Sz01 = new ModuleCountViewModel() { Name = "创业板指", Code = Const.SZ06ZS };
                    Modules.Add(Sh01);
                    Modules.Add(Sh02);
                    Modules.Add(Sz01);

                    await HandleMainLogic();
                    await HandleNews();
                    ScopeToRun();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _isLoad = true;
                Loading = false;
            }
        }

        private void ScopeToRun()
        {
            _ = Task.Run(async () =>
              {
                  while (true)
                  {
                      await Task.Delay(10000);
                      await HandleMainLogic();
                  }
              });
        }

        private async Task HandleMainLogic()
        {
            var param = $"s_{Const.SH01ZS},s_{Const.SZ06ZS},s_{Const.SZ01ZS}";
            var resp = await HttpRequestHelper.GetAsync($"{Const.HomeMainUrl}?lsts={param}");
            if (resp.IsSuccessStatusCode)
            {
                //更新数据
                var result = await resp.Content.ReadAsStringAsync();
                foreach (var item in result.Split(';'))
                {
                    try
                    {
                        var local = item.IndexOf("=");
                        if (local < 0) continue;
                        var start = item.IndexOf("hq_str_") + 9;
                        var code = item.Substring(start, local - start);
                        var innerItems = item.Substring(local).Split(',');
                        var model = Modules.FirstOrDefault(o => o.Code == code);
                        if (model == null) continue;
                        model.Update(double.Parse(innerItems[1]),
                                     double.Parse(innerItems[2]),
                                     double.Parse(innerItems[3]),
                                     int.Parse(innerItems[4]),
                                     int.Parse(innerItems[5].Replace("\"", string.Empty)));
                    }
                    catch { continue; }
                }
            }

            this.ShTops = await GetLocalChange($"{Const.TopUrl}?page=1&local=sh_a");
            this.ShLasts = await GetLocalChange($"{Const.LastUrl}?page=1&local=sh_a");
            this.SzTops = await GetLocalChange($"{Const.TopUrl}?page=1&local=sz_a");
            this.SzLasts = await GetLocalChange($"{Const.LastUrl}?page=1&local=sz_a");
        }

        private async Task HandleNews(int page=1)
        {
            var resp = await HttpRequestHelper.GetAsync($"{Const.NewsUrl}?page={page}");
            if (resp.IsSuccessStatusCode)
            {
                var obj = JsonConvert.DeserializeObject<dynamic>(await resp.Content.ReadAsStringAsync());

                if (obj.result.status.code == 0) 
                {
                    var datas=obj.result.data.feed.list;
                    foreach (var data in datas) 
                    {
                        News.Add(new NewsViewModel
                        {
                            Id = data.id,
                            Create_time=data.create_time,
                            Author=data.author,
                            Docurl=data.docurl,
                            Rich_text=data.rich_text
                        }) ;   
                    }
                }

            }
        }

        private async Task<ObservableCollection<ShareViewModel>> GetLocalChange(string url)
        {
            try
            {
                var resp = await HttpRequestHelper.GetAsync(url);
                if (resp.IsSuccessStatusCode)
                {
                    var result = await resp.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ObservableCollection<ShareViewModel>>(result);
                }
            }
            catch { return null; }
            return null;
        }
    }
}
