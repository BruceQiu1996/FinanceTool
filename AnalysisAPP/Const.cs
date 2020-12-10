using AnalysisAPP.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAPP
{
    public class Const
    {
        //page
        private static MainPage mainPage;
        internal static MainPage MianPage => mainPage ?? (mainPage = new MainPage());

        private static ConfigPage configPage;
        internal static ConfigPage ConfigPage => configPage ?? (configPage = new ConfigPage());

        private static MinePage minePage;
        internal static MinePage MinePage => minePage ?? (minePage = new MinePage());
        //api
        private static readonly string baseUrl = "http://localhost:5000/api";

        public static readonly string HomeMainUrl = $"{baseUrl}/home/main/";
        public static readonly string LastUrl = $"{baseUrl}/home/lasts";
        public static readonly string TopUrl = $"{baseUrl}/home/tops";
        public static readonly string NewsUrl = $"{baseUrl}/home/news";
        //common code
        public static readonly string SH01ZS = "sh000001";
        public static readonly string SZ06ZS = "sz399006";//创业板
        public static readonly string SZ01ZS = "sz399001";//深证
    }
}
