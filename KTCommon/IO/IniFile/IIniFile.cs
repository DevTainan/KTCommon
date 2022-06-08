using System;
using System.Collections.Generic;
using System.Text;

namespace KTCommon.IO
{
    /// <summary>
    /// 設定檔的介面
    /// </summary>
    public interface IIniFile
    {
        /// <summary>
        /// 寫入
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Write(string section, string key, string value);

        /// <summary>
        /// 讀取
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string Read(string section, string key);

        /// <summary>
        /// 讀取
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        string Read(string section, string key, string defaultValue);
    }
}
