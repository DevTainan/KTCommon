namespace Tutorials
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnWriteLog = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.cboLogLevel = new System.Windows.Forms.ComboBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblLogLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnWriteLog
            // 
            this.btnWriteLog.Location = new System.Drawing.Point(290, 111);
            this.btnWriteLog.Name = "btnWriteLog";
            this.btnWriteLog.Size = new System.Drawing.Size(75, 23);
            this.btnWriteLog.TabIndex = 0;
            this.btnWriteLog.Text = "Write Log";
            this.btnWriteLog.UseVisualStyleBackColor = true;
            this.btnWriteLog.Click += new System.EventHandler(this.btnWriteLog_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(133, 56);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(232, 22);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "some error!";
            // 
            // cboLogLevel
            // 
            this.cboLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLogLevel.FormattingEnabled = true;
            this.cboLogLevel.Location = new System.Drawing.Point(133, 85);
            this.cboLogLevel.Name = "cboLogLevel";
            this.cboLogLevel.Size = new System.Drawing.Size(232, 20);
            this.cboLogLevel.TabIndex = 2;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(71, 61);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(44, 12);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Message";
            // 
            // lblLogLevel
            // 
            this.lblLogLevel.AutoSize = true;
            this.lblLogLevel.Location = new System.Drawing.Point(65, 88);
            this.lblLogLevel.Name = "lblLogLevel";
            this.lblLogLevel.Size = new System.Drawing.Size(50, 12);
            this.lblLogLevel.TabIndex = 4;
            this.lblLogLevel.Text = "LogLevel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 262);
            this.Controls.Add(this.lblLogLevel);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cboLogLevel);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnWriteLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWriteLog;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ComboBox cboLogLevel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblLogLevel;
    }
}

