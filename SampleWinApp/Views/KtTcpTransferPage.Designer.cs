namespace SampleWinApp.Views
{
    partial class KtTcpTransferPage
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
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIpAddr = new System.Windows.Forms.TextBox();
            this.lblIpAddr = new System.Windows.Forms.Label();
            this.rdoClient = new System.Windows.Forms.RadioButton();
            this.rdoServer = new System.Windows.Forms.RadioButton();
            this.grpMessageSending = new System.Windows.Forms.GroupBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.grpMessageReceived = new System.Windows.Forms.GroupBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.txtTransactionError = new System.Windows.Forms.TextBox();
            this.lblTransactionError = new System.Windows.Forms.Label();
            this.txtMsgReceived = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblMsgReceived = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.lblSystemStatusForClient = new System.Windows.Forms.Label();
            this.lblSystemStatusDesc = new System.Windows.Forms.Label();
            this.lblSystemStatusDesc2 = new System.Windows.Forms.Label();
            this.grpConnect.SuspendLayout();
            this.grpMessageSending.SuspendLayout();
            this.grpMessageReceived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
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
            this.lblSystemStatus.Click += new System.EventHandler(this.lblSystemStatus_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(178, 81);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(107, 23);
            this.btnConnect.TabIndex = 62;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(294, 81);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(84, 23);
            this.btnDisconnect.TabIndex = 63;
            this.btnDisconnect.Text = "&Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // grpConnect
            // 
            this.grpConnect.Controls.Add(this.txtPort);
            this.grpConnect.Controls.Add(this.lblPort);
            this.grpConnect.Controls.Add(this.txtIpAddr);
            this.grpConnect.Controls.Add(this.lblSystemStatusDesc2);
            this.grpConnect.Controls.Add(this.lblSystemStatusDesc);
            this.grpConnect.Controls.Add(this.lblIpAddr);
            this.grpConnect.Controls.Add(this.rdoClient);
            this.grpConnect.Controls.Add(this.rdoServer);
            this.grpConnect.Controls.Add(this.lblSystemStatusForClient);
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
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(86, 80);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(86, 22);
            this.txtPort.TabIndex = 64;
            this.txtPort.Text = "9500";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(50, 83);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(24, 12);
            this.lblPort.TabIndex = 63;
            this.lblPort.Text = "Port";
            // 
            // txtIpAddr
            // 
            this.txtIpAddr.Location = new System.Drawing.Point(86, 52);
            this.txtIpAddr.Name = "txtIpAddr";
            this.txtIpAddr.Size = new System.Drawing.Size(86, 22);
            this.txtIpAddr.TabIndex = 64;
            this.txtIpAddr.Text = "127.0.0.1";
            // 
            // lblIpAddr
            // 
            this.lblIpAddr.AutoSize = true;
            this.lblIpAddr.Location = new System.Drawing.Point(56, 55);
            this.lblIpAddr.Name = "lblIpAddr";
            this.lblIpAddr.Size = new System.Drawing.Size(15, 12);
            this.lblIpAddr.TabIndex = 63;
            this.lblIpAddr.Text = "IP";
            // 
            // rdoClient
            // 
            this.rdoClient.AutoSize = true;
            this.rdoClient.Location = new System.Drawing.Point(115, 22);
            this.rdoClient.Name = "rdoClient";
            this.rdoClient.Size = new System.Drawing.Size(51, 16);
            this.rdoClient.TabIndex = 64;
            this.rdoClient.Text = "Client";
            this.rdoClient.UseVisualStyleBackColor = true;
            // 
            // rdoServer
            // 
            this.rdoServer.AutoSize = true;
            this.rdoServer.Checked = true;
            this.rdoServer.Location = new System.Drawing.Point(30, 22);
            this.rdoServer.Name = "rdoServer";
            this.rdoServer.Size = new System.Drawing.Size(53, 16);
            this.rdoServer.TabIndex = 64;
            this.rdoServer.TabStop = true;
            this.rdoServer.Text = "Server";
            this.rdoServer.UseVisualStyleBackColor = true;
            // 
            // grpMessageSending
            // 
            this.grpMessageSending.Controls.Add(this.txtFilePath);
            this.grpMessageSending.Controls.Add(this.lblFilePath);
            this.grpMessageSending.Controls.Add(this.btnSend);
            this.grpMessageSending.Location = new System.Drawing.Point(3, 119);
            this.grpMessageSending.Name = "grpMessageSending";
            this.grpMessageSending.Size = new System.Drawing.Size(385, 86);
            this.grpMessageSending.TabIndex = 64;
            this.grpMessageSending.TabStop = false;
            this.grpMessageSending.Text = "Message Sending";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(86, 21);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(291, 22);
            this.txtFilePath.TabIndex = 64;
            this.txtFilePath.Text = "C:\\Users\\kentseng\\Pictures\\S__40075311.jpg";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(26, 24);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(45, 12);
            this.lblFilePath.TabIndex = 63;
            this.lblFilePath.Text = "File Path";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(272, 49);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(107, 23);
            this.btnSend.TabIndex = 62;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // grpMessageReceived
            // 
            this.grpMessageReceived.Controls.Add(this.picImage);
            this.grpMessageReceived.Controls.Add(this.txtTransactionError);
            this.grpMessageReceived.Controls.Add(this.btnGet);
            this.grpMessageReceived.Controls.Add(this.lblTransactionError);
            this.grpMessageReceived.Controls.Add(this.txtMsgReceived);
            this.grpMessageReceived.Controls.Add(this.lblImage);
            this.grpMessageReceived.Controls.Add(this.lblMsgReceived);
            this.grpMessageReceived.Location = new System.Drawing.Point(3, 211);
            this.grpMessageReceived.Name = "grpMessageReceived";
            this.grpMessageReceived.Size = new System.Drawing.Size(385, 284);
            this.grpMessageReceived.TabIndex = 64;
            this.grpMessageReceived.TabStop = false;
            this.grpMessageReceived.Text = "Message Received";
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(86, 172);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(291, 106);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 65;
            this.picImage.TabStop = false;
            // 
            // txtTransactionError
            // 
            this.txtTransactionError.Location = new System.Drawing.Point(86, 93);
            this.txtTransactionError.Multiline = true;
            this.txtTransactionError.Name = "txtTransactionError";
            this.txtTransactionError.Size = new System.Drawing.Size(291, 66);
            this.txtTransactionError.TabIndex = 64;
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
            // txtMsgReceived
            // 
            this.txtMsgReceived.Location = new System.Drawing.Point(86, 21);
            this.txtMsgReceived.Multiline = true;
            this.txtMsgReceived.Name = "txtMsgReceived";
            this.txtMsgReceived.Size = new System.Drawing.Size(291, 66);
            this.txtMsgReceived.TabIndex = 64;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(23, 172);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(34, 12);
            this.lblImage.TabIndex = 63;
            this.lblImage.Text = "Image";
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
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(6, 187);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(68, 23);
            this.btnGet.TabIndex = 62;
            this.btnGet.Text = "&Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // lblSystemStatusForClient
            // 
            this.lblSystemStatusForClient.BackColor = System.Drawing.Color.Lime;
            this.lblSystemStatusForClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSystemStatusForClient.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemStatusForClient.Location = new System.Drawing.Point(292, 47);
            this.lblSystemStatusForClient.Name = "lblSystemStatusForClient";
            this.lblSystemStatusForClient.Size = new System.Drawing.Size(87, 29);
            this.lblSystemStatusForClient.TabIndex = 60;
            this.lblSystemStatusForClient.Text = "執行中";
            this.lblSystemStatusForClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSystemStatusForClient.Click += new System.EventHandler(this.lblSystemStatusForClient_Click);
            // 
            // lblSystemStatusDesc
            // 
            this.lblSystemStatusDesc.AutoSize = true;
            this.lblSystemStatusDesc.Location = new System.Drawing.Point(254, 24);
            this.lblSystemStatusDesc.Name = "lblSystemStatusDesc";
            this.lblSystemStatusDesc.Size = new System.Drawing.Size(31, 12);
            this.lblSystemStatusDesc.TabIndex = 63;
            this.lblSystemStatusDesc.Text = "Local";
            // 
            // lblSystemStatusDesc2
            // 
            this.lblSystemStatusDesc2.AutoSize = true;
            this.lblSystemStatusDesc2.Location = new System.Drawing.Point(244, 55);
            this.lblSystemStatusDesc2.Name = "lblSystemStatusDesc2";
            this.lblSystemStatusDesc2.Size = new System.Drawing.Size(41, 12);
            this.lblSystemStatusDesc2.TabIndex = 63;
            this.lblSystemStatusDesc2.Text = "Remote";
            // 
            // KtTcpTransferPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMessageReceived);
            this.Controls.Add(this.grpMessageSending);
            this.Controls.Add(this.grpConnect);
            this.Name = "KtTcpTransferPage";
            this.Size = new System.Drawing.Size(391, 499);
            this.grpConnect.ResumeLayout(false);
            this.grpConnect.PerformLayout();
            this.grpMessageSending.ResumeLayout(false);
            this.grpMessageSending.PerformLayout();
            this.grpMessageReceived.ResumeLayout(false);
            this.grpMessageReceived.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.GroupBox grpConnect;
        private System.Windows.Forms.RadioButton rdoClient;
        private System.Windows.Forms.RadioButton rdoServer;
        private System.Windows.Forms.GroupBox grpMessageSending;
        private System.Windows.Forms.GroupBox grpMessageReceived;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtTransactionError;
        private System.Windows.Forms.Label lblTransactionError;
        private System.Windows.Forms.TextBox txtMsgReceived;
        private System.Windows.Forms.Label lblMsgReceived;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.TextBox txtIpAddr;
        private System.Windows.Forms.Label lblIpAddr;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblSystemStatusDesc2;
        private System.Windows.Forms.Label lblSystemStatusDesc;
        private System.Windows.Forms.Label lblSystemStatusForClient;
    }
}
