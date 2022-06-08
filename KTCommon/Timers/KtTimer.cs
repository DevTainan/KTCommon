using KTCommon.Interfaces;
using KTCommon.Structures;
using System;
using System.Timers;

namespace KTCommon.Timers
{
    internal class KtTimer : ITimer
    {
        private Timer _timer;
        private Action[] _actions;

        #region Property

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

        private readonly object _lockOfPassCount = new object();
        private int _passCount;

        /// <summary>
        /// Pass 的次數
        /// </summary>
        private int PassCount
        {
            get { return _passCount; }
            set
            {
                lock (_lockOfPassCount)
                {
                    _passCount = value;
                }
            }
        }

        #endregion

        #region Event

        public event EventHandler<ExceptionEventArgs> Error;

        public event EventHandler Starting;
        public event EventHandler Stopped;
        public event EventHandler<KtTimerPassEventArgs> Passing;

        #endregion

        public KtTimer(double interval = 500, params Action[] actions)
        {
            _actions = actions;

            // Create a timer with a five second interval.  (milliseconds)
            _timer = new Timer(interval);

            // Hook up the Elapsed event for the timer.
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _timer.Enabled = false;
        }

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
            Starting?.Invoke(this, EventArgs.Empty);

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

            // 停止時, 可覆寫的方法
            Stopped?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (IsRunning)  // 執行中就不要觸發
            {
                try
                {
                    Passing?.Invoke(this, new KtTimerPassEventArgs(PassCount++));
                }
                catch (Exception ex)
                {
                    Error?.Invoke(this, new ExceptionEventArgs(ex));
                }

                return;
            }

            try
            {
                IsRunning = true;
                PassCount = 0;

                foreach (var action in _actions)
                {
                    action?.Invoke();
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, new ExceptionEventArgs(ex));
            }
            finally
            {
                IsRunning = false;
            }
        }
    }
}
