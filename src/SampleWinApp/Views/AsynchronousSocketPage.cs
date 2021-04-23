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
using KTCommon.Internet;
using KTCommon.Structures;
using KTCommon.Interfaces;

namespace SampleWinApp.Views
{
    public partial class AsynchronousSocketPage : UserControl
    {
        private bool _isServer = true;
        private ISocket _socket;

        public AsynchronousSocketPage()
        {
            InitializeComponent();

            // 初始化物件
            SetStatus(false);
        }

        private void OnConnectionStatus(object sender, ConnectionStatusEventArgs e)
        {
            if (lblSystemStatus.InvokeRequired)
            {
                lblSystemStatus.Invoke(new Action<bool>(SetStatus), e.IsConnected);
                return;
            }

            SetStatus(e.IsConnected);
        }

        private void OnMessageReceived(object sender, SocketMessageEventArgs e)
        {
            if (txtContent.InvokeRequired)
            {
                txtContent.Invoke(new EventHandler<SocketMessageEventArgs>(OnMessageReceived), sender, e);
                return;
            }

            txtContent.Text = e.Content;
        }

        private void OnTransactionError(object sender, ExceptionEventArgs e)
        {
            MessageBox.Show(e.Ex.ToString());
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            bool isServer = rdoSocketOfServer.Checked;

            // 初始化物件
            if (_isServer != isServer || _socket == null)
            {
                _isServer = isServer;

                if (_isServer)
                {
                    _socket = new AsynchronousSocketServer();
                }
                else
                {
                    _socket = new AsynchronousSocketClient();
                }

                _socket.ConnectionStatus += OnConnectionStatus;
                _socket.MessageReceived += OnMessageReceived;
                _socket.TransactionError += OnTransactionError;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_socket.IsConnected)
            {
                return;
            }

            _socket.SetConnection(txtIPAddress.Text, 11000);
            _socket.Connect();
            //SetStatus(_server.IsConnected);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _socket.Disconnect();
            //SetStatus(_server.IsConnected);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            _socket.Send(txtContent.Text);
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
