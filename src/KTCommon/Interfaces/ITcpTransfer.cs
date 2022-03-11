using KTCommon.Structures;
using System;
using System.Net.Sockets;

namespace KTCommon.Interfaces
{
    public interface ITcpTransfer : IDisposable
    {
        bool IsConnected { get; }
        bool IsClientConnected { get; }
        void Connect();
        void Disconnect();
        NetworkStream GetStream();
    }
}
