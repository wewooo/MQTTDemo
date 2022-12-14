using log4net;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using Sunny.UI;
using System.Text;

namespace MQTTPublisher
{
    public partial class Main : UIForm
    {
        private static ILog _log = LogManager.GetLogger(typeof(Main));
        private bool _connected = false;
        public bool Connected
        {
            get { return _connected; }
            set
            {
                _connected = value;
                btn_start.Text = _connected ? "断开" : "连接";
                btn_send.Enabled = _connected;
            }
        }
        public string Hints
        {
            get => txt_hint.Text; set
            {
                txt_hint.Text += $"{value}\r\n";
            }
        }
        private IMqttClient? _mqttClient;
        public Main()
        {
            InitializeComponent();
            Connected = false;
        }

        private async void btn_start_Click(object sender, EventArgs e)
        {
            if (Connected)
            {
                _mqttClient?.DisconnectAsync();
                return;
            }
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(txt_ip.Text, txt_port.IntValue)// 要访问的mqtt服务端的 ip 和 端口号
                .WithCredentials(txt_username.Text, txt_password.Text)// 要访问的mqtt服务端的用户名和密码
                .WithClientId(txt_id.Text)// 设置客户端id
                .WithCleanSession()
                .WithTls(new MqttClientOptionsBuilderTlsParameters
                {
                    UseTls = false// 是否使用 tls加密
                }).Build();
            _mqttClient = new MqttFactory().CreateMqttClient();
            _mqttClient.ConnectedAsync += _mqttClient_ConnectedAsync; // 客户端连接成功事件

            _mqttClient.DisconnectedAsync += _mqttClient_DisconnectedAsync; // 客户端连接关闭事件

            _mqttClient.ApplicationMessageReceivedAsync += _mqttClient_ApplicationMessageReceivedAsync; // 收到消息事件
            _log.Info("开始连接MQTT服务");
            await _mqttClient.ConnectAsync(options);
        }

        private Task _mqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            _log.Info($"ApplicationMessageReceivedAsync：客户端ID=【 {arg.ClientId}】接收到消息。Topic主题=【 {arg.ApplicationMessage.Topic}】 消息=【 {Encoding.UTF8.GetString(arg.ApplicationMessage.Payload)}】 qos等级=【 {arg.ApplicationMessage.QualityOfServiceLevel}】");
            return Task.CompletedTask;
        }

        private Task _mqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            _log.Info($"客户端已断开与服务端的连接……");
            Invoke(() =>
            {
                Connected = false;
            });
            return Task.CompletedTask;
        }

        private Task _mqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            _log.Info($"客户端已连接服务端……");
            Invoke(() =>
            {
                Connected = true;
            });
            return Task.CompletedTask;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connected)
                {
                    if(txt_topic.Text.IsNullOrEmpty() || txt_playload.Text.IsNullOrEmpty())
                    {
                        ShowWarningTip("主题和内容不能为空");
                        return;
                    }
                    var message = new MqttApplicationMessage
                    {
                        Topic = txt_topic.Text,
                        Payload = Encoding.Default.GetBytes(txt_playload.Text),
                        QualityOfServiceLevel = MqttQualityOfServiceLevel.ExactlyOnce,
                        Retain = true,// 服务端是否保留消息。true为保留，如果有新的订阅者连接，就会立马收到该消息。
                    };
                    var result = _mqttClient?.PublishAsync(message).Result;
                    if (result?.ReasonCode == MqttClientPublishReasonCode.Success)
                    {
                        Hints = $"主题:{txt_topic.Text},内容:{txt_playload.Text}";
                        return;
                    }
                    ShowErrorTip("推送失败");
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }
    }
}
