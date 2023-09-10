using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Timer
{
    public interface ITimer
    {
        event EventHandler Elapsed;
        bool IsRunning { get; }
        void Start(TimeSpan interval);
        void Stop();
    }
}