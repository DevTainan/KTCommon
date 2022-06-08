using KTCommon.Structures;
using System;

namespace KTCommon.Interfaces
{
    public interface ITimer
    {
        event EventHandler<ExceptionEventArgs> Error;
        event EventHandler Starting;
        event EventHandler Stopped;
        event EventHandler<KtTimerPassEventArgs> Passing;

        bool IsTimerEnabled { get; }
        bool IsRunning { get; }
        void Start();
        void Stop();
    }
}
