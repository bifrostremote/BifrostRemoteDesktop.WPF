using BifrostRemoteDesktop.WPF.Pages;
using System.Windows;
using System.Windows.Controls;

namespace BifrostRemoteDesktop.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Page CurrentPage;

        public MainWindow()
        {
            InitializeComponent();
            InnerFrame.Navigate(new MainPage());
        }
    }
}
