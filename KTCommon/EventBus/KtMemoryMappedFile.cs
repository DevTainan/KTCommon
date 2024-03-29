﻿using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;

namespace KTCommon.EventBus
{
    public class KtMemoryMappedFile : IDisposable
    {
        // https://learn.microsoft.com/en-us/dotnet/api/system.io.memorymappedfiles.memorymappedfile?view=net-7.0
        private MemoryMappedFile _mmf;
        private readonly long _size = 512;  // 要配置給記憶體對應檔的大小上限 (以位元組為單位)
        private static readonly string _mutexName = "KtMemoryMappedFile";
        private static Mutex _mutex;

        public bool IsConnected { get { return !(_mmf == null || _mmf.SafeMemoryMappedFileHandle.IsClosed); } }

        public KtMemoryMappedFile()
        {
        }

        public KtMemoryMappedFile(long size) : this()
        {
            _size = size;
        }

        public void Connect(string mapName)
        {
            if (IsConnected)
            {
                return;
            }

            string mutexName = _mutexName + "_" + mapName;
            _mmf = MemoryMappedFile.CreateOrOpen(mapName, _size);

            bool mutexCreated = false;
            _mutex = new Mutex(false, mutexName, out mutexCreated);

            if (mutexCreated == false)
            {
                bool doesNotExist = false;
                try
                {
                    // Open the mutex with (MutexRights.Synchronize |
                    // MutexRights.Modify), to enter and release the
                    // named mutex.
                    //
                    _mutex = Mutex.OpenExisting(mutexName, System.Security.AccessControl.MutexRights.FullControl);
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    //Console.WriteLine("Mutex does not exist.");
                    doesNotExist = true;
                }
                //catch (UnauthorizedAccessException ex)
                //{
                //    Console.WriteLine("Unauthorized access: {0}", ex.Message);
                //    unauthorized = true;
                //}
            }
        }

        public void Disconnect()
        {
            if (IsConnected == false)
            {
                return;
            }

            _mmf.Dispose();
        }

        public void Set(string content)
        {
            if (IsConnected == false)
            {
                return;
            }

            try
            {
                //bool mutexCreated = false;
                //using (Mutex mutex = new Mutex(true, "KtMemoryMappedFile", out mutexCreated))
                //{
                    _mutex.WaitOne();
                    using (MemoryMappedViewStream stream = _mmf.CreateViewStream(0, _size))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(content);
                    }
                //}
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }

        public string Get()
        {
            if (IsConnected == false)
            {
                return null;
            }

            try
            {
                _mutex.WaitOne();
                using (MemoryMappedViewStream stream = _mmf.CreateViewStream(0, _size))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        return reader.ReadString();
                    }
                }
            }
            finally
            {
                _mutex.ReleaseMutex();
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
        ~KtMemoryMappedFile()
        {
            Dispose(false);
        }
        #endregion
    }
}
