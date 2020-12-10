using AnalysisAPP.UserControls.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalysisAPP.UserControls
{
    /// <summary>
    /// Interaction logic for MenuList.xaml
    /// </summary>
    public partial class MenuList : UserControl
    {
        public static readonly RoutedEvent SelectTabEvent =
            EventManager.RegisterRoutedEvent("SelectTabEvent", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventArgs<Object>), typeof(MenuList));
        public MenuList()
        {
            InitializeComponent();
            this.DataContext = new MenuViewModel();
        }
        public event RoutedEventHandler SelectTab
        {
            //将路由事件添加路由事件处理程序
            add { AddHandler(SelectTabEvent, value); }
            //从路由事件处理程序中移除路由事件
            remove { RemoveHandler(SelectTabEvent, value); }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems?.Count > 0 && e.AddedItems?.Count > 0 && e.AddedItems[0] != e.RemovedItems[0])
            {
                RoutedEventArgs args2 = new RoutedEventArgs(SelectTabEvent, tab);
                //引用自定义路由事件
                this.RaiseEvent(args2);
            }
        }
    }
}
