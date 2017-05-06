using System;
using System.Collections.Generic;
using System.Text;

namespace KTCommon
{
    /// <summary>
    /// 常常使用的事件參數
    /// </summary>
    public class MessageArgs : EventArgs
    {
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// log 等級
        /// </summary>
        public LogLevelType LogLevel { get; set; }
    }
}
