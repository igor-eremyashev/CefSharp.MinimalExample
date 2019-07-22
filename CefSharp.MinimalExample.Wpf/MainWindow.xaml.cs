using System.Windows;
using CefSharp.Wpf;

namespace CefSharp.MinimalExample.Wpf
{
    public partial class MainWindow : Window
    {
        private readonly ChromiumWebBrowser _browser = new ChromiumWebBrowser("http://google.com");

        public MainWindow()
        {
            InitializeComponent();

            Border.Child = _browser;
        }

        private void OnOpenWindowButtonClick(object sender, RoutedEventArgs e)
        {
            Border.Child = null;

            var floatingWindow = new FloatingWindow
            {
                Content = _browser
            };

            floatingWindow.Closed += (o, args) =>
            {
                floatingWindow.Content = null;
                Border.Child = _browser;
            };

            floatingWindow.Show();
        }
    }
}
