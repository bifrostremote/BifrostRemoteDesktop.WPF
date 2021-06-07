using BifrostRemoteDesktop.Pages;
using System.Windows;
using System.Windows.Controls;

namespace BifrostRemoteDesktop.WPF.Pages
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Start_Transmitter_Client_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TransmitterClientPage());
        }
        public void Start_Receiver_Client_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReceiverClientPage());
        }
    }
}
