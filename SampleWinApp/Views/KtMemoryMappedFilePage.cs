using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KTCommon.EventBus;
using SampleWinApp.Models;

namespace SampleWinApp.Views
{
    public partial class KtMemoryMappedFilePage : UserControl
    {
        private KtMemoryMappedFile _eventBus;

        public KtMemoryMappedFilePage()
        {
            InitializeComponent();

            // 初始化物件
            SetStatus(false);

            _eventBus = new KtMemoryMappedFile();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _eventBus.Connect(txtMapName.Text);
            SetStatus(_eventBus.IsConnected);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _eventBus.Disconnect();
            SetStatus(_eventBus.IsConnected);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            _eventBus.Set(txtContent.Text);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            txtMsgReceived.Text = _eventBus.Get();
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
