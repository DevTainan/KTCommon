using System;
using System.Collections.Generic;
using System.Text;

namespace KTCommon.Logger
{
    /// <summary>
    /// log 檔案寫入的介面
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 寫入 log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        void Log(string message, LogLevel level);

        /// <summary>
        /// 寫入 log
        /// </summary>
        /// <param name="timetag"></param>
        /// <param name="message"></param>
        /// <param name="level"></param>
        void Log(string timetag, string message, LogLevel level);
    }
}
