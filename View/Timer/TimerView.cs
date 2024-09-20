using StopWatch.Entities;
using StopWatch.Libraries;

namespace StopWatch.View.Timer
{
    public partial class TimerView : UserControl
    {
        private ApplicationDbContext _db;
        private ApplicationForm _form;
        private StopWatchTimer _stopwatch;
        private bool _isStarted = false;
        private bool _isPaused = false;
        private Image? _playImage;
        private Image? _pauseImage;
        private Image? _stopImage;
        private System.Windows.Forms.Timer _timer;

        public TimerView(ApplicationForm form)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerView));
            _db = new ApplicationDbContext();
            _form = form;
            _stopwatch = new StopWatchTimer();
            _stopwatch.OnStateChange += OnStopWatchTimer_Change;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;

            byte[] playData = (byte[])resources.GetObject("play.Image");
            if (playData is not null)
            {
                using (MemoryStream ms1 = new MemoryStream(playData))
                {
                    _playImage = Image.FromStream(ms1);
                }
            }

            byte[] pauseData = (byte[])resources.GetObject("pause.Image");
            if (pauseData is not null)
            {
                using (MemoryStream ms2 = new MemoryStream(pauseData))
                {
                    _pauseImage = Image.FromStream(ms2);
                }
            }

            byte[] stopData = (byte[])resources.GetObject("stop.Image");
            if (stopData is not null)
            {
                using (MemoryStream ms3 = new MemoryStream(stopData))
                {
                    _stopImage = Image.FromStream(ms3);
                }
            }

            InitializeComponent();

            _form.OnApplicationClosing += OnApplicationClosing_Event;
            pausePlayButton.Enabled = false;
            pausePlayButton.Image = _pauseImage;
            playStopButton.Image = _playImage;
            elapsedTimeLabel.Text = " ";
        }

        private void OnApplicationClosing_Event()
        {
            if (_isPaused == true)
            {
                _stopwatch.Unpause();
                _timer.Start();
            }
            if (_isStarted == true)
            {
                _stopwatch.Stop();
                _timer.Stop();
            }
        }

        private void OnStopWatchTimer_Change(StopWatchTimerState name)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerView));
            ChangeLog changeLog = new ChangeLog()
            {
                Id = Guid.NewGuid(),
                TimeStamp = DateTime.Now,
                Type = name
            };
            _db.Add(changeLog);
            _db.SaveChanges();
            switch (name) 
            {
                case StopWatchTimerState.Start:
                    _form.MenuEnabled = false;
                    _isStarted = true;
                    _isPaused = false;
                    playStopButton.Enabled = true;
                    pausePlayButton.Enabled = true;
                    playStopButton.Image = _stopImage;
                    pausePlayButton.Image = _pauseImage;
                    startTimeLabel.Text = DateTime.Now.ToString();
                    stopTimeLabel.Text = " ";
                    _stopwatch.Start();
                    _timer.Start();
                    break;
                case StopWatchTimerState.Stop:
                    _isStarted = false;
                    _isPaused = false;
                    playStopButton.Enabled = true;
                    pausePlayButton.Enabled = false;
                    pausePlayButton.Image = _pauseImage;
                    playStopButton.Image = _playImage;
                    stopTimeLabel.Text = DateTime.Now.ToString();
                    _stopwatch.Stop();
                    _timer.Stop();
                    _stopwatch.Reset();
                    _form.MenuEnabled = true;
                    break;
                case StopWatchTimerState.Pause:
                    if (_isStarted)
                    {
                        _isPaused = true;
                        pausePlayButton.Image = _playImage;
                        playStopButton.Enabled = false;
                        pausePlayButton.Enabled = true;
                        playStopButton.Image = _stopImage;
                        pauseTimeLabel.Text = DateTime.Now.ToString();
                        _stopwatch.Pause();
                        _timer.Stop();
                    }
                    break;
                case StopWatchTimerState.Unpause:
                    if (_isStarted)
                    {
                        _isPaused = false;
                        pausePlayButton.Image = _pauseImage;
                        playStopButton.Enabled = true;
                        pausePlayButton.Enabled = true;
                        playStopButton.Image = _stopImage;
                        pauseTimeLabel.Text = " ";
                        _stopwatch.Unpause();
                        _timer.Start();
                    }
                    break;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTimeLabel.Text = _stopwatch.GetElapsedTime(false).ToString(@"hh\:mm\:ss");
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (_isStarted == false && _isPaused == false)
            {
                _stopwatch.Reset();
                _stopwatch.Start();
                _timer.Start();
                return;
            }
            if (_isStarted == true && _isPaused == false)
            {
                _stopwatch.Stop();
                _timer.Stop();
                return;
            }
        }

        private void pausePlayButton_Click(object sender, EventArgs e)
        {
            if (_isStarted == true && _isPaused == false)
            {
                _stopwatch.Pause();
                _timer.Stop();
                return;
            }
            if (_isStarted == true && _isPaused == true)
            {
                _stopwatch.Unpause();
                _timer.Start();
                return;
            }

        }

        private void TimerView_Load(object sender, EventArgs e)
        {
            
        }

        private void alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _form.AlwaysOnTop = alwaysOnTopCheckBox.Checked;
        }
    }
}
