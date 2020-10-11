using System;
using System.Collections.Generic;
using System.Text;

namespace KTCommon
{
    /// <summary>
    /// log 檔案寫入的介面
    /// </summary>
    public interface IFileLog
    {
        /// <summary>
        /// 寫入 log
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="errorCode"></param>
        void Log(string strMessage, LogLevelType errorCode);

        /// <summary>
        /// 寫入 log
        /// </summary>
        /// <param name="strTime"></param>
        /// <param name="strMessage"></param>
        /// <param name="errorCode"></param>
        void Log(string strTime, string strMessage, LogLevelType errorCode);
    }
}
