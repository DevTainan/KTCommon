using KTCommon.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTCommon.Interfaces
{
    public interface ISocket : IDisposable
    {
        event EventHandler<ConnectionStatusEventArgs> ConnectionStatus;
        event EventHandler<SocketMessageEventArgs> MessageReceived;
        event EventHandler<ExceptionEventArgs> TransactionError;

        bool IsConnected { get; }
        void SetConnection(string ip, int port);
        void Connect();
        void Disconnect();
        void Send(string content);
    }

    public class ConnectionStatusEventArgs : EventArgs
    {
        public bool IsConnected { get; private set; }

        public ConnectionStatusEventArgs(bool isConnected)
        {
            IsConnected = isConnected;
        }
    }

    public class SocketMessageEventArgs : EventArgs
    {
        public string Content { get; private set; }

        public SocketMessageEventArgs(string content)
        {
            Content = content;
        }
    }
}
