using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace KTCommon.IO
{
    /// <summary>
    /// Config 元件 for ini
    /// </summary>
    public class IniFile : IIniFile
    {
        /*________________________________________________________________________________*/
        /* Extern Library Declare */
        #region ExternDeclare
        [DllImport("kernel32")]
        private static extern Boolean WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern UInt32 GetPrivateProfileString(string section,
                                                            string key,
                                                            string def,
                                                            StringBuilder retVal,
                                                            int size,
                                                            string filePath);
        #endregion

        /*________________________________________________________________________________*/
        /* Members */
        #region Members
        private readonly string _filePath;

        /// <summary>
        /// 是否存在該檔案
        /// </summary>
        public bool IsExist
        {
            get { return File.Exists(_filePath); }
        }
        #endregion

        /*________________________________________________________________________________*/
        /* PublicMethods */
        #region PublicMethods

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="filePath">檔案路徑</param>
        public IniFile(string filePath)
        {
            _filePath = filePath;

            // 如果沒有該檔案, 就建立
            if (IsExist == false)
            {
                string dirPath = Path.GetDirectoryName(_filePath);
                if (Directory.Exists(dirPath) == false)
                {
                    Directory.CreateDirectory(dirPath);
                }
                using (FileStream file = File.Create(filePath))
                {
                }
            }
        }

        /// <summary>
        /// 寫入
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Write(string section, string key, string value)
        {
            return WritePrivateProfileString(section, key, value, this._filePath);
        }

        /// <summary>
        /// 讀取
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Read(string section, string key)
        {
            var temp = new StringBuilder(255);
            uint i = GetPrivateProfileString(section, key, "", temp,
                                             255, this._filePath);
            return temp.ToString();
        }

        /// <summary>
        /// 讀取數值, 若無設定則返回預設數值
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string Read(string section, string key, string defaultValue)
        {
            string configValue = Read(section, key);
            return string.IsNullOrEmpty(configValue) ? defaultValue : configValue;
        }

        public T Read<T>(string section, string key, T defaultValue)
        {
            string value = Read(section, key);
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return ChangeType<T>(value);
        }
        #endregion


        /// <summary>
        /// 通用的轉換方法 (只包含 string 部分)
        /// </summary>
        /// <typeparam name="T">欲輸出的型態</typeparam>
        /// <param name="value">欲轉換的字串</param>
        /// <returns></returns>
        /// <remarks>
        /// 參考資料
        /// https://docs.microsoft.com/zh-tw/dotnet/api/system.convert.changetype?view=netframework-4.8
        /// https://www.cnblogs.com/youring2/archive/2012/07/26/2610035.html
        /// </remarks>
        private static T ChangeType<T>(string value)
        {
            var typeOfTarget = typeof(T);

            if (typeOfTarget.BaseType == typeof(Enum))
            {
                return (T)(Enum.Parse(typeOfTarget, value));
            }

            string str = value.ToString();
            if (str.Equals("True", StringComparison.OrdinalIgnoreCase) || str.Equals("False", StringComparison.OrdinalIgnoreCase))
            {
                bool result = Convert.ToBoolean(value);
                return (T)Convert.ChangeType(result, typeOfTarget);
            }

            double num = double.NaN;
            bool isSuccess = double.TryParse(str, out num);
            if (isSuccess)
            {
                return (T)Convert.ChangeType(num, typeOfTarget);
            }

            DateTime dt = DateTime.Parse(str, new System.Globalization.DateTimeFormatInfo(), System.Globalization.DateTimeStyles.None);
            //DateTime dt2 = Convert.ToDateTime(value);
            return (T)Convert.ChangeType(dt.Ticks, typeOfTarget);
        }
    }
}
