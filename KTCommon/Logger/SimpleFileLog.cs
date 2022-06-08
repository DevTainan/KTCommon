using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KTCommon.Logger
{
    public class SimpleFileLog
    {
        public void Write(string content, string filePath)
        {
            using (var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.Write(content);
            }   // the streamwriter WILL be closed and flushed here, even if an exception is thrown.
        }
    }
}
