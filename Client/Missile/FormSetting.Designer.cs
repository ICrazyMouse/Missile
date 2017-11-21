namespace Missile
{
    partial class FormSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.btnToggleMissile = new System.Windows.Forms.Button();
            this.btnTextTest = new System.Windows.Forms.Button();
            this.btnImageTest = new System.Windows.Forms.Button();
            this.btnFullScreenTest = new System.Windows.Forms.Button();
            this.serverConnector1 = new Server.ServerConnector();
            this.SuspendLayout();
            // 
            // btnToggleMissile
            // 
            this.btnToggleMissile.Location = new System.Drawing.Point(12, 322);
            this.btnToggleMissile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnToggleMissile.Name = "btnToggleMissile";
            this.btnToggleMissile.Size = new System.Drawing.Size(87, 33);
            this.btnToggleMissile.TabIndex = 0;
            this.btnToggleMissile.Text = "打开弹幕";
            this.btnToggleMissile.UseVisualStyleBackColor = true;
            this.btnToggleMissile.Click += new System.EventHandler(this.btnToggleMissile_Click);
            // 
            // btnTextTest
            // 
            this.btnTextTest.Location = new System.Drawing.Point(383, 322);
            this.btnTextTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTextTest.Name = "btnTextTest";
            this.btnTextTest.Size = new System.Drawing.Size(87, 33);
            this.btnTextTest.TabIndex = 2;
            this.btnTextTest.Text = "测试文本";
            this.btnTextTest.UseVisualStyleBackColor = true;
            this.btnTextTest.Click += new System.EventHandler(this.btnTextTest_Click);
            // 
            // btnImageTest
            // 
            this.btnImageTest.Location = new System.Drawing.Point(476, 322);
            this.btnImageTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImageTest.Name = "btnImageTest";
            this.btnImageTest.Size = new System.Drawing.Size(87, 33);
            this.btnImageTest.TabIndex = 3;
            this.btnImageTest.Text = "测试图片";
            this.btnImageTest.UseVisualStyleBackColor = true;
            this.btnImageTest.Click += new System.EventHandler(this.btnImageTest_Click);
            // 
            // btnFullScreenTest
            // 
            this.btnFullScreenTest.Location = new System.Drawing.Point(569, 322);
            this.btnFullScreenTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFullScreenTest.Name = "btnFullScreenTest";
            this.btnFullScreenTest.Size = new System.Drawing.Size(87, 33);
            this.btnFullScreenTest.TabIndex = 4;
            this.btnFullScreenTest.Text = "测试霸屏";
            this.btnFullScreenTest.UseVisualStyleBackColor = true;
            this.btnFullScreenTest.Click += new System.EventHandler(this.btnFullScreenTest_Click);
            // 
            // serverConnector1
            // 
            this.serverConnector1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serverConnector1.Location = new System.Drawing.Point(12, 13);
            this.serverConnector1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serverConnector1.Name = "serverConnector1";
            this.serverConnector1.Size = new System.Drawing.Size(522, 104);
            this.serverConnector1.TabIndex = 5;
            this.serverConnector1.Message += new Server.ServerConnector.onMessage(this.serverConnector_Message);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 362);
            this.Controls.Add(this.serverConnector1);
            this.Controls.Add(this.btnFullScreenTest);
            this.Controls.Add(this.btnImageTest);
            this.Controls.Add(this.btnTextTest);
            this.Controls.Add(this.btnToggleMissile);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSetting";
            this.Text = "稳";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnToggleMissile;
        private System.Windows.Forms.Button btnTextTest;
        private System.Windows.Forms.Button btnImageTest;
        private System.Windows.Forms.Button btnFullScreenTest;
        private Server.ServerConnector serverConnector1;
    }
}