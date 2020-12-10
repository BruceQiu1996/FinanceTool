using AnalysisAPP.UserControls;
using AnalysisAPP.UserControls.ViewModels;
using CefSharp;
using CefSharp.Wpf;
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

namespace AnalysisAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.frame.Content = Const.MianPage;
        }
        /// <summary>
        /// 切换选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuList_SelectTab(object sender, RoutedEventArgs e)
        {
            var tabName = ((e.Source as MenuList)?.tab?.SelectedItem as MenuItems)?.TabName;

            switch (tabName)
            {
                case "MianPage":
                    this.frame.Content = Const.MianPage;
                    break;
                case "MinePage":
                    this.frame.Content = Const.MinePage;
                    break;
                case "ConfigPage":
                    this.frame.Content = Const.ConfigPage;
                    break;
                default:
                    this.frame.Content = Const.MianPage;
                    break;
            }
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Canvas_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Application.Current?.Shutdown();
            Environment.Exit(0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var setting = new CefSettings();
            // 设置语言
            setting.Locale = "zh-CN";
            //cef设置userAgent
            setting.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            //配置浏览器路径
            setting.BrowserSubprocessPath = System.IO.Path.GetFullPath(@"x86\CefSharp.BrowserSubprocess.exe");
            Cef.Initialize(setting, performDependencyCheck: true, browserProcessHandler: null);
        }
    }
}
