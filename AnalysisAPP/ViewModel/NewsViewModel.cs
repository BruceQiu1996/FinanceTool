using AnalysisAPP.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAPP.ViewModel
{
    public class NewsViewModel:ViewModelBase
    {
        public RelayCommand ClickNewCommand { get; set; }

        public NewsViewModel() 
        {
            ClickNewCommand = new RelayCommand(Jump);
        }
        public int Id { get; set; }

        public string Docurl { get; set; }

        public string Create_time { get; set; }

        public string Author { get; set; }

        public string Rich_text { get; set; }

        private void Jump() 
        {
            if (string.IsNullOrEmpty(Docurl)) return;
            Explorer explorer = new Explorer(Docurl, Rich_text.Length>50? Rich_text.Substring(0,50)+"...":Rich_text);
            explorer.Show();
        }
    }
}
