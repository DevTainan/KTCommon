using System;
using System.Collections.Generic;
using System.Text;

namespace KTCommon
{
    /// <summary>
    /// 負責每秒回報給 UI 訊息
    /// </summary>
    public class UiTaskManager : TaskManager
    {
        #region Member

        private int _interval = 0;

        #endregion

        #region Property

        /// <summary>
        /// 循環秒數
        /// </summary>
        public int IntervalSeconds { get; private set; }

        #endregion

        #region Event

        /// <summary>
        /// 訊息事件
        /// </summary>
        public EventHandler<MessageArgs> OnMessage;

        /// <summary>
        /// 觸發 OnMessage 訊息事件
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logLevel"></param>
        private void TriggerMessageEvent(string message, LogLevelType logLevel)
        {
            if (OnMessage != null)
            {
                MessageArgs args = new MessageArgs();
                //args.Timetag = DateTime.Now;
                args.Message = message;
                args.LogLevel = logLevel;

                OnMessage(this, args);
            }
        }

        #endregion

        public UiTaskManager(int intervalSeconds) : base()
        {
            IntervalSecondsOfPolling = 1;   // 預設 1 秒回報

            SetIntervalSeconds(intervalSeconds);
        }

        /// <summary>
        /// 設定間格秒數
        /// </summary>
        /// <param name="intervalSeconds"></param>
        public void SetIntervalSeconds(int intervalSeconds)
        {
            _interval = intervalSeconds;
            IntervalSeconds = intervalSeconds;
        }

        /// <summary>
        /// 實際處理
        /// </summary>
        protected override void Process()
        {
            if (IntervalSeconds < 0)
            {
                Reset();
            }

            TriggerMessageEvent(IntervalSeconds.ToString(), LogLevelType.Information);
            IntervalSeconds--;
        }

        /// <summary>
        /// 終止後重設數值
        /// </summary>
        protected override void Stopped()
        {
            Reset();
        }

        /// <summary>
        /// 重新校時
        /// </summary>
        /// <remarks>
        /// 開放給外部校時
        /// </remarks>
        public void Reset()
        {
            IntervalSeconds = _interval;
        }
    }
}
