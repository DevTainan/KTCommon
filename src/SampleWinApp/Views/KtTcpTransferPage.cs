using System;
using System.Drawing;
using System.Windows.Forms;
using SampleWinApp.Models;
using KTCommon.Internet;
using System.IO;

namespace SampleWinApp.Views
{
    public partial class KtTcpTransferPage : UserControl
    {
        private KtTcpTransfer _client;

        public KtTcpTransferPage()
        {
            InitializeComponent();

            // 初始化物件
            SetStatus(false);
            SetStatusForClient(false);

            _client = new KtTcpTransfer();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _client.SetConnectionInfo(txtIpAddr.Text, Convert.ToInt32(txtPort.Text), rdoServer.Checked);
            _client.Connect();
            SetStatus(_client.IsConnected);
            SetStatusForClient(_client.IsClientConnected);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _client.Disconnect();
            SetStatus(_client.IsConnected);
            SetStatusForClient(_client.IsClientConnected);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var stream = _client.GetStream();
            if (stream.CanWrite == false)
            {
                MessageBox.Show("CanWrite == false");
                return;
            }

            using (var fs = File.Open(txtFilePath.Text, FileMode.Open))
            {
                //using (var stream = _client.GetStream())
                //{
                //    fs.CopyTo(stream);
                //}

                //fs.CopyTo(stream);
                //fs.Flush();

                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);

                    var buffer = ms.ToArray();

                    // 先寫入圖片長度, 再寫入圖片
                    stream.Write(BitConverter.GetBytes(buffer.Length), 0, 4);
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            var stream = _client.GetStream();
            if (stream.DataAvailable == false)
            {
                MessageBox.Show("DataAvailable == false");
                return;
            }

            //Image image = Image.FromStream(stream);
            //picImage.Image = image;

            // 先讀取圖片長度, 再讀取圖片
            var bufferOfSize = new byte[4];
            int read = stream.Read(bufferOfSize, 0, 4);
            int imageSize = BitConverter.ToInt32(bufferOfSize, 0);

            var bufferOfImage = new byte[imageSize];
            int bytesRead = 0;
            int totalBytesRead = 0;
            while ((bytesRead = stream.Read(bufferOfImage, 0, bufferOfImage.Length)) != 0)
            {
                totalBytesRead += bytesRead;
                if (totalBytesRead == imageSize)
                {
                    //Save image
                    break;
                }
                else if (totalBytesRead > imageSize)
                {
                    //May happens, split the buffer.
                }
            }

            using (var ms = new MemoryStream(bufferOfImage))
            {
                Image image = Image.FromStream(ms);
                picImage.Image = image;
            }
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

        private void SetStatusForClient(bool isSuccess)
        {
            if (isSuccess)
            {

                lblSystemStatusForClient.BackColor = AppConstant.SucessColor;
                lblSystemStatusForClient.Text = AppConstant.Connected;
            }
            else
            {
                lblSystemStatusForClient.BackColor = AppConstant.FailColor;
                lblSystemStatusForClient.Text = AppConstant.Disconnected;
            }
        }

        private void lblSystemStatus_Click(object sender, EventArgs e)
        {
            SetStatus(_client.IsConnected);
        }

        private void lblSystemStatusForClient_Click(object sender, EventArgs e)
        {
            SetStatusForClient(_client.IsClientConnected);
        }
    }
}
