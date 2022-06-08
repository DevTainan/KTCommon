using KTCommon.Interfaces;
using KTCommon.Structures;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTCommon.Internet
{
    // refernce: 
    // https://docs.microsoft.com/zh-tw/dotnet/framework/network-programming/asynchronous-server-socket-example
    public class AsynchronousSocketServer : ISocket
    {
        private ConcurrentDictionary<string, Socket> _clients =
            new ConcurrentDictionary<string, Socket>(StringComparer.OrdinalIgnoreCase);

        // The port number for the remote device.  
        private int _port = 11000;

        private Socket _listener;

        // Thread signal.  
        private static ManualResetEvent allDone = new ManualResetEvent(false);

        public bool IsListening { get; protected set; }
        public bool IsConnected { get { return _listener != null && _listener.Connected; } }

        public event EventHandler<ConnectionStatusEventArgs> ConnectionStatus;
        private void TriggerConnectionStatus(bool isListening)
        {
            if (IsListening == isListening)
            {
                return;
            }

            IsListening = isListening;
            ConnectionStatus?.Invoke(this, new ConnectionStatusEventArgs(IsListening));
        }

        public event EventHandler<SocketMessageEventArgs> MessageReceived;
        public event EventHandler<ExceptionEventArgs> TransactionError;

        public void SetConnection(string ip, int port)
        {
            _port = port;
        }

        public void Connect()
        {
            if (IsListening)
            {
                return;
            }

            // Establish the local endpoint for the socket.  
            // The DNS name of the computer  
            // running the listener is "host.contoso.com".  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, _port);

            // Create a TCP/IP socket.  
            _listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                _listener.Bind(localEndPoint);
                _listener.Listen(100);

                TriggerConnectionStatus(true);

                Task.Factory.StartNew(StartListing);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            //Console.WriteLine("\nPress ENTER to continue...");
            //Console.Read();

        }

        private void StartListing()
        {
            while (IsListening)
            {
                // Set the event to nonsignaled state.  
                allDone.Reset();

                // Start an asynchronous socket to listen for connections.  
                Console.WriteLine("Waiting for a connection...");
                _listener.BeginAccept(
                    new AsyncCallback(AcceptCallback),
                    _listener);

                // Wait until a connection is made before continuing.  
                allDone.WaitOne();
            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            allDone.Set();

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;

            Socket handler = listener.EndAccept(ar);

            // 加入 Client 清單
            _clients.TryAdd(handler.LocalEndPoint.ToString(), handler);

            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        private void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read
                // more data.  
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the
                    // client. Display it on the console.  
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);
                    // Echo the data back to the client.  
                    Send(handler, content);
                }
                else
                {
                    // Not all data received. Get more.  
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }

        private static void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public void Disconnect()
        {
            if (IsListening == false)
            {
                return;
            }

            TriggerConnectionStatus(false); //先變更 IsConnected 屬性, 停止背景的監聽

            // Release the socket.  
            try
            {
                //_listener.Shutdown(SocketShutdown.Both);
                _listener.Close();
            }
            catch (SocketException ex)
            {
                string temp = ex.ToString();
            }
        }

        public void Send(string content)
        {
            foreach (Socket client in _clients.Values)
            {
                Send(client, content);
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
        protected virtual void Dispose(bool disposing)
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
        ~AsynchronousSocketServer()
        {
            Dispose(false);
        }
        #endregion
    }
}
