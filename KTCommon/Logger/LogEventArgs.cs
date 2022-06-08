using System;
using System.Collections.Generic;
using System.Text;

namespace KTCommon.Logger
{
    /// <summary>
    /// log 事件參數
    /// </summary>
    public class LogEventArgs : EventArgs
    {
        /// <summary>
        /// 時間
        /// </summary>
        public string Timetag { get; set; }

        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// log 等級
        /// </summary>
        public LogLevel LogLevel { get; set; }

        public LogEventArgs(string timetag, string message, LogLevel logLevel)
        {
            Timetag = timetag;
            Message = message;
            LogLevel = logLevel;
        }
    }
}
