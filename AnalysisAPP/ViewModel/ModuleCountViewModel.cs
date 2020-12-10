using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAPP.ViewModel
{
    public class ModuleCountViewModel:ViewModelBase
    {

        public void Update(double curCount,double curPrice,double rate,int count,int price) 
        {
            this.CurCount = curCount;
            this.CurPrice = curPrice;
            this.AdRate = rate;
            this.Turnover_Count = count;
            this.Turnover_Price = price;
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Url => "http://image.sinajs.cn/newchart/small/n" + Code+".gif";

        private double curCount;
        public double CurCount
        {
            get { return curCount; }
            set
            {
                curCount = value;
                RaisePropertyChanged(nameof(CurCount));
            }
        }

        private double curPrice;
        public double CurPrice
        {
            get { return curPrice; }
            set
            {
                curPrice = value;
                RaisePropertyChanged(nameof(CurPrice));
            }
        }

        private double adRate;
        public double AdRate
        {
            get { return adRate; }
            set
            {
                adRate = value;
                RaisePropertyChanged(nameof(AdRate));
            }
        }

        private int turnover_Count;
        public int Turnover_Count
        {
            get { return turnover_Count; }
            set
            {
                turnover_Count = value;
                RaisePropertyChanged(nameof(Turnover_Count));
            }
        }

        private int turnover_Price;
        public int Turnover_Price
        {
            get { return turnover_Price; }
            set
            {
                turnover_Price = value;
                RaisePropertyChanged(nameof(Turnover_Price));
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.curCount} {this.CurPrice} {this.AdRate}";
        }
    }
}
