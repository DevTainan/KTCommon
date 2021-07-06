using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KTCommon.Core
{
    /// <summary>
    /// 檔案系統的通用方法
    /// </summary>
    public static class FileHelper
    {

        // https://stackoverflow.com/questions/2570930/check-if-a-file-directory-exists-is-there-a-better-way
        public static bool IsDirectoryOrFileExists(string path)
        {
            return (Directory.Exists(path) || File.Exists(path));
        }

        // https://stackoverflow.com/questions/1395205/better-way-to-check-if-a-path-is-a-file-or-a-directory
        public static bool IsDirectory(string path)
        {
            // get the file attributes for file or directory
            FileAttributes attr = File.GetAttributes(path);

            //detect whether its a directory or file
            return ((attr & FileAttributes.Directory) == FileAttributes.Directory);
        }
    }
}
