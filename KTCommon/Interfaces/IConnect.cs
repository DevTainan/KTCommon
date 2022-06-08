using System;

namespace KTCommon.Interfaces
{
    public interface IConnect
    {
        event EventHandler<ConnectionStatusEventArgs> ConnectionStatus;

        bool IsConnected { get; }
        void Connect();
        void Disconnect();
    }

    public class ConnectionStatusEventArgs : EventArgs
    {
        public bool IsConnected { get; private set; }

        public ConnectionStatusEventArgs(bool isConnected)
        {
            IsConnected = isConnected;
        }
    }
}
