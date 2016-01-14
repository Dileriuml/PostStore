using PostStore.ViewModels;
using MahApps.Metro.Controls;

namespace PostStore
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
        }
    }
}