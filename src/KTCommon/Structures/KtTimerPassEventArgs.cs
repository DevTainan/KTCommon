using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTCommon.Structures
{
    public class KtTimerPassEventArgs : EventArgs
    {
        public int Count { get; private set; }

        public KtTimerPassEventArgs(int count)
        {
            Count = count;
        }
    }
}
