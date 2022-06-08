using KTCommon.Structures;
using System;

namespace KTCommon.Interfaces
{
    public interface ISocket : IConnect, IDisposable
    {
        event EventHandler<SocketMessageEventArgs> MessageReceived;
        event EventHandler<ExceptionEventArgs> TransactionError;

        void SetConnection(string ip, int port);
        void Send(string content);
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
