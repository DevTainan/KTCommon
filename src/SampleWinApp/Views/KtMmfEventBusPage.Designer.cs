namespace SampleWinApp.Views
{
    partial class KtMmfEventBusPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.grpConnect = new System.Windows.Forms.GroupBox();
            this.grpMessageSending = new System.Windows.Forms.GroupBox();
            this.grpMessageReceived = new System.Windows.Forms.GroupBox();
            this.rdoMmfTypeOfMaster = new System.Windows.Forms.RadioButton();
            this.rdoMmfTypeOfSlave = new System.Windows.Forms.RadioButton();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblChannelId = new System.Windows.Forms.Label();
            this.txtChannelId = new System.Windows.Forms.TextBox();
            this.lblMessageId = new System.Windows.Forms.Label();
            this.txtMessageId = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblMsgReceived = new System.Windows.Forms.Label();
            this.txtMsgReceived = new System.Windows.Forms.TextBox();
            this.lblTransactionError = new System.Windows.Forms.Label();
            this.txtTransactionError = new System.Windows.Forms.TextBox();
            this.grpConnect.SuspendLayout();
            this.grpMessageSending.SuspendLayout();
            this.grpMessageReceived.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.BackColor = System.Drawing.Color.Lime;
            this.lblSystemStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSystemStatus.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemStatus.Location = new System.Drawing.Point(292, 16);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Size = new System.Drawing.Size(87, 29);
            this.lblSystemStatus.TabIndex = 60;
            this.lblSystemStatus.Text = "執行中";
            this.lblSystemStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(179, 70);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(107, 23);
            this.btnConnect.TabIndex = 62;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(295, 70);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(84, 23);
            this.btnDisconnect.TabIndex = 63;
            this.btnDisconnect.Text = "&Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // grpConnect
            // 
            this.grpConnect.Controls.Add(this.rdoMmfTypeOfSlave);
            this.grpConnect.Controls.Add(this.rdoMmfTypeOfMaster);
            this.grpConnect.Controls.Add(this.lblSystemStatus);
            this.grpConnect.Controls.Add(this.btnDisconnect);
            this.grpConnect.Controls.Add(this.btnConnect);
            this.grpConnect.Location = new System.Drawing.Point(3, 3);
            this.grpConnect.Name = "grpConnect";
            this.grpConnect.Size = new System.Drawing.Size(385, 110);
            this.grpConnect.TabIndex = 64;
            this.grpConnect.TabStop = false;
            this.grpConnect.Text = "Connect";
            // 
            // grpMessageSending
            // 
            this.grpMessageSending.Controls.Add(this.txtContent);
            this.grpMessageSending.Controls.Add(this.lblContent);
            this.grpMessageSending.Controls.Add(this.txtMessageId);
            this.grpMessageSending.Controls.Add(this.lblMessageId);
            this.grpMessageSending.Controls.Add(this.txtChannelId);
            this.grpMessageSending.Controls.Add(this.lblChannelId);
            this.grpMessageSending.Controls.Add(this.btnSend);
            this.grpMessageSending.Location = new System.Drawing.Point(3, 119);
            this.grpMessageSending.Name = "grpMessageSending";
            this.grpMessageSending.Size = new System.Drawing.Size(385, 185);
            this.grpMessageSending.TabIndex = 64;
            this.grpMessageSending.TabStop = false;
            this.grpMessageSending.Text = "Message Sending";
            // 
            // grpMessageReceived
            // 
            this.grpMessageReceived.Controls.Add(this.txtTransactionError);
            this.grpMessageReceived.Controls.Add(this.lblTransactionError);
            this.grpMessageReceived.Controls.Add(this.txtMsgReceived);
            this.grpMessageReceived.Controls.Add(this.lblMsgReceived);
            this.grpMessageReceived.Location = new System.Drawing.Point(3, 310);
            this.grpMessageReceived.Name = "grpMessageReceived";
            this.grpMessageReceived.Size = new System.Drawing.Size(385, 185);
            this.grpMessageReceived.TabIndex = 64;
            this.grpMessageReceived.TabStop = false;
            this.grpMessageReceived.Text = "Message Received";
            // 
            // rdoMmfTypeOfMaster
            // 
            this.rdoMmfTypeOfMaster.AutoSize = true;
            this.rdoMmfTypeOfMaster.Checked = true;
            this.rdoMmfTypeOfMaster.Location = new System.Drawing.Point(30, 22);
            this.rdoMmfTypeOfMaster.Name = "rdoMmfTypeOfMaster";
            this.rdoMmfTypeOfMaster.Size = new System.Drawing.Size(54, 16);
            this.rdoMmfTypeOfMaster.TabIndex = 64;
            this.rdoMmfTypeOfMaster.TabStop = true;
            this.rdoMmfTypeOfMaster.Text = "Master";
            this.rdoMmfTypeOfMaster.UseVisualStyleBackColor = true;
            // 
            // rdoMmfTypeOfSlave
            // 
            this.rdoMmfTypeOfSlave.AutoSize = true;
            this.rdoMmfTypeOfSlave.Location = new System.Drawing.Point(115, 22);
            this.rdoMmfTypeOfSlave.Name = "rdoMmfTypeOfSlave";
            this.rdoMmfTypeOfSlave.Size = new System.Drawing.Size(48, 16);
            this.rdoMmfTypeOfSlave.TabIndex = 64;
            this.rdoMmfTypeOfSlave.Text = "Slave";
            this.rdoMmfTypeOfSlave.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(278, 149);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(107, 23);
            this.btnSend.TabIndex = 62;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblChannelId
            // 
            this.lblChannelId.AutoSize = true;
            this.lblChannelId.Location = new System.Drawing.Point(26, 24);
            this.lblChannelId.Name = "lblChannelId";
            this.lblChannelId.Size = new System.Drawing.Size(54, 12);
            this.lblChannelId.TabIndex = 63;
            this.lblChannelId.Text = "ChannelId";
            // 
            // txtChannelId
            // 
            this.txtChannelId.Location = new System.Drawing.Point(86, 21);
            this.txtChannelId.Name = "txtChannelId";
            this.txtChannelId.Size = new System.Drawing.Size(200, 22);
            this.txtChannelId.TabIndex = 64;
            this.txtChannelId.Text = "Channel Test";
            // 
            // lblMessageId
            // 
            this.lblMessageId.AutoSize = true;
            this.lblMessageId.Location = new System.Drawing.Point(26, 52);
            this.lblMessageId.Name = "lblMessageId";
            this.lblMessageId.Size = new System.Drawing.Size(54, 12);
            this.lblMessageId.TabIndex = 63;
            this.lblMessageId.Text = "MessageId";
            // 
            // txtMessageId
            // 
            this.txtMessageId.Location = new System.Drawing.Point(86, 49);
            this.txtMessageId.Name = "txtMessageId";
            this.txtMessageId.Size = new System.Drawing.Size(200, 22);
            this.txtMessageId.TabIndex = 64;
            this.txtMessageId.Text = "Greeting";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(26, 80);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(42, 12);
            this.lblContent.TabIndex = 63;
            this.lblContent.Text = "Content";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(86, 77);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(291, 66);
            this.txtContent.TabIndex = 64;
            this.txtContent.Text = "Hello World~!";
            // 
            // lblMsgReceived
            // 
            this.lblMsgReceived.AutoSize = true;
            this.lblMsgReceived.Location = new System.Drawing.Point(26, 24);
            this.lblMsgReceived.Name = "lblMsgReceived";
            this.lblMsgReceived.Size = new System.Drawing.Size(48, 12);
            this.lblMsgReceived.TabIndex = 63;
            this.lblMsgReceived.Text = "Received";
            // 
            // txtMsgReceived
            // 
            this.txtMsgReceived.Location = new System.Drawing.Point(86, 21);
            this.txtMsgReceived.Multiline = true;
            this.txtMsgReceived.Name = "txtMsgReceived";
            this.txtMsgReceived.Size = new System.Drawing.Size(291, 66);
            this.txtMsgReceived.TabIndex = 64;
            // 
            // lblTransactionError
            // 
            this.lblTransactionError.AutoSize = true;
            this.lblTransactionError.Location = new System.Drawing.Point(26, 96);
            this.lblTransactionError.Name = "lblTransactionError";
            this.lblTransactionError.Size = new System.Drawing.Size(30, 12);
            this.lblTransactionError.TabIndex = 63;
            this.lblTransactionError.Text = "Error";
            // 
            // txtTransactionError
            // 
            this.txtTransactionError.Location = new System.Drawing.Point(86, 93);
            this.txtTransactionError.Multiline = true;
            this.txtTransactionError.Name = "txtTransactionError";
            this.txtTransactionError.Size = new System.Drawing.Size(291, 66);
            this.txtTransactionError.TabIndex = 64;
            // 
            // KtMmfEventBusPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMessageReceived);
            this.Controls.Add(this.grpMessageSending);
            this.Controls.Add(this.grpConnect);
            this.Name = "KtMmfEventBusPage";
            this.Size = new System.Drawing.Size(391, 499);
            this.grpConnect.ResumeLayout(false);
            this.grpConnect.PerformLayout();
            this.grpMessageSending.ResumeLayout(false);
            this.grpMessageSending.PerformLayout();
            this.grpMessageReceived.ResumeLayout(false);
            this.grpMessageReceived.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.GroupBox grpConnect;
        private System.Windows.Forms.RadioButton rdoMmfTypeOfSlave;
        private System.Windows.Forms.RadioButton rdoMmfTypeOfMaster;
        private System.Windows.Forms.GroupBox grpMessageSending;
        private System.Windows.Forms.GroupBox grpMessageReceived;
        private System.Windows.Forms.TextBox txtChannelId;
        private System.Windows.Forms.Label lblChannelId;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtMessageId;
        private System.Windows.Forms.Label lblMessageId;
        private System.Windows.Forms.TextBox txtTransactionError;
        private System.Windows.Forms.Label lblTransactionError;
        private System.Windows.Forms.TextBox txtMsgReceived;
        private System.Windows.Forms.Label lblMsgReceived;
    }
}
