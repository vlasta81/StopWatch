using System.Diagnostics;

namespace StopWatch.Libraries
{
    public enum StopWatchTimerState
    {
        Start, Stop, Pause, Unpause
    }

    public class StopWatchTimer
    {
        private readonly Stopwatch _stopwatch;
        private TimeSpan _pausedTime;
        private bool _isPaused;
        private TimeSpan _totalPausedDuration;

        public event Action<StopWatchTimerState>? OnStateChange;

        public StopWatchTimer()
        {
            _stopwatch = new Stopwatch();
            _pausedTime = TimeSpan.Zero;
            _totalPausedDuration = TimeSpan.Zero;
            _isPaused = false;
        }

        public void Reset()
        {
            _stopwatch.Reset();
        }

        public bool Start()
        {
            if (!_stopwatch.IsRunning && !_isPaused)
            {
                _stopwatch.Start();
                OnStateChange?.Invoke(StopWatchTimerState.Start);
                return true;
            }
            return false;
        }

        public bool Pause()
        {
            if (_stopwatch.IsRunning && !_isPaused)
            {
                _stopwatch.Stop();
                _pausedTime = _stopwatch.Elapsed;
                _isPaused = true;
                OnStateChange?.Invoke(StopWatchTimerState.Pause);
                return true;
            }
            return false;
        }

        public bool Unpause()
        {
            if (_isPaused)
            {
                _totalPausedDuration += _stopwatch.Elapsed - _pausedTime;
                _stopwatch.Start();
                _isPaused = false;
                OnStateChange?.Invoke(StopWatchTimerState.Unpause);
                return true;
            }
            return false;
        }

        public bool Stop()
        {
            if (_stopwatch.IsRunning || _isPaused)
            {
                if (_isPaused)
                {
                    _totalPausedDuration += _stopwatch.Elapsed - _pausedTime;
                }

                _stopwatch.Stop();
                OnStateChange?.Invoke(StopWatchTimerState.Stop);
                return true;
            }
            return false;
        }

        public TimeSpan GetElapsedTime(bool withPause = false)
        {
            if (_isPaused)
            {
                if (withPause)
                {
                    return _pausedTime;
                }
                else
                {
                    return _pausedTime - _totalPausedDuration;
                }
            }
            else
            {
                if (withPause)
                {
                    return _stopwatch.Elapsed;
                }
                else
                {
                    return _stopwatch.Elapsed - _totalPausedDuration;
                }
            }
        }
    }

}
