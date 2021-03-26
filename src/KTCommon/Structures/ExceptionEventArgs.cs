using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTCommon.Structures
{
    public class ExceptionEventArgs : EventArgs
    {
        public Exception Ex { get; private set; }

        public ExceptionEventArgs(Exception ex)
        {
            Ex = ex;
        }
    }
}
