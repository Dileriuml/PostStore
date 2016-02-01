using MahApps.Metro.Controls;
using PostStore.ViewModels;
using System.Windows;

namespace PostStore.Views
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }

        void OnExitClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowSettings(object sender, RoutedEventArgs e)
        {
            CargoFlyout.IsOpen = true;
        }
    }
}