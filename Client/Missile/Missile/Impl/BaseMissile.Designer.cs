﻿namespace Missile.Missile.Impl
{
    partial class BaseMissile
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
            this.components = new System.ComponentModel.Container();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 16;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // BaseMissile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.Name = "BaseMissile";
            this.Text = "BaseFormMissile";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerUpdate;
    }
}