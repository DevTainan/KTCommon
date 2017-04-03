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
        public string Message { get; set; }
        public LogLevelType LogLevel { get; set; }
    }
}
