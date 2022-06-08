using KTCommon.Interfaces;
using KTCommon.Structures;
using KTCommon.Timers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace KTCommon.EventBus
{
    /// <summary>
    /// 程式內部的 MQ 物件
    /// </summary>
    public class KTAppEventBus : IEventBus
    {
        private static KTAppEventBus instance = null;
        private static readonly object padlock = new object();

        private KTAppEventBus()
        {
            _queue = new ConcurrentQueue<EventBusMessageEventArgs>();
            _timer = new KtTimer(50, ProcessQueue);
            _timer.Starting += (object sender, EventArgs e) =>
            {
                ConnectionStatus?.Invoke(this, new ConnectionStatusEventArgs(true));
            };
            _timer.Stopped += (object sender, EventArgs e) =>
            {
                ConnectionStatus?.Invoke(this, new ConnectionStatusEventArgs(false));
            };
            _timer.Error += (object sender, ExceptionEventArgs e) =>
            {
                TransactionError?.Invoke(this, e);
            };
        }

        public static KTAppEventBus Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new KTAppEventBus();
                        }
                    }
                }
                return instance;
            }
        }

        public bool IsConnected { get { return _timer.IsTimerEnabled; } }

        private readonly ConcurrentQueue<EventBusMessageEventArgs> _queue;   // 存放訊息
        private readonly KtTimer _timer;

        public event EventHandler<EventBusMessageEventArgs> MessageReceived;
        public event EventHandler<ExceptionEventArgs> TransactionError;
        public event EventHandler<ConnectionStatusEventArgs> ConnectionStatus;

        private void ProcessQueue()
        {
            if (_queue.Count <= 0)
            {
                return;
            }

            var queue = new Queue<EventBusMessageEventArgs>(_queue);
            while (_queue.Count > 0)
            {
                _queue.TryDequeue(out EventBusMessageEventArgs message);
            }

            while (queue.Count > 0)
            {
                EventBusMessageEventArgs arg = queue.Peek();

                //foreach (var kvp in _manager.GetAll())
                //{
                MessageReceived?.Invoke(this, arg);
                //}

                queue.Dequeue();
            }
        }

        /// <summary>
        /// 發送新消息
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="messageId"></param>
        /// <param name="content"></param>
        public void Send(string channelId, string messageId, string content)
        {
            if (IsConnected == false)
            {
                throw new Exception("KTAppEventBus is disconnected.");
            }

            _queue.Enqueue(new EventBusMessageEventArgs(channelId, messageId, content));
        }

        public void Connect()
        {
            _timer.Start(); // 開始處理
        }

        public void Disconnect()
        {
            _timer.Stop();  // 停止處理
        }

        public void Dispose() { }
    }
}
