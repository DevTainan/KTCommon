using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SampleWinApp.Models;
using KTCommon.EventBus;

namespace SampleWinApp.Views
{
    public partial class KtMmfEventBusPage : UserControl
    {
        private KtMmfEventBus _eventBus;

        public KtMmfEventBusPage()
        {
            InitializeComponent();

            // 初始化物件
            SetStatus(false);

            _eventBus = new KtMmfEventBus();
            _eventBus.MessageReceived += OnMessageReceived;
            _eventBus.TransactionError += OnTransactionError;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _eventBus.SetConnectionInfo(rdoMmfTypeOfMaster.Checked);
            _eventBus.Connect();
            SetStatus(_eventBus.IsConnected);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _eventBus.Disconnect();
            SetStatus(_eventBus.IsConnected);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _eventBus.Send(txtChannelId.Text, txtMessageId.Text, txtContent.Text);
        }

        private void OnMessageReceived(object sender, KTCommon.Interfaces.EventBusMessageEventArgs e)
        {
            txtMsgReceived.CheckAndInvoke(() => 
            { 
                txtMsgReceived.Text = string.Join(Environment.NewLine, e.ChannelId, e.MessageId, e.Content); 
            });
        }

        private void OnTransactionError(object sender, KTCommon.Structures.ExceptionEventArgs e)
        {
            txtTransactionError.CheckAndInvoke(() => { txtTransactionError.Text = e.Ex.ToString(); });
        }

        private void SetStatus(bool isSuccess)
        {
            if (isSuccess)
            {

                lblSystemStatus.BackColor = AppConstant.SucessColor;
                lblSystemStatus.Text = AppConstant.Connected;
            }
            else
            {
                lblSystemStatus.BackColor = AppConstant.FailColor;
                lblSystemStatus.Text = AppConstant.Disconnected;
            }
        }
    }
}
