using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace KTCommon.Timers
{
    /// <summary>
    /// Task 管理者, 負責處理 Timer 啟動與終止
    /// </summary>
    /// <remarks>
    /// System.Timers.Timer
    /// https://msdn.microsoft.com/zh-tw/library/system.timers.timer(v=vs.100).aspx
    /// </remarks>
    public abstract class TaskManager
    {
        #region Member

        private Timer _timer;

        #endregion

        #region Property

        /// <summary>
        /// Timer 間隔時間 (豪秒)
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/zh-tw/library/system.timers.timer.interval(v=vs.100).aspx
        /// 如果間隔是在 Timer 啟動後才設定，計數將重設。 
        /// 例如，如果您將間隔設定為 5 秒，然後將 Enabled 屬性設定為 true，計數將會在時間設定 Enabled 後啟動。 
        /// 如果您在計數為 3 秒時將間隔重設為 10 秒，當 Enabled 設定為 true 後的 13 秒，將首次引發 Elapsed 事件。
        /// </remarks>
        public double IntervalMillisecondsOfPolling
        {
            get
            {
                return _timer.Interval;
            }
            set
            {
                _timer.Interval = value;
            }
        }

        /// <summary>
        /// Timer 間隔時間 (秒)
        /// </summary>
        /// <remarks>
        /// https://msdn.microsoft.com/zh-tw/library/system.timers.timer.interval(v=vs.100).aspx
        /// 如果間隔是在 Timer 啟動後才設定，計數將重設。 
        /// 例如，如果您將間隔設定為 5 秒，然後將 Enabled 屬性設定為 true，計數將會在時間設定 Enabled 後啟動。 
        /// 如果您在計數為 3 秒時將間隔重設為 10 秒，當 Enabled 設定為 true 後的 13 秒，將首次引發 Elapsed 事件。
        /// </remarks>
        public int IntervalSecondsOfPolling
        {
            get
            {
                double milliseconds = _timer.Interval;
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);
                return Convert.ToInt32(timeSpan.TotalSeconds);
            }
            set
            {
                TimeSpan timeSpan = new TimeSpan(0, 0, value);
                _timer.Interval = timeSpan.TotalMilliseconds;
            }
        }

        /// <summary>
        /// Timer 是否開始執行
        /// </summary>
        public bool IsTimerEnabled { get { return _timer.Enabled; } }

        private readonly object _lockOfIsRunning = new object();
        private bool _isRunning;

        /// <summary>
        /// 是否執行中 (Timer 停止, 可能還在執行中? ex:搬移檔案)
        /// </summary>
        public bool IsRunning
        {
            get { return _isRunning; }
            protected set
            {
                lock (_lockOfIsRunning)
                {
                    _isRunning = value;
                }
            }
        }

        /// <summary>
        /// Pass 的次數
        /// </summary>
        protected int PassCount { get; set; }

        #endregion

        #region Event

        /// <summary>
        /// 訊息事件
        /// </summary>
        public EventHandler<MessageEventArgs> Message;

        #endregion

        public TaskManager()
        {
            // Create a timer with a five second interval.  (milliseconds)
            _timer = new Timer(5000);

            // Hook up the Elapsed event for the timer.
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent); ;
            _timer.Enabled = false;
        }

        #region Private Method

        /// <summary>
        /// Timer 觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (IsRunning)  // 執行中就不要觸發
            {
                try
                {
                    Pass(PassCount++);
                }
                catch (Exception ex)
                {
                    Message?.Invoke(this, new MessageEventArgs($"OnTimedEvent Exception: {ex}", LogLevel.Error));
                }

                return;
            }

            try
            {
                IsRunning = true;
                PassCount = 0;
                Process();
            }
            catch(Exception ex)
            {
                Message?.Invoke(this, new MessageEventArgs($"OnTimedEvent Exception: {ex}", LogLevel.Error));
            }
            finally
            {
                IsRunning = false;
            }
        }

        #endregion

        #region Protected Method

        /// <summary>
        /// Pass 處理的方法
        /// </summary>
        protected virtual void Pass(int count) { }

        /// <summary>
        /// 實際處理的方法
        /// </summary>
        protected abstract void Process();

        /// <summary>
        /// 停止後的額外處理
        /// </summary>
        protected virtual void Stopped() { }

        /// <summary>
        /// 開始前的額外處理
        /// </summary>
        protected virtual void OnStart() { }

        #endregion

        #region Public Method

        /// <summary>
        /// 開始
        /// </summary>
        public void Start()
        {
            if (_timer.Enabled == true) // 執行中就不動作
            {
                return;
            }

            _timer.Enabled = true;

            // 啟動時, 可覆寫的方法
            OnStart();

            // 若是啟動, 需先執行一次動作
            System.Threading.ThreadStart threadDelegate = new System.Threading.ThreadStart(TriggerTimedEvent);
            System.Threading.Thread thread = new System.Threading.Thread(threadDelegate);
            //System.Threading.Thread thread = new System.Threading.Thread(new delegate
            //{
            //    OnTimedEvent(this, null);
            //});
            thread.Start();
        }
        
        private void TriggerTimedEvent()
        {
            OnTimedEvent(this, null);
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (_timer.Enabled == false)
            {
                return;
            }

            _timer.Enabled = false;
            IsRunning = false;	//todo: 這邊可以取消? Timer 會處理是否執行中

            // 停止時, 可覆寫的方法
            Stopped();
        }

        #endregion
    }
}
