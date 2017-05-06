using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace KTCommon
{
    internal class NameDateEarlyFirst : Comparer<FileInfo>
    {
        // Compares by Length, Height, and Width.
        public override int Compare(FileInfo x, FileInfo y)
        {
            DateTime firstFileTime = DateTime.MinValue;
            string fileNameWithoutExtension = x.Name.Replace(x.Extension, string.Empty);  // Log_20170412.txt
            string fileNameOnlyTimeSection = fileNameWithoutExtension.Remove(0, 4);
            bool IsParseSuccess = DateTime.TryParseExact(fileNameOnlyTimeSection, "yyyyMMdd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out firstFileTime);

            // 轉換錯誤
            if (IsParseSuccess == false)
            {
                return 0;
            }

            DateTime secondFileTime = DateTime.MinValue;
            fileNameWithoutExtension = y.Name.Replace(y.Extension, string.Empty);  // Log_20170412.txt
            fileNameOnlyTimeSection = fileNameWithoutExtension.Remove(0, 4);
            IsParseSuccess = DateTime.TryParseExact(fileNameOnlyTimeSection, "yyyyMMdd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out secondFileTime);

            // 轉換錯誤
            if (IsParseSuccess == false)
            {
                return 0;
            }

            return firstFileTime.CompareTo(secondFileTime);
        }
    }
}
