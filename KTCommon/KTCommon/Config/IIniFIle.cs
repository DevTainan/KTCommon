using System;
using System.Collections.Generic;
using System.Text;

namespace KTCommon
{
    /// <summary>
    /// 設定檔的介面
    /// </summary>
    public interface IIniFIle
    {
        /// <summary>
        /// 寫入
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        bool IniWriteValue(string Section, string Key, string Value);

        /// <summary>
        /// 讀取
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        string IniReadValue(string Section, string Key);

        /// <summary>
        /// 讀取
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        string IniReadValue(string Section, string Key, string defaultValue);
    }
}
