using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnalysisAPP.UserControls.ViewModels
{
    public class MenuViewModel:ViewModelBase
    {
        public List<MenuItems> ItemList
        {
            get
            {
                return new List<MenuItems>
                {
                    //I will provide path data for icons in the description so you may copy and paste them because it is very long to type all of them
                    //so copy and paste like i am doing here below
                    new MenuItems(){ IsItemSelected=true,Name="Home",TabName="MianPage" },

                    new MenuItems(){Name="Mine" ,TabName="MinePage"},
                    //To add space i am adding blank item

                    new MenuItems() {Name="Config",TabName="ConfigPage"}
                };
            }
        }
    }

    public class MenuItems
    {
        public string Name { get; set; }

        public string TabName { get; set; }

        public string PathData
        {
            get
            {
                return Application.Current.FindResource("LogoData_" + Name)?.ToString();
            }

            private set { }
        }

        public int ListItemHeight { get; set; }

        public bool IsItemSelected { get; set; }

        public string ToolTip
        {
            get
            {
                return Application.Current.FindResource(Name)?.ToString();
            }

            private set { }
        }
    }
}
