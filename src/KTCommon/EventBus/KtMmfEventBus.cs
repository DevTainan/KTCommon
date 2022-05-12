using KTCommon.Interfaces;
using KTCommon.Structures;
using KTCommon.Timers;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;

namespace KTCommon.EventBus
{
    /// <summary>
    /// EventBus by MemoryMappedFile
    /// </summary>
    /// <remarks>
    /// 參考資料
    /// 1. 黑暗執行緒 - 關於 Shared Memory 的兩三事
    /// https://blog.darkthread.net/blog/about-shared-memory/
    /// 2. MSDN - Memory-mapped files
    /// https://docs.microsoft.com/zh-tw/dotnet/standard/io/memory-mapped-files
    /// </remarks>
    public class KtMmfEventBus : IEventBus
    {
        private bool _isMaster = true;
        private static readonly long _size = 512;
        private KtTimer _timer;
        private MemoryMappedFile _mmf;

        private readonly object _lockOfTicks = new object();
        private long _ticks;
        private long Ticks 
        {
            get { return _ticks; }
            set 
            {
                lock (_lockOfTicks)
                {
                    _ticks = value;
                }
            }
        }

        private long WriteOffset { get { return _isMaster ? 0 : _size; } }
        private long ReadOffset { get { return _isMaster ? _size : 0; } }

        public bool IsConnected { get { return !(_mmf == null || _mmf.SafeMemoryMappedFileHandle.IsClosed); } }

        #region Event

        public event EventHandler<EventBusMessageEventArgs> MessageReceived;
        public event EventHandler<ExceptionEventArgs> TransactionError;

        #endregion

        public KtMmfEventBus()
        {
            _timer = new KtTimer(double.Epsilon, ReceiveData);
            _timer.Error += (object sender, ExceptionEventArgs e) =>
            {
                TransactionError?.Invoke(this, e);
            };
        }

        public void SetConnectionInfo(bool isMaster)
        {
            _isMaster = isMaster;
        }

        public void Connect()
        {
            if (IsConnected)
            {
                return;
            }

            Ticks = -1;   // it can read the data when restart the program.
            _mmf = MemoryMappedFile.CreateOrOpen("KtCommon", _size * 2);
            _timer.Start();
        }

        public void Disconnect()
        {
            if (IsConnected == false)
            {
                return;
            }

            _timer.Stop();
            _mmf.Dispose();
        }

        public void Send(string channelId, string messageId, string content)
        {
            try
            {
                bool mutexCreated = false;
                using (Mutex mutex = new Mutex(true, "KtMmfEventBus", out mutexCreated))
                {
                    using (MemoryMappedViewStream stream = _mmf.CreateViewStream(WriteOffset, _size))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(DateTime.UtcNow.Ticks);
                        writer.Write(channelId);
                        writer.Write(messageId);
                        writer.Write(content);
                    }

                    mutex.ReleaseMutex();
                }
            }
            catch (Exception ex)
            {
                TransactionError?.Invoke(this, new ExceptionEventArgs(ex));
            }
        }

        private void ReceiveData()
        {
            long ticks = 0;
            string channelId = null;
            string messageId = null;
            string content = null;
            using (MemoryMappedViewStream stream = _mmf.CreateViewStream(ReadOffset, _size))
            {
                using (var reader = new BinaryReader(stream))
                {
                    ticks = reader.ReadInt64();
                    channelId = reader.ReadString();
                    messageId = reader.ReadString();
                    content = reader.ReadString();
                }
            }

            if (Ticks != ticks)
            {
                Ticks = ticks;
                MessageReceived?.Invoke(this, new EventBusMessageEventArgs(channelId, messageId, content));
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
        ~KtMmfEventBus()
        {
            Dispose(false);
        }
        #endregion
    }
}
