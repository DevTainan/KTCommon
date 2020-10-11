using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KTCommon
{
    /// <summary>
    /// 全域使用的靜態方法
    /// </summary>
    public static class SysUtils
    {
        /// <summary>
        /// 字串轉日期
        /// </summary>
        /// <param name="timeTxt"></param>
        /// <param name="format"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static bool TryParseTxtToDateTime(string timeTxt, string format, out DateTime time)
        {
            return DateTime.TryParseExact(timeTxt, format,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out time);
        }
    }
}
