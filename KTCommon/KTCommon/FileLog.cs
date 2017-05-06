using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KTCommon
{
    /// <summary>
    /// Log 元件
    /// </summary>
    /// <remarks>
    /// 修改 GEDMachine 的元件
    /// </remarks>
    public class FileLog : IFileLog
    {
        /*___________________________________________________________________________________*/
        /* Event */
        #region Event
        
        /// <summary>
        /// 寫 log 事件
        /// </summary>
        public EventHandler<LogArgs> OnLogging;

        /// <summary>
        /// log 參數
        /// </summary>
        public class LogArgs : EventArgs
        {
            /// <summary>
            /// 時間
            /// </summary>
            public string DateTime { get; set; }

            /// <summary>
            /// 訊息
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// log 等級
            /// </summary>
            public LogLevelType LogLevel { get; set; }
        }

        #endregion

        /*___________________________________________________________________________________*/
        /* Field */
        #region Field
        // 2017/03/29 Modify
        const string LOGVERSION = "2.0.0.2";
        #endregion

        /*___________________________________________________________________________________*/
        /* Members */
        #region Members

        /// <summary>
        /// 實際寫檔案的資料夾路徑
        /// </summary>
        protected string LogDirPath;

        /// <summary>
        /// 例外的錯誤紀錄
        /// </summary>
        protected string _ErrorMessage;

        #endregion

        /*___________________________________________________________________________________*/
        /* Properties */
        #region Properties

        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// 副檔名
        /// </summary>
        public string FileExtensionName { get; private set; }

        /// <summary>
        /// LOG 的根路徑
        /// </summary>
        public string FileRootPath { get; private set; }

        /// <summary>
        /// LOG的子路徑 \\GEDLog\\_SubDirectory
        /// </summary>
        public string SubDirectory { get; private set; }

        /// <summary>
        /// 排除的 log 紀錄等級 (數值越低, 紀錄越多)
        /// </summary>
        public LogLevelType LogLevel { get; set; }

        /// <summary>
        /// Log 檔案保留天數, 設定 0 表示不啟用刪除
        /// </summary>
        public int LogKeepDays { get; set; }

        #endregion


        /*___________________________________________________________________________________*/
        /* PublicMethods */
        #region PublicMethods

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="fileName">檔案名稱</param>
        /// <param name="fileExtensionName">副檔名</param>
        /// <param name="fileRootPath">根目錄的路徑</param>
        /// <param name="subDirName">子目錄的路徑</param>
        public FileLog(string fileName, string fileExtensionName, string fileRootPath, string subDirName)
        {
            FileName = fileName;                        // LOGFile
            FileExtensionName = fileExtensionName;      // .txt
            FileRootPath = fileRootPath;
            SubDirectory = subDirName;

            InitialObject();
        }

        private void InitialObject()
        {
            try
            {
                if (SubDirectory == "")
                {
                    LogDirPath = FileRootPath;
                }
                else
                {
                    LogDirPath = FileRootPath + "\\" + SubDirectory;
                }
                // 建立Log Directory
                if (Directory.Exists(LogDirPath) == false)
                {
                    Directory.CreateDirectory(LogDirPath);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 寫檔案
        /// </summary>
        public void Log(string strMessage, LogLevelType errorCode)
        {
            string strTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Log(strTime, strMessage, errorCode);
        }

        /// <summary>
        /// 寫檔案
        /// </summary>
        /// <param name="strTime"></param>
        /// <param name="strMessage"></param>
        /// <param name="errorCode"></param>
        /// <remarks>
        /// 呼叫此方法之前, 需要先呼叫 InitialObject 方法
        /// </remarks>
        public void Log(string strTime, string strMessage, LogLevelType errorCode)
        {
            // 低於 log 設定等級的不處理
            if (errorCode < LogLevel)
            {
                return;
            }

            // 宣告事件讓外部呼叫
            if (OnLogging != null)
            {
                var args = new LogArgs();
                args.DateTime = strTime;
                args.Message = strMessage;
                args.LogLevel = errorCode;

                OnLogging(this, args);
            }

            string strError;
            if (errorCode == LogLevelType.DebugLevel1)
            {
                strError = "[ DBGLVE1 ]";
            }
            else if (errorCode == LogLevelType.DebugLevel2)
            {
                strError = "[ DBGLVE2 ]";
            }
            else if (errorCode == LogLevelType.Information)
            {
                strError = "[  INFO.  ]";
            }
            else if (errorCode == LogLevelType.Warning)
            {
                strError = "[ WARNING ]";
            }
            else if (errorCode == LogLevelType.Alarm)
            {
                strError = "[  ALARM  ]";
            }
            else if (errorCode == LogLevelType.Error)
            {
                strError = "[  ERROR  ]";
            }
            else if (errorCode == LogLevelType.Exception)
            {
                strError = "[EXCEPTION]";
            }
            else
            {
                strError = "[  INFO.  ]";
            }

            string strText = string.Format("{0} {1} {2}\r\n", strTime, strError, strMessage);
            
            // 超過 14 天刪除檔案
            if (LogKeepDays > 0)
            {
                RemoveLogFiles(LogDirPath, FileName, FileExtensionName, LogKeepDays);
            }

            // 寫檔案
            string MessageFilePath = LogDirPath + "\\" + FileName + "_" + DateTime.Now.ToString("yyyyMMdd") + FileExtensionName;
            WriteFile(strText, MessageFilePath);
        }

        private void RemoveLogFiles(string logDirPath, string fileName, string fileExtensionName, int count)
        {
            DirectoryInfo targetDir = new DirectoryInfo(logDirPath);

            var fileInfoList = targetDir.GetFiles(FileName + "_*" + FileExtensionName, SearchOption.TopDirectoryOnly);
            Array.Sort<FileInfo>(fileInfoList, new NameDateEarlyFirst());
            var fileInfoCount = fileInfoList.Length;

            foreach (var fileInfo in fileInfoList)
            {
                if (fileInfoCount <= count)
                {
                    break;
                }

                fileInfo.Delete();
                fileInfoCount--;
            }
        }

        /// <summary>
        /// 實際寫檔案
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="MessageFilePath"></param>
        /// <remarks>
        /// todo: try catch 應該直接拋出例外, 讓外部處理
        /// </remarks>
        private void WriteFile(string strText, string MessageFilePath)
        {
            try
            {
                StreamWriter FileStreamLog = new StreamWriter(MessageFilePath, true);
                FileStreamLog.Write(strText);
                FileStreamLog.Flush();
                FileStreamLog.Close();
            }
            catch (Exception ex)
            {
                _ErrorMessage = ex.Message;
            }
        }

        #endregion
    }
}
