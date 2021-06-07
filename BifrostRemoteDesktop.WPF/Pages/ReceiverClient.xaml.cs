

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using BifrostRemoteDesktop.Common.Network;
using BifrostRemoteDesktop.Common.SystemControllers;
using System.Windows;
using System.Windows.Controls;

namespace BifrostRemoteDesktop.WPF.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReceiverClientPage : Page
    {
        private CommandReceiver _commandReceiver;

        public ReceiverClientPage()
        {
            _commandReceiver = new CommandReceiver(new WindowsSystemController());
        }

        private void Start_Server_Click(object sender, RoutedEventArgs e)
        {
            _commandReceiver.Start();
        }

        private void Stop_Server_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
