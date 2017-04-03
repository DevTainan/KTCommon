using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KTCommon
{
    public abstract class BaseCsvReader
    {
        public string FilePath { get; private set; }

        public BaseCsvReader(string filePath)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// 為指定的檔名初始化 System.IO.StreamReader 類別的新執行個體。
        /// </summary>
        /// <exception cref="System.ArgumentException">path為空字串 ("")。</exception>
        /// <exception cref="System.ArgumentNullException">path 為 null。</exception>
        /// <exception cref="System.IO.FileNotFoundException">找不到檔案。</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">指定的路徑無效，例如位在未對應的磁碟上。</exception>
        /// <exception cref="System.IO.IOException">path 包含檔案名稱、目錄名稱或磁碟標籤的不正確或無效語法。</exception>
        public void Read()
        {
            try
            {
                using (var stream = new StreamReader(FilePath))
                {
                    string txtLine;
                    while ((txtLine = stream.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(txtLine))
                        {
                            continue;
                        }

                        string[] txtLineArray = txtLine.Split(',');

                        // 以下自行發揮
                        ProcessLine(txtLineArray);
                        if (IsBreak(txtLineArray))
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected abstract bool IsBreak(string[] txtLineArray);

        protected abstract void ProcessLine(string[] txtLineArray);
    }
}
