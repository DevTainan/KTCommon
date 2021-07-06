using KTCommon.Interfaces;
using KTCommon.Structures;
using KTCommon.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace KTCommon.EventBus
{
    public class KtSingleEventBus : IEventBus
    {
        private object _lockOfMessage = new object();
        private object _lockOfIsConnected = new object();
        private Socket _socket;
        private byte[] cv_RecevieBuffer = new byte[65536];

        private string _ip = "127.0.0.1";
        public string IP
        {
            get
            {
                return _ip;
            }
            protected set
            {
                _ip = value;
            }
        }

        private int _port = 11000;
        public int Port
        {
            get
            {
                return _port;
            }
            protected set
            {
                _port = value;
            }
        }

        private bool _isConnected = false;
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            protected set
            {
                _isConnected = value;
            }
        }

        private bool _isOpen = false;
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            protected set
            {
                _isOpen = value;
            }
        }

        private bool _isActiveRole = false;
        public bool IsActiveRole
        {
            get
            {
                return _isActiveRole;
            }
            protected set
            {
                _isActiveRole = value;
            }
        }

        private KtTimer cv_SocketProcessTimer;
        private KtTimer cv_DataProcessTimer;
        private KtTimer cv_EventProcessTimer;

        public event EventHandler<EventBusMessageEventArgs> MessageReceived;
        public event EventHandler<ExceptionEventArgs> TransactionError;

        public KtSingleEventBus()
        {
            this.cv_SocketProcessTimer = new KtTimer(300, new Action(OnSocketProcess));
        }

        private void OnSocketProcess()
        {
            if (_socket == null)
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            if (_isOpen == false)
            {
                return;
            }
            if (IsOpen && IsConnected == false)
            {
                try
                {
                    if (IsActiveRole == false)
                    {
                        _socket.Bind(new IPEndPoint(IPAddress.Any, _port));
                        _socket.Listen(1);
                        Socket cvSocket = _socket;
                        _socket = cvSocket.Accept();
                        cvSocket.Close();
                    }
                    else
                    {
                        _socket.Connect(new IPEndPoint(IPAddress.Parse(_ip), _port));
                    }
                }
                catch
                {
                    _socket = null;
                    Thread.Sleep(3000);
                }
                Thread.Sleep(1000);
            }
            if (!this.CheckSocketConnection())
            {
                this.ProcessConnectionEvent();
                return;
            }
            this.ProcessConnectionEvent();
            this.ReadSocketData();
            //this.cv_SocketProcessTimer.SetEvent();
        }

        public void Connect()
        {
            lock (_lockOfIsConnected)
            {
                try
                {
                    if (!IsConnected && !IsOpen)
                    {
                        IsOpen = true;
                    }
                    //this.cv_SocketProcessTimer.SetEvent();
                    //this.cv_DataProcessTimer.SetEvent();
                }
                catch
                {
                }
            }
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Send(string channelId, string messageId, string content)
        {
            throw new NotImplementedException();
        }


        private bool CheckSocketConnection()
        {
            bool flag;
            if (_socket == null)
            {
                return false;
            }
            bool flag1 = false;
            try
            {
                if (_socket.Connected)
                {
                    if (!_socket.Poll(1, 0))
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            Thread.Sleep(10);
                            if (_socket.Poll(1, 0))
                            {
                                break;
                            }
                        }
                    }
                    if (!_socket.Poll(1, 0))
                    {
                        flag1 = true;
                    }
                    else if (_socket.Available != 0)
                    {
                        flag1 = true;
                    }
                    else
                    {
                        _socket = null;
                        Thread.Sleep(3000);
                    }
                }
                return flag1;
            }
            catch
            {
                _socket = null;
                flag = false;
            }
            return flag;
        }

        private void ProcessConnectionEvent()
        {
            bool connected = false;
            if (_socket != null)
            {
                connected = _socket.Connected;
            }
            if (!connected)
            {
                try
                {
                    if (_socket != null)
                    {
                        _socket.Close();
                        _socket = null;
                        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    }
                }
                catch
                {
                }
            }
            //if (IsConnected && !connected)
            //{
            //    IsConnected = false;
            //    //this.WriteTxLog("Disconnected!");
            //    KSingleEventBus.EventItem eventItem = new KSingleEventBus.EventItem()
            //    {
            //        Ticket = 0,
            //        EventCode = 3
            //    };
            //    this.AddEventItem(eventItem);
            //    return;
            //}
            //if (!IsConnected && connected)
            //{
            //    IsConnected = true;
            //    //this.WriteTxLog("Connected!");
            //    KSingleEventBus.EventItem eventItem1 = new KSingleEventBus.EventItem()
            //    {
            //        Ticket = 0,
            //        EventCode = 2
            //    };
            //    this.AddEventItem(eventItem1);
            //}
        }

        private void ReadSocketData()
        {
            if (_socket == null)
            {
                return;
            }

            try
            {
                if (_socket.Connected)
                {
                    while (_socket.Poll(0, 0) && _socket.Available > 0)
                    {
                        int num = _socket.Receive(this.cv_RecevieBuffer);
                        if (num <= 0)
                        {
                            break;
                        }
                        this.OnReceiveData(this.cv_RecevieBuffer, num);
                    }
                }
            }
            catch
            {
            }
        }

        private void OnReceiveData(byte[] m_Buffer, int m_BufferSize)
        {
            if (m_BufferSize <= 0)
            {
                return;
            }
            //if (this.cv_LogTransaction)
            //{
            //    this.WriteTxLog(string.Concat("Recv Binary: ", SysUtils.ToString(m_BufferSize)));
            //}
            //if (this.cv_LogTransaction && this.cv_LogBinary)
            //{
            //    string hex = SysUtils.BinaryToHex(m_Buffer, m_BufferSize);
            //    this.WriteTxLog("Recv:");
            //    this.WriteTxLog(hex);
            //}
            lock (_lockOfMessage)
            {

            }
            //this.cv_ReadStreamCs.Enter();
            //try
            //{
            //    long position = this.cv_ReadStream.Position;
            //    this.cv_ReadStream.Seek(0, 2);
            //    this.cv_ReadStream.Write(m_Buffer, m_BufferSize);
            //    this.cv_ReadStream.Position = position;
            //}
            //catch
            //{
            //}
            //this.cv_ReadStreamCs.Leave();
        }
    }
}
