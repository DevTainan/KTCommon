using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace KTCommon
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
                var timeSpan = TimeSpan.FromMilliseconds(milliseconds);
                return Convert.ToInt32(timeSpan.TotalSeconds);
            }
            set
            {
                var timeSpan = new TimeSpan(0, 0, value);
                _timer.Interval = timeSpan.TotalMilliseconds;
            }
        }

        /// <summary>
        /// 是否開始執行
        /// </summary>
        public bool IsRunning { get; private set; }

        #endregion

        #region Event

        #endregion

        public TaskManager()
        {
            // Initial
            InitialTimer();
        }

        #region Private Method

        /// <summary>
        /// 初始化 Timer
        /// </summary>
        private void InitialTimer()
        {
            // Create a timer with a five second interval.  (milliseconds)
            _timer = new Timer(5000);

            // Hook up the Elapsed event for the timer.
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent); ;
            _timer.Enabled = false;
        }

        /// <summary>
        /// Timer 觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (IsRunning == false) // 執行中就不要觸發
            {
                //TriggerRunningEvent();    //IsRunning = true;
                ////System.Threading.Thread.Sleep(5000);
                //CopyDirectory(SourcePath, TargetPath, true);
                //TriggerCompletedEvent();    //IsRunning = false; 

                IsRunning = true;
                Process();
                IsRunning = false;
            }
        }

        #endregion

        #region Protected Method

        /// <summary>
        /// 實際處理的方法
        /// </summary>
        protected abstract void Process();

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

            // 若是啟動, 需先執行一次動作
            //OnTimedEvent(this, null);
            var thread = new System.Threading.Thread(delegate ()
            {
                OnTimedEvent(this, null);
            });
            thread.Start();
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
        }

        #endregion
    }
}
