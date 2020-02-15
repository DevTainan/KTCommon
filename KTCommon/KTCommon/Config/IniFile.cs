using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace KTCommon
{
    /// <summary>
    /// Config 元件 for ini
    /// </summary>
    public class IniFile : IIniFIle
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
        private string strIniFile;

        /// <summary>
        /// 是否存在該檔案
        /// </summary>
        public bool IsExist
        {
            get { return File.Exists(strIniFile); }
        }
        #endregion

        /*________________________________________________________________________________*/
        /* PublicMethods */
        #region PublicMethods

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="strFile">檔案路徑</param>
        public IniFile(string strFile)
        {
            strIniFile = strFile;

            // 如果沒有該檔案, 就建立
            if (IsExist == false)
            {
                string dirPath = Path.GetDirectoryName(strIniFile);
                if (Directory.Exists(dirPath) == false)
                {
                    Directory.CreateDirectory(dirPath);
                }
                var file = File.Create(strFile);
                file.Close();
            }
        }

        /// <summary>
        /// 寫入
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public bool IniWriteValue(string Section, string Key, string Value)
        {
            return WritePrivateProfileString(Section, Key, Value, this.strIniFile);
        }

        /// <summary>
        /// 讀取
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            var temp = new StringBuilder(255);
            uint i = GetPrivateProfileString(Section, Key, "", temp,
                                             255, this.strIniFile);
            return temp.ToString();
        }

        /// <summary>
        /// 讀取數值, 若無設定則返回預設數值
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key, string defaultValue)
        {
            string configValue = IniReadValue(Section, Key);
            return string.IsNullOrEmpty(configValue) ? defaultValue : configValue;
        }
        #endregion
    }
}
