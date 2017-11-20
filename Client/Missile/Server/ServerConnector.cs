using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebSocketSharp;

namespace MissileText.Server
{
    /// <summary>
    /// 服务器连接器
    /// </summary>
    public partial class ServerConnector : UserControl
    {
        //Socket连接对象
        private WebSocket wsc;
        //连接成功事件
        public delegate void onConnected();
        [Description("连接成功")]
        public event onConnected Open;
        //消息处理事件
        public delegate void onMessage(String message);
        [Description("消息处理")]
        public event onMessage Message;
        //连接关闭事件
        public delegate void onClose();
        [Description("连接关闭")]
        public event onClose Close;
        //连接错误
        public delegate void onError(String error);
        [Description("连接错误")]
        public event onError Error;
        public ServerConnector()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtServerUrl.Text.IsNullOrEmpty())
                {
                    this.txtServerUrl.Focus();
                    this.labServerUrlText.ForeColor = Color.Red;
                    return;
                }
                this.labServerUrlText.ForeColor = Color.Black;
                wsc = new WebSocket("ws://" + this.txtServerUrl.Text + "?roomId=" + txtRoomId.Text + "&type=consumer");
                wsc.OnMessage += Wsc_OnMessage;
                wsc.OnOpen += Wsc_OnOpen;
                wsc.OnError += Wsc_OnError;
                wsc.OnClose += Wsc_OnClose;
                wsc.Connect();
                this.btnConnect.Enabled = false;
                this.txtRoomId.Enabled = false;
                this.txtServerUrl.Enabled = false;
                this.btnStop.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("连接错误:" + err.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        /// <summary>
        /// 连接打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wsc_OnOpen(object sender, EventArgs e)
        {
            this.labInfo.ForeColor = Color.Green;
            this.labInfo.Text = "已连接";
            this.tmrReconnect.Stop();
            this.Open?.Invoke();
        }

        /// <summary>
        /// 收到信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wsc_OnMessage(object sender, MessageEventArgs e)
        {
            this.Message?.Invoke(Encoding.UTF8.GetString(e.RawData));
        }
        /// <summary>
        /// 出现错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wsc_OnError(object sender, ErrorEventArgs e)
        {
            this.Error?.Invoke(e.Message);
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wsc_OnClose(object sender, CloseEventArgs e)
        {
            Action changeState = () => {
                this.tmrReconnect.Start();
            };
            this.BeginInvoke(changeState);
            this.Close?.Invoke();
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(String message)
        {
            this.wsc?.Send(message);
        }
        /// <summary>
        /// 重连Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrReconnect_Tick(object sender, EventArgs e)
        {
            this.labInfo.ForeColor = Color.Red;
            this.labInfo.Text = "连接断开,正在重连";
            wsc.Connect();
        }
        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if(this.wsc.ReadyState != WebSocketState.Closed)
            {
                this.wsc.Close();
            }
            this.tmrReconnect.Stop();
            this.btnConnect.Enabled = true;
            this.txtRoomId.Enabled = true;
            this.txtServerUrl.Enabled = true;
            this.btnStop.Enabled = false;
            this.labInfo.ForeColor = Color.Red;
            this.labInfo.Text = "未连接";
        }
    }
}
