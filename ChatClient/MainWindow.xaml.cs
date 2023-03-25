using System.Windows;
using System.Windows.Input;
using ChatClient.ChatService;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ChatService.IChatServiceCallback
    {
        private ChatServiceClient _client;
        private bool _isConnected = false;
        private int _id;

        public MainWindow()
        {
            InitializeComponent();         
        }

        private void ConnectUser()
        {
            if (!_isConnected)
            {
                _client = new ChatServiceClient(new System.ServiceModel.InstanceContext(this));
                _id = _client.Connect(tbUserName.Text);
                tbUserName.IsEnabled = false;
                btnConnect.Content = "Disconnect";
                _isConnected = true;
            }
        }

        private void DisconnectUser()
        {
            if (_isConnected)
            {
                _client.Disconnect(_id);
                _client = null;
                tbUserName.IsEnabled = true;
                btnConnect.Content = "Connect";
                _isConnected = false;
            }
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (_isConnected)
            {
                DisconnectUser();
                return;
            }
            ConnectUser();
        }

        public void MessageCallback(string message)
        {
            lbChat.Items.Add(message);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }

        private void tbMessage_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (_client != null)
                {
                    _client.SendMessage(tbMessage.Text, _id);
                    tbMessage.Text = string.Empty;
                }                      
            }
        }
    }
}
