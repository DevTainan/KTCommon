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

        public abstract void Start(object obj);
        public abstract void Stop();
    }
}
