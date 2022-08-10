using log4net;
using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;
using Sunny.UI;
using System.Text;

namespace MQTTBroker
{
    public partial class Main : UIForm
    {
        private static ILog _log = LogManager.GetLogger(typeof(Main));
        private bool _started = false;
        public bool Started
        {
            get { return _started; } set
            {
                _started = value;
                btn_start.Text = _started?"停止":"启动";
            }
        }
        private MqttServer? _mqttServer;
        public Main()
        {
            InitializeComponent();
            Started = false;
        }

        private async void btn_start_Click(object sender, EventArgs e)
        {
            if (Started)
            {
                _mqttServer?.StopAsync();
                return;
            }
            var mqttFactory = new MqttFactory();
            MqttServerOptions options = mqttFactory.CreateServerOptionsBuilder()
                .WithDefaultEndpointBoundIPAddress(System.Net.IPAddress.Parse("127.0.0.1"))
                .WithDefaultEndpointPort(txt_port.IntValue)//端口
                .WithConnectionBacklog(100)//最大连接数
                .WithDefaultEndpoint()
                .Build();
            _mqttServer = new MqttFactory().CreateMqttServer(options);
            _mqttServer.ClientConnectedAsync += MqttServer_ClientConnectedAsync;
            _mqttServer.ClientDisconnectedAsync += MqttServer_ClientDisconnectedAsync;
            _mqttServer.ApplicationMessageNotConsumedAsync += MqttServer_ApplicationMessageNotConsumedAsync;
            _mqttServer.ClientSubscribedTopicAsync += MqttServer_ClientSubscribedTopicAsync;
            _mqttServer.ClientUnsubscribedTopicAsync += MqttServer_ClientUnsubscribedTopicAsync;
            _mqttServer.StartedAsync += MqttServer_StartedAsync;
            _mqttServer.StoppedAsync += MqttServer_StoppedAsync;
            _mqttServer.InterceptingPublishAsync += MqttServer_InterceptingPublishAsync;
            _mqttServer.ValidatingConnectionAsync += MqttServer_ValidatingConnectionAsync;
            _log.Info("MQTT服务开始启动");
            await _mqttServer.StartAsync();
        }

        private Task MqttServer_ClientConnectedAsync(ClientConnectedEventArgs arg)
        {
            _log.Info($"ClientConnectedAsync：客户端ID=【 {arg.ClientId}】已连接, 用户名=【 {arg.UserName}】地址=【 {arg.Endpoint}】 ");
            return Task.CompletedTask;
        }

        /// <summary>
        /// 消息接收事件
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Task MqttServer_InterceptingPublishAsync(InterceptingPublishEventArgs arg)
        {
            _log.Info($"InterceptingPublishAsync：客户端ID=【 {arg.ClientId}】 Topic主题=【 {arg.ApplicationMessage.Topic}】 消息=【 {Encoding.UTF8.GetString(arg.ApplicationMessage.Payload)}】 qos等级=【 {arg.ApplicationMessage.QualityOfServiceLevel}】");
            return Task.CompletedTask;
        }

        /// <summary>
        /// 关闭后事件
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Task MqttServer_StoppedAsync(EventArgs arg)
        {
            Started = false;
            _log.Info($"StoppedAsync：MQTT服务已关闭……");
            return Task.CompletedTask;
        }

        /// <summary>
        /// 启动后事件
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Task MqttServer_StartedAsync(EventArgs arg)
        {
            Started = true;
            _log.Info($"StartedAsync：MQTT服务已启动……");
            return Task.CompletedTask;
        }

        /// <summary>
        /// 客户端取消订阅事件
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Task MqttServer_ClientUnsubscribedTopicAsync(ClientUnsubscribedTopicEventArgs arg)
        {
            _log.Info($"ClientUnsubscribedTopicAsync：客户端ID=【 {arg.ClientId}】已取消订阅的主题=【 {arg.TopicFilter}】 ");
            return Task.CompletedTask;
        }

        /// <summary>
        /// 客户端订阅主题事件
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Task MqttServer_ClientSubscribedTopicAsync(ClientSubscribedTopicEventArgs arg)
        {
            _log.Info($"ClientSubscribedTopicAsync：客户端ID=【 {arg.ClientId}】订阅的主题=【 {arg.TopicFilter}】 ");
            return Task.CompletedTask;
        }

        /// <summary>
        /// 客户端关闭事件
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Task MqttServer_ClientDisconnectedAsync(ClientDisconnectedEventArgs arg)
        {
            _log.Info($"ClientDisconnectedAsync：客户端ID=【 {arg.ClientId}】已断开, 地址=【 {arg.Endpoint}】 ");
            return Task.CompletedTask;
        }

        /// <summary>
        /// 消息接收事件
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private Task MqttServer_ApplicationMessageNotConsumedAsync(ApplicationMessageNotConsumedEventArgs arg)
        {
            _log.Info($"ApplicationMessageNotConsumedAsync：发送端ID=【 {arg.SenderId}】 Topic主题=【 {arg.ApplicationMessage.Topic}】 消息=【 {Encoding.UTF8.GetString(arg.ApplicationMessage.Payload)}】 qos等级=【 {arg.ApplicationMessage.QualityOfServiceLevel}】");
            return Task.CompletedTask;
        }

        /// <summary>
        /// 用户名密码验证
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private Task MqttServer_ValidatingConnectionAsync(ValidatingConnectionEventArgs e)
        {
            _log.Info($"ValidatingConnectionAsync：客户端ID=【 {e.ClientId}】");
            if (cb_verify.Checked)
            {
                if(!txt_username.Text.Equals(e.UserName) || !txt_password.Text.Equals(e.Password))
                {
                    _log.Info($"ValidatingConnectionAsync：客户端ID=【 {e.ClientId}】用户名或密码验证错误 ");
                    e.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                }
            }
            return Task.CompletedTask;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mqttServer?.Dispose();
        }
    }
}
