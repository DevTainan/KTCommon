using KTCommon.Interfaces;
using System;
using System.Net;
using System.Net.Sockets;

namespace KTCommon.Internet
{
    public sealed class KtTcpTransfer : ITcpTransfer
    {
        private TcpListener _server;
        private TcpClient _client;
        private IPAddress _ipAddr = IPAddress.None;
        private int _port;
        private bool _isServer;
        
        public bool IsConnected { get { return _isServer ? IsServerConnected : IsClientConnected; } }
        //public bool IsServerConnected { get { return !(_server == null || !_server.Server.IsConnected()); } }
        private bool IsServerConnected { get; set; }
        public bool IsClientConnected { get { return !(_client == null || _client.Client.Connected == false || !_client.Client.IsConnected()); } }
        
        public void SetConnectionInfo(string ip, int port, bool isServer = false)
        {
            _ipAddr = IPAddress.Parse(ip);
            _port = port;
            _isServer = isServer;
        }

        public void Connect()
        {
            if (_isServer)
            {
                _server = new TcpListener(_ipAddr, _port);
                _server.Start();
                IsServerConnected = true;

                WaitClientConnect();
            }
            else
            {
                _client = new TcpClient();
                _client.Connect(_ipAddr, _port);
            }
        }

        public void Disconnect()
        {
            if (_isServer)
            {
                _server.Stop();
                IsServerConnected = false;
            }
            else
            {
                _client.Close();
            }
        }

        public NetworkStream GetStream()
        {
            if (_isServer)
            {
                if (IsClientConnected == false)
                {
                    WaitClientConnect();
                }

                return _client.GetStream();
            }
            else
            {
                return _client.GetStream();
            }
        }

        private void WaitClientConnect()
        {
            // https://docs.microsoft.com/zh-tw/dotnet/api/system.net.sockets.tcplistener.beginaccepttcpclient?view=net-6.0
            // Accept the connection.
            // BeginAcceptSocket() creates the accepted socket.
            _server.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), _server);
        }

        // Process the client connection.
        private void DoAcceptTcpClientCallback(IAsyncResult ar)
        {
            try
            {
                // Get the listener that handles the client request.
                TcpListener listener = (TcpListener)ar.AsyncState;

                // End the operation and display the received data on
                // the console.
                _client = listener.EndAcceptTcpClient(ar);
            }
            catch (ObjectDisposedException)
            {
                // cancel
            }
        }

        #region IDisposable
        // Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Protected implementation of Dispose pattern.
        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free any other managed objects here.
                //
                Disconnect();
            }
            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        ~KtTcpTransfer()
        {
            Dispose(false);
        }
        #endregion
    }

    internal static class SocketExtensions
    {
        /// <summary>
        /// Extension method to tell if the Socket REALLY is closed
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static bool IsConnected(this Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }
    }
}
