using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAPP.ViewModel
{
    public class ShareViewModel:ViewModelBase
    {
        public string Symbol { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        private double trade;
        public double Trade
        {
            get { return trade; }
            set
            {
                trade = value;
                RaisePropertyChanged(nameof(Trade));
            }
        }

        private double pricechange;
        public double Pricechange
        {
            get { return pricechange; }
            set
            {
                pricechange = value;
                RaisePropertyChanged(nameof(Pricechange));
            }
        }

        private double changepercent;
        public double Changepercent
        {
            get { return changepercent; }
            set
            {
                changepercent = value;
                RaisePropertyChanged(nameof(Changepercent));
            }
        }

        private double buy;
        public double Buy
        {
            get { return buy; }
            set
            {
                buy = value;
                RaisePropertyChanged(nameof(Buy));
            }
        }

        private double sell;
        public double Sell
        {
            get { return sell; }
            set
            {
                sell = value;
                RaisePropertyChanged(nameof(Sell));
            }
        }

        private double settlement;
        public double Settlement
        {
            get { return settlement; }
            set
            {
                settlement = value;
                RaisePropertyChanged(nameof(Settlement));
            }
        }

        private double open;
        public double Open
        {
            get { return open; }
            set
            {
                open = value;
                RaisePropertyChanged(nameof(Open));
            }
        }

        private double high;
        public double High
        {
            get { return high; }
            set
            {
                high = value;
                RaisePropertyChanged(nameof(High));
            }
        }

        private double low;
        public double Low
        {
            get { return low; }
            set
            {
                low = value;
                RaisePropertyChanged(nameof(Low));
            }
        }

        private int volume;
        public int Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                RaisePropertyChanged(nameof(Volume));
            }
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                RaisePropertyChanged(nameof(Amount));
            }
        }

        private string ticktime;
        public string Ticktime
        {
            get { return ticktime; }
            set
            {
                ticktime = value;
                RaisePropertyChanged(nameof(Ticktime));
            }
        }

        private double per;
        public double Per
        {
            get { return per; }
            set
            {
                per = value;
                RaisePropertyChanged(nameof(Per));
            }
        }

        private double pb;
        public double Pb
        {
            get { return pb; }
            set
            {
                pb = value;
                RaisePropertyChanged(nameof(Pb));
            }
        }

        private double mktcap;
        public double Mktcap
        {
            get { return mktcap; }
            set
            {
                mktcap = value;
                RaisePropertyChanged(nameof(Mktcap));
            }
        }

        private double nmc;
        public double Nmc
        {
            get { return nmc; }
            set
            {
                nmc = value;
                RaisePropertyChanged(nameof(Nmc));
            }
        }

        private double turnoverratio;
        public double Turnoverratio
        {
            get { return turnoverratio; }
            set
            {
                turnoverratio = value;
                RaisePropertyChanged(nameof(Turnoverratio));
            }
        }
    }
}
