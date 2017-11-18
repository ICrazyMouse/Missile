namespace MissileText.Server
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
            this.labServerUrlText = new System.Windows.Forms.Label();
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gropSeverSetting = new System.Windows.Forms.GroupBox();
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
            this.txtServerUrl.Size = new System.Drawing.Size(137, 23);
            this.txtServerUrl.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(261, 19);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(81, 48);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "ws://";
            // 
            // labInfo
            // 
            this.labInfo.AutoSize = true;
            this.labInfo.ForeColor = System.Drawing.Color.Red;
            this.labInfo.Location = new System.Drawing.Point(82, 51);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(44, 17);
            this.labInfo.TabIndex = 5;
            this.labInfo.Text = "未连接";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "状态:";
            // 
            // gropSeverSetting
            // 
            this.gropSeverSetting.Controls.Add(this.btnConnect);
            this.gropSeverSetting.Controls.Add(this.label1);
            this.gropSeverSetting.Controls.Add(this.labServerUrlText);
            this.gropSeverSetting.Controls.Add(this.labInfo);
            this.gropSeverSetting.Controls.Add(this.txtServerUrl);
            this.gropSeverSetting.Controls.Add(this.label2);
            this.gropSeverSetting.Location = new System.Drawing.Point(3, 3);
            this.gropSeverSetting.Name = "gropSeverSetting";
            this.gropSeverSetting.Size = new System.Drawing.Size(350, 79);
            this.gropSeverSetting.TabIndex = 7;
            this.gropSeverSetting.TabStop = false;
            this.gropSeverSetting.Text = "服务器设置";
            // 
            // ServerConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gropSeverSetting);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ServerConnector";
            this.Size = new System.Drawing.Size(356, 84);
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
    }
}
