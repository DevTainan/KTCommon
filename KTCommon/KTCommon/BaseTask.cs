using System;
using System.Collections.Generic;
using System.Text;

namespace KTCommon
{
    /// <summary>
    /// Task 執行者, 由 Task 管理者來安排
    /// </summary>
    public abstract class BaseTask
    {

        #region Event

        /// <summary>
        /// 訊息事件
        /// </summary>
        public EventHandler<MessageArgs> OnMessage;

        private void TriggerMessageEvent(string message, LogLevelType logLevel)
        {
            if (OnMessage != null)
            {
                var args = new MessageArgs()
                {
                    Message = message,
                    LogLevel = logLevel,
                };
                OnMessage(this, args);
            }
        }

        #endregion

        /// <summary>
        /// 開始
        /// </summary>
        /// <param name="obj"></param>
        public abstract void Start(object obj);

        /// <summary>
        /// 停止
        /// </summary>
        public abstract void Stop();
    }
}
