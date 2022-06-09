using KTCommon.Interfaces;
using KTCommon.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace KTCommon.Internet
{
    // refernce: 
    // https://docs.microsoft.com/zh-tw/dotnet/framework/network-programming/using-an-asynchronous-client-socket
    public class AsynchronousSocketClient : ISocket
    {
        private string _ip = "127.0.0.1";
        // The port number for the remote device.  
        private int _port = 11000;

        private Socket _client;

        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone = new ManualResetEvent(false);
        //private static ManualResetEvent sendDone = new ManualResetEvent(false);
        private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        // The response from the remote device.  
        private static string response = string.Empty;


        public bool IsConnected { get; set; }


        public event EventHandler<ConnectionStatusEventArgs> ConnectionStatus;
        private void TriggerConnectionStatus(bool isConnected)
        {
            if (IsConnected == isConnected)
            {
                return;
            }

            IsConnected = isConnected;
            ConnectionStatus?.Invoke(this, new ConnectionStatusEventArgs(IsConnected));
        }

        public event EventHandler<SocketMessageEventArgs> MessageReceived;
        public event EventHandler<ExceptionEventArgs> TransactionError;

        public void SetConnection(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }

        public void Connect()
        {
            if (IsConnected)
            {
                return;
            }

            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // The name of the
                // remote device is "host.contoso.com".  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(_ip);
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, _port);

                // Create a TCP/IP socket.  
                _client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                _client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), _client);
                connectDone.WaitOne();

                //// Send test data to the remote device.  
                //Send(client, "This is a test<EOF>");
                //sendDone.WaitOne();

                //// Receive the response from the remote device.  
                //Receive(_client);
                //receiveDone.WaitOne();
                System.Threading.Tasks.Task.Factory.StartNew(StartReceiving);

                //// Write the response to the console.  
                //Console.WriteLine("Response received : {0}", response);

                //// Release the socket.  
                //client.Shutdown(SocketShutdown.Both);
                //client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Disconnect()
        {
            if (IsConnected == false)
            {
                return;
            }

            // Release the socket.  
            _client.Shutdown(SocketShutdown.Both);
            _client.Close();

            TriggerConnectionStatus(false);
        }

        public void Send(string content)
        {
            // Send test data to the remote device.  
            //Send(_client, "This is a test<EOF>");
            //sendDone.Reset();
            Send(_client, content);
            //sendDone.WaitOne();

            //// Receive the response from the remote device.  
            //Receive(_client);
            //receiveDone.WaitOne();
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                // Signal that the connection has been made.  
                connectDone.Set();

                //Console.WriteLine("Socket connected to {0}",
                //    client.RemoteEndPoint.ToString());
                TriggerConnectionStatus(true);
            }
            catch (Exception ex)
            {
                // Signal that the connection has been made.  
                connectDone.Set();

                //Console.WriteLine(ex.ToString());
                TransactionError?.Invoke(this, new ExceptionEventArgs(ex));
            }
        }

        private void StartReceiving()
        {
            while (IsConnected)
            {
                // Set the event to nonsignaled state.  
                receiveDone.Reset();

                // Receive the response from the remote device.  
                try
                {
                    // Create the state object.  
                    StateObject state = new StateObject();
                    state.workSocket = _client;

                    // Begin receiving the data from the remote device.  
                    _client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    TransactionError?.Invoke(this, new ExceptionEventArgs(ex));
                }

                receiveDone.WaitOne();
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // 斷線時, 也會觸發此事件
                if (client.Connected == false)
                {
                    receiveDone.Set();
                    //MessageReceived?.Invoke(this, new SocketMessageEventArgs("Disconnected"));
                    return;
                }

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read
                    // more data.  
                    response = state.sb.ToString();
                    if (response.IndexOf("<EOF>") > -1)
                    {
                        // Signal that all bytes have been received.  
                        receiveDone.Set();

                        //// All the data has been read from the
                        //// client. Display it on the console.  
                        MessageReceived?.Invoke(this, new SocketMessageEventArgs(response));
                    }
                    else
                    {
                        // Get the rest of the data.  
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);
                    }
                }
            }
            catch (Exception ex)
            {
                TransactionError?.Invoke(this, new ExceptionEventArgs(ex));
            }
        }

        private void Send(Socket client, string data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data + "<EOF>");

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                //Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                //sendDone.Set();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TransactionError?.Invoke(this, new ExceptionEventArgs(ex));
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
        ~AsynchronousSocketClient()
        {
            Dispose(false);
        }
        #endregion
    }

    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }
}
