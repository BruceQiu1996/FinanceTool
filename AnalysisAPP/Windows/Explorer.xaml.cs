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
using System.Windows.Shapes;

namespace AnalysisAPP.Windows
{
    /// <summary>
    /// Interaction logic for Explorer.xaml
    /// </summary>
    public partial class Explorer : Window
    {
        private readonly string _url;

        public ChromiumWebBrowser chromeBrowser;
        public Explorer(string url,string title)
        {
            InitializeComponent();
            _url = url;
            this.title.Text = title;
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Canvas_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chromeBrowser = new ChromiumWebBrowser(_url);
            // Add it to the form and fill it to the form window.
            container.Children.Add(chromeBrowser);
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
