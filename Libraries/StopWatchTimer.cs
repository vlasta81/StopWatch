using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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

        //public TimeSpan Elapsed 
        //{ 
        //    get
        //    {
        //        return GetElapsedTime(false);
        //        //return _stopwatch.Elapsed;
        //    }
        //}

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

        // Start stopwatch
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

        // Pause stopwatch
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

        // Unpause stopwatch
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

        // Stop stopwatch
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

        // Get elapsed time (with or without paused duration)
        public TimeSpan GetElapsedTime(bool withPause = false)
        {
            if (_isPaused)
            {
                // If paused, calculate current total elapsed time till pause
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
                // If running, calculate total elapsed time
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
