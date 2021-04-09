namespace SampleWinApp.Views
{
    partial class KtMemoryMappedFilePage
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
            this.btnGet = new System.Windows.Forms.Button();
            this.txtMsgReceived = new System.Windows.Forms.TextBox();
            this.lblMsgReceived = new System.Windows.Forms.Label();
            this.grpMessageSending = new System.Windows.Forms.GroupBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.grpConnect = new System.Windows.Forms.GroupBox();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblMapName = new System.Windows.Forms.Label();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.grpMessageReceived.SuspendLayout();
            this.grpMessageSending.SuspendLayout();
            this.grpConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMessageReceived
            // 
            this.grpMessageReceived.Controls.Add(this.btnGet);
            this.grpMessageReceived.Controls.Add(this.txtMsgReceived);
            this.grpMessageReceived.Controls.Add(this.lblMsgReceived);
            this.grpMessageReceived.Location = new System.Drawing.Point(3, 311);
            this.grpMessageReceived.Name = "grpMessageReceived";
            this.grpMessageReceived.Size = new System.Drawing.Size(385, 185);
            this.grpMessageReceived.TabIndex = 65;
            this.grpMessageReceived.TabStop = false;
            this.grpMessageReceived.Text = "Message Received";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(277, 156);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(107, 23);
            this.btnGet.TabIndex = 65;
            this.btnGet.Text = "&Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtMsgReceived
            // 
            this.txtMsgReceived.Location = new System.Drawing.Point(86, 21);
            this.txtMsgReceived.Multiline = true;
            this.txtMsgReceived.Name = "txtMsgReceived";
            this.txtMsgReceived.Size = new System.Drawing.Size(291, 129);
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
            this.grpMessageSending.Size = new System.Drawing.Size(385, 185);
            this.grpMessageSending.TabIndex = 66;
            this.grpMessageSending.TabStop = false;
            this.grpMessageSending.Text = "Message Sending";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(86, 21);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(291, 122);
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
            this.btnSet.Location = new System.Drawing.Point(278, 149);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(107, 23);
            this.btnSet.TabIndex = 62;
            this.btnSet.Text = "&Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // grpConnect
            // 
            this.grpConnect.Controls.Add(this.txtMapName);
            this.grpConnect.Controls.Add(this.lblSystemStatus);
            this.grpConnect.Controls.Add(this.lblMapName);
            this.grpConnect.Controls.Add(this.btnDisconnect);
            this.grpConnect.Controls.Add(this.btnConnect);
            this.grpConnect.Location = new System.Drawing.Point(3, 4);
            this.grpConnect.Name = "grpConnect";
            this.grpConnect.Size = new System.Drawing.Size(385, 110);
            this.grpConnect.TabIndex = 67;
            this.grpConnect.TabStop = false;
            this.grpConnect.Text = "Connect";
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
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Location = new System.Drawing.Point(26, 24);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(56, 12);
            this.lblMapName.TabIndex = 63;
            this.lblMapName.Text = "Map Name";
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(86, 21);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(200, 22);
            this.txtMapName.TabIndex = 64;
            this.txtMapName.Text = "KtMemoryMappedFile";
            // 
            // KtMemoryMappedFilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMessageReceived);
            this.Controls.Add(this.grpMessageSending);
            this.Controls.Add(this.grpConnect);
            this.Name = "KtMemoryMappedFilePage";
            this.Size = new System.Drawing.Size(390, 500);
            this.grpMessageReceived.ResumeLayout(false);
            this.grpMessageReceived.PerformLayout();
            this.grpMessageSending.ResumeLayout(false);
            this.grpMessageSending.PerformLayout();
            this.grpConnect.ResumeLayout(false);
            this.grpConnect.PerformLayout();
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
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.TextBox txtMapName;
    }
}
