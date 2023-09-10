using System;
using TTimer = System.Timers.Timer;

namespace Infrastructure.Timer
{
    public class InMemoryTimer : ITimer
    {
        private TTimer _timer;

        public event EventHandler Elapsed;

        public bool IsRunning { get; private set; }

        public InMemoryTimer()
        {
            _timer = new TTimer();
            _timer.Elapsed += (sender, args) => OnElapsed();
        }

        public void Start(TimeSpan interval)
        {
            _timer.Interval = interval.TotalMilliseconds;
            _timer.Start();
            IsRunning = true;
        }

        public void Stop()
        {
            _timer.Stop();
        }

        protected virtual void OnElapsed()
        {
            Elapsed?.Invoke(this, EventArgs.Empty);
        }
    }
}