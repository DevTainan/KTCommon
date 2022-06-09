namespace SampleWinApp.Views
{
    partial class AsynchronousSocketPage
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
            this.grpMessageReceived = new System.Windows.Forms.GroupBox();
            this.txtMsgReceived = new System.Windows.Forms.TextBox();
            this.lblMsgReceived = new System.Windows.Forms.Label();
            this.grpMessageSending = new System.Windows.Forms.GroupBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.grpConnect = new System.Windows.Forms.GroupBox();
            this.rdoSocketOfClient = new System.Windows.Forms.RadioButton();
            this.rdoSocketOfServer = new System.Windows.Forms.RadioButton();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpTransactionError = new System.Windows.Forms.GroupBox();
            this.txtError = new System.Windows.Forms.TextBox();
            this.lblTransactionError = new System.Windows.Forms.Label();
            this.grpMessageReceived.SuspendLayout();
            this.grpMessageSending.SuspendLayout();
            this.grpConnect.SuspendLayout();
            this.grpTransactionError.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMessageReceived
            // 
            this.grpMessageReceived.Controls.Add(this.txtMsgReceived);
            this.grpMessageReceived.Controls.Add(this.lblMsgReceived);
            this.grpMessageReceived.Location = new System.Drawing.Point(5, 255);
            this.grpMessageReceived.Name = "grpMessageReceived";
            this.grpMessageReceived.Size = new System.Drawing.Size(385, 104);
            this.grpMessageReceived.TabIndex = 65;
            this.grpMessageReceived.TabStop = false;
            this.grpMessageReceived.Text = "Message Received";
            // 
            // txtMsgReceived
            // 
            this.txtMsgReceived.Location = new System.Drawing.Point(86, 21);
            this.txtMsgReceived.Multiline = true;
            this.txtMsgReceived.Name = "txtMsgReceived";
            this.txtMsgReceived.Size = new System.Drawing.Size(291, 72);
            this.txtMsgReceived.TabIndex = 64;
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
            // grpMessageSending
            // 
            this.grpMessageSending.Controls.Add(this.txtContent);
            this.grpMessageSending.Controls.Add(this.lblContent);
            this.grpMessageSending.Controls.Add(this.btnSet);
            this.grpMessageSending.Location = new System.Drawing.Point(3, 120);
            this.grpMessageSending.Name = "grpMessageSending";
            this.grpMessageSending.Size = new System.Drawing.Size(385, 129);
            this.grpMessageSending.TabIndex = 66;
            this.grpMessageSending.TabStop = false;
            this.grpMessageSending.Text = "Message Sending";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(86, 21);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(291, 72);
            this.txtContent.TabIndex = 64;
            this.txtContent.Text = "Hello World~!";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(26, 24);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(42, 12);
            this.lblContent.TabIndex = 63;
            this.lblContent.Text = "Content";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(270, 99);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(107, 23);
            this.btnSet.TabIndex = 62;
            this.btnSet.Text = "&Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // grpConnect
            // 
            this.grpConnect.Controls.Add(this.rdoSocketOfClient);
            this.grpConnect.Controls.Add(this.rdoSocketOfServer);
            this.grpConnect.Controls.Add(this.txtIPAddress);
            this.grpConnect.Controls.Add(this.lblSystemStatus);
            this.grpConnect.Controls.Add(this.lblIPAddress);
            this.grpConnect.Controls.Add(this.btnDisconnect);
            this.grpConnect.Controls.Add(this.btnInit);
            this.grpConnect.Controls.Add(this.btnConnect);
            this.grpConnect.Location = new System.Drawing.Point(3, 4);
            this.grpConnect.Name = "grpConnect";
            this.grpConnect.Size = new System.Drawing.Size(385, 110);
            this.grpConnect.TabIndex = 67;
            this.grpConnect.TabStop = false;
            this.grpConnect.Text = "Connect";
            // 
            // rdoSocketOfClient
            // 
            this.rdoSocketOfClient.AutoSize = true;
            this.rdoSocketOfClient.Location = new System.Drawing.Point(113, 22);
            this.rdoSocketOfClient.Name = "rdoSocketOfClient";
            this.rdoSocketOfClient.Size = new System.Drawing.Size(48, 16);
            this.rdoSocketOfClient.TabIndex = 65;
            this.rdoSocketOfClient.Text = "Slave";
            this.rdoSocketOfClient.UseVisualStyleBackColor = true;
            // 
            // rdoSocketOfServer
            // 
            this.rdoSocketOfServer.AutoSize = true;
            this.rdoSocketOfServer.Checked = true;
            this.rdoSocketOfServer.Location = new System.Drawing.Point(28, 22);
            this.rdoSocketOfServer.Name = "rdoSocketOfServer";
            this.rdoSocketOfServer.Size = new System.Drawing.Size(54, 16);
            this.rdoSocketOfServer.TabIndex = 66;
            this.rdoSocketOfServer.TabStop = true;
            this.rdoSocketOfServer.Text = "Master";
            this.rdoSocketOfServer.UseVisualStyleBackColor = true;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(86, 53);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(200, 22);
            this.txtIPAddress.TabIndex = 64;
            this.txtIPAddress.Text = "127.0.0.1";
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
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(53, 56);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(15, 12);
            this.lblIPAddress.TabIndex = 63;
            this.lblIPAddress.Text = "IP";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(295, 81);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(84, 23);
            this.btnDisconnect.TabIndex = 63;
            this.btnDisconnect.Text = "&Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(295, 53);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(82, 23);
            this.btnInit.TabIndex = 62;
            this.btnInit.Text = "&Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(179, 81);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(107, 23);
            this.btnConnect.TabIndex = 62;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpTransactionError
            // 
            this.grpTransactionError.Controls.Add(this.txtError);
            this.grpTransactionError.Controls.Add(this.lblTransactionError);
            this.grpTransactionError.Location = new System.Drawing.Point(5, 365);
            this.grpTransactionError.Name = "grpTransactionError";
            this.grpTransactionError.Size = new System.Drawing.Size(385, 104);
            this.grpTransactionError.TabIndex = 65;
            this.grpTransactionError.TabStop = false;
            this.grpTransactionError.Text = "Transaction Error";
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(86, 21);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(291, 72);
            this.txtError.TabIndex = 64;
            // 
            // lblTransactionError
            // 
            this.lblTransactionError.AutoSize = true;
            this.lblTransactionError.Location = new System.Drawing.Point(44, 24);
            this.lblTransactionError.Name = "lblTransactionError";
            this.lblTransactionError.Size = new System.Drawing.Size(30, 12);
            this.lblTransactionError.TabIndex = 63;
            this.lblTransactionError.Text = "Error";
            // 
            // AsynchronousSocketPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpTransactionError);
            this.Controls.Add(this.grpMessageReceived);
            this.Controls.Add(this.grpMessageSending);
            this.Controls.Add(this.grpConnect);
            this.Name = "AsynchronousSocketPage";
            this.Size = new System.Drawing.Size(390, 500);
            this.grpMessageReceived.ResumeLayout(false);
            this.grpMessageReceived.PerformLayout();
            this.grpMessageSending.ResumeLayout(false);
            this.grpMessageSending.PerformLayout();
            this.grpConnect.ResumeLayout(false);
            this.grpConnect.PerformLayout();
            this.grpTransactionError.ResumeLayout(false);
            this.grpTransactionError.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMessageReceived;
        private System.Windows.Forms.TextBox txtMsgReceived;
        private System.Windows.Forms.Label lblMsgReceived;
        private System.Windows.Forms.GroupBox grpMessageSending;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.GroupBox grpConnect;
        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.RadioButton rdoSocketOfClient;
        private System.Windows.Forms.RadioButton rdoSocketOfServer;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.GroupBox grpTransactionError;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label lblTransactionError;
    }
}
