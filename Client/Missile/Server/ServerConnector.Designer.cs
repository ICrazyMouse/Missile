namespace Server
{
    partial class ServerConnector
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labServerUrlText = new System.Windows.Forms.Label();
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gropSeverSetting = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRoomId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tmrReconnect = new System.Windows.Forms.Timer(this.components);
            this.gropSeverSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // labServerUrlText
            // 
            this.labServerUrlText.AutoSize = true;
            this.labServerUrlText.Location = new System.Drawing.Point(5, 23);
            this.labServerUrlText.Name = "labServerUrlText";
            this.labServerUrlText.Size = new System.Drawing.Size(71, 17);
            this.labServerUrlText.TabIndex = 0;
            this.labServerUrlText.Text = "服务器地址:";
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Location = new System.Drawing.Point(118, 20);
            this.txtServerUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(229, 23);
            this.txtServerUrl.TabIndex = 1;
            this.txtServerUrl.Text = "localhost:8080/missile";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(353, 17);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(81, 75);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "启动";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "wss://";
            // 
            // labInfo
            // 
            this.labInfo.AutoSize = true;
            this.labInfo.ForeColor = System.Drawing.Color.Red;
            this.labInfo.Location = new System.Drawing.Point(82, 78);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(44, 17);
            this.labInfo.TabIndex = 5;
            this.labInfo.Text = "未连接";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "状态:";
            // 
            // gropSeverSetting
            // 
            this.gropSeverSetting.Controls.Add(this.btnStop);
            this.gropSeverSetting.Controls.Add(this.label4);
            this.gropSeverSetting.Controls.Add(this.txtRoomId);
            this.gropSeverSetting.Controls.Add(this.label3);
            this.gropSeverSetting.Controls.Add(this.btnConnect);
            this.gropSeverSetting.Controls.Add(this.label1);
            this.gropSeverSetting.Controls.Add(this.labServerUrlText);
            this.gropSeverSetting.Controls.Add(this.labInfo);
            this.gropSeverSetting.Controls.Add(this.txtServerUrl);
            this.gropSeverSetting.Controls.Add(this.label2);
            this.gropSeverSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gropSeverSetting.Location = new System.Drawing.Point(0, 0);
            this.gropSeverSetting.MaximumSize = new System.Drawing.Size(522, 104);
            this.gropSeverSetting.MinimumSize = new System.Drawing.Size(522, 104);
            this.gropSeverSetting.Name = "gropSeverSetting";
            this.gropSeverSetting.Size = new System.Drawing.Size(522, 104);
            this.gropSeverSetting.TabIndex = 7;
            this.gropSeverSetting.TabStop = false;
            this.gropSeverSetting.Text = "服务器设置";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Enabled = false;
            this.btnStop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStop.Location = new System.Drawing.Point(435, 17);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(81, 75);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "roomId=";
            // 
            // txtRoomId
            // 
            this.txtRoomId.Location = new System.Drawing.Point(143, 48);
            this.txtRoomId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoomId.Name = "txtRoomId";
            this.txtRoomId.Size = new System.Drawing.Size(204, 23);
            this.txtRoomId.TabIndex = 8;
            this.txtRoomId.Text = "001TEST";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "房间ID:";
            // 
            // tmrReconnect
            // 
            this.tmrReconnect.Interval = 5000;
            this.tmrReconnect.Tick += new System.EventHandler(this.tmrReconnect_Tick);
            // 
            // ServerConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gropSeverSetting);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ServerConnector";
            this.Size = new System.Drawing.Size(522, 104);
            this.gropSeverSetting.ResumeLayout(false);
            this.gropSeverSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labServerUrlText;
        private System.Windows.Forms.TextBox txtServerUrl;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gropSeverSetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRoomId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer tmrReconnect;
        private System.Windows.Forms.Button btnStop;
    }
}
