using BifrostRemoteDesktop.Common.Enums;
using BifrostRemoteDesktop.Common.Models.Commands;
using BifrostRemoteDesktop.Common.Network;
using BifrostRemoteDesktop.Common.SystemControllers;
using BifrostRemoteDesktop.WPF.Backend.Models.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BifrostRemoteDesktop.Pages
{
    public sealed partial class TransmitterClientPage : Page, INotifyPropertyChanged
    {

        private double _mouseX;
        private double _mouseY;
        private bool _mouseRightButtonPressed = false;
        private bool _mouseLeftButtonPressed = false;
        private bool _mouseMiddleButtonPressed;

        private string _selectedEndpoint;

        private CommandTransmitter _commandTransmitter;
        CommandReceiver _commandReceiver;
        private string _connectionStatus;

        public string SelectedEndpoint
        {
            get => _selectedEndpoint;
            set
            {
                _selectedEndpoint = value;
                NotifyPropertyChanged(nameof(SelectedEndpoint));
            }
        }

        public bool MouseRightButtonPressed
        {
            get => _mouseRightButtonPressed;
            set
            {
                _mouseRightButtonPressed = value;
                NotifyPropertyChanged(nameof(MouseRightButtonPressed));
            }
        }
        public bool MouseLeftButtonPressed
        {
            get => _mouseLeftButtonPressed;
            set
            {
                _mouseLeftButtonPressed = value;
                NotifyPropertyChanged(nameof(MouseLeftButtonPressed));
            }
        }

        public bool MouseMiddleButtonPressed
        {
            get => _mouseMiddleButtonPressed;
            set
            {
                _mouseMiddleButtonPressed = value;
                NotifyPropertyChanged(nameof(MouseMiddleButtonPressed));
            }
        }

        public double MouseX
        {
            get => _mouseX;
            set
            {
                _mouseX = value;
                NotifyPropertyChanged(nameof(MouseX));
            }
        }
        public double MouseY
        {
            get => _mouseY;
            set
            {
                _mouseY = value;
                NotifyPropertyChanged(nameof(MouseY));
            }
        }

        public ObservableCollection<string> AvailableEndpoints { get; set; }

        public string ConnectionStatus
        {
            get => _connectionStatus; set
            {
                _connectionStatus = value;
                NotifyPropertyChanged(nameof(ConnectionStatus));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TransmitterClientPage()
        {
            LoadAvailableEndpoints();
            InitializeComponent();

            _commandTransmitter = new CommandTransmitter();

            if (AvailableEndpoints.Count > 0)
            {
                SelectedEndpoint = AvailableEndpoints[0];
            }

            BindEvents();
            ConnectionStatus = "Not initialized.";

            //DEBUG
            if (_commandReceiver == null)
            {
                _commandReceiver = new CommandReceiver(new WindowsSystemController());
                _commandReceiver.Start();
            }

        }

        private void BindEvents()
        {
            _commandTransmitter.NoReceiverFound += (s, e) =>
            {
                ConnectionStatus = "No receiver found!";
            };

            _commandTransmitter.ConnectionEstablished += (s, e) =>
            {
                ConnectionStatus = "Connection Established!";
            };
        }

        private void _commandTransmitter_NoReceiverFound(object sender, EventArgs e)
        {
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadAvailableEndpoints()
        {
            // TODO: Load endpoints from database.
            AvailableEndpoints = new ObservableCollection<string>()
            {
                "127.0.0.1"
            };
        }

        private void UpdateViewPointerDetails(Point point)
        {
            ///MouseRightButtonPressed = point.Properties.IsRightButtonPressed;
            //MouseLeftButtonPressed = point.Properties.IsLeftButtonPressed;
            //MouseMiddleButtonPressed = point.Properties.IsMiddleButtonPressed;
        }

        private void SendMovePointerCommand(MovePointerCommandArgs args)
        {
            _commandTransmitter.SendCommand(CommandType.MovePointer, args);
        }

        private void SendUpdatePointerStateCommand(PointerUpdateStateCommandArgs args)
        {
            _commandTransmitter.SendCommand(CommandType.UpdatePointerState, args);
        }

        private void SendUpdatePointerStateCommand(Point point)
        {
            // TODO: UNCOMMENT AND FIX THIS!!!
            /*SendUpdatePointerStateCommand(new PointerUpdateStateCommandArgs()
            {
                IsLeftPointerButtonPressed = point.Properties.IsLeftButtonPressed,
                IsRightPointerButtonPressed = point.Properties.IsRightButtonPressed,
                IsMiddlePointerButtonPressed = point.Properties.IsMiddleButtonPressed
            });*/
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedEndpoint != null)
            {
                _commandTransmitter.Connect(SelectedEndpoint);
            }
        }

        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = e.GetPosition((IInputElement)sender);
            MouseX = pos.X;
            MouseY = pos.Y;

            _commandTransmitter.SendCommand(CommandType.MovePointerPercentage,
                new MovePointerPercentageCommandArgs()
                {
                    PercentageX = MouseX / MainCanvas.Width,
                    PercentageY = MouseY / MainCanvas.Height
                });

            //SendMovePointerCommand(new MovePointerCommandArgs() { TargetX = MouseX, TargetY = MouseY });
        }

        private void MainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {

            //PointerPoint point = e.GetCurrentPoint((UIElement)sender);
            //UpdateViewPointerDetails(point);
            //SendUpdatePointerStateCommand(point);
        }

        private void MainCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {

            var pos = e.GetPosition((IInputElement)sender);
            //UpdateViewPointerDetails(point);
            //SendUpdatePointerStateCommand(point);
        }

        private void MainCanvas_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }

}