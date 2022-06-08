using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KTCommon.Timers
{
    /// <summary>
    /// Task 管理者, 負責處理 Timer 啟動與終止
    /// </summary>
    /// <remarks>
    /// System.Threading.Timer
    /// https://msdn.microsoft.com/zh-tw/library/system.threading.timer(v=vs.110).aspx
    /// </remarks>
    public sealed class TaskManagerByThreadingTimer
    {
        #region Member

        private static TaskManagerByThreadingTimer instance = null;
        private static readonly object padlock = new object();
        private Dictionary<string, Timer> _timerDic;
        private Dictionary<string, BaseTask> _taskDic;

        #endregion

        #region Property

        private int _IntervalMillisecondsOfPolling;

        public int IntervalMillisecondsOfPolling
        {
            get { return _IntervalMillisecondsOfPolling; }
        }

        /// <summary>
        /// Timer 間隔時間 (秒)
        /// </summary>
        public int IntervalSecondsOfPolling
        {
            get
            {
                var timeSpan = new TimeSpan(0, 0, 0, 0, _IntervalMillisecondsOfPolling);
                return Convert.ToInt32(timeSpan.TotalSeconds);
            }
            set
            {
                var timeSpan = new TimeSpan(0, 0, value);
                _IntervalMillisecondsOfPolling = Convert.ToInt32(timeSpan.TotalMilliseconds);

                // 若已經執行, 則修改時間間隔
                foreach (var timer in _timerDic.Values)
                {
                    timer.Change(0, _IntervalMillisecondsOfPolling);
                }
            }
        }

        /// <summary>
        /// 是否開始執行
        /// </summary>
        public bool IsRunning { get; private set; }

        #endregion

        #region Event

        public EventHandler<MessageEventArgs> OnMessage;

        private void TriggerMessageEvent(string message, LogLevel logLevel)
        {
            OnMessage?.Invoke(this, new MessageEventArgs(message, logLevel));
        }

        private void TriggerMessageEvent(MessageEventArgs args)
        {
            OnMessage?.Invoke(this, args);
        }

        private void task_OnMessage(object sender, MessageEventArgs e)
        {
            TriggerMessageEvent(e);
        }

        #endregion

        private TaskManagerByThreadingTimer()
        {
            // Initial
            _timerDic = new Dictionary<string, Timer>();
            _taskDic = new Dictionary<string, BaseTask>();
            IntervalSecondsOfPolling = 10;   // 預設 10 秒
        }

        public static TaskManagerByThreadingTimer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new TaskManagerByThreadingTimer();
                        }
                    }
                }
                return instance;
            }
        }

        #region Private Method

        #endregion

        #region Protected Method

        #endregion

        #region Public Method

        /// <summary>
        /// 開始
        /// </summary>
        public void Start()
        {
            if (IsRunning == true) // 執行中就不動作
            {
                return;
            }

            IsRunning = true;

            //// Create an AutoResetEvent to signal the timeout threshold in the
            //// timer callback has been reached.
            //var autoEvent = new AutoResetEvent(false);

            _timerDic.Clear();
            foreach (var kvp in _taskDic)
            {
                var id = kvp.Key;
                var task = kvp.Value;

                // Create a timer with a second interval.  (milliseconds)
                var timer = new Timer(task.Start, null, 0, IntervalMillisecondsOfPolling);
                _timerDic.Add(id, timer);
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (IsRunning == false) // 停止中就不動作
            {
                return;
            }

            IsRunning = false;

            foreach (var timer in _timerDic.Values)
            {
                timer.Dispose();
            }
        }

        /// <summary>
        /// 加入任務
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public string AddTask(BaseTask task)
        {
            if (IsRunning == true) // 執行中先停止
            {
                Stop();
            }

            // 先處理事件
            task.OnMessage += task_OnMessage;

            var newId = Guid.NewGuid().ToString();
            _taskDic.Add(newId, task);
            return newId;
        }

        /// <summary>
        /// 移除任務
        /// </summary>
        /// <param name="id"></param>
        public void RemoveTask(string id)
        {
            if (IsRunning == true) // 執行中先停止
            {
                Stop();
            }

            // 先處理事件
            var task = _taskDic[id];
            task.OnMessage -= task_OnMessage;

            _taskDic.Remove(id);
        }

        /// <summary>
        /// 移除所有任務
        /// </summary>
        public void RemoveAllTask()
        {
            if (IsRunning == true) // 執行中先停止
            {
                Stop();
            }

            // 先處理事件
            foreach (var task in _taskDic.Values)
            {
                task.OnMessage -= task_OnMessage;
            }

            _taskDic.Clear();
        }

        #endregion
    }
}
