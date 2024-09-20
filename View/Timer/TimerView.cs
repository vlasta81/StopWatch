using StopWatch.Entities;
using StopWatch.Libraries;
using System;
using System.Windows.Forms;
using StopWatch.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
            _timer.Interval = 1000; // Aktualizace času každých 100 ms
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

            pausePlayButton.Enabled = false;
            pausePlayButton.Image = _pauseImage;
            playStopButton.Image = _playImage;
            elapsedTimeLabel.Text = " ";
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
                    //_timer = new System.Windows.Forms.Timer();
                    
                    //_timer.Interval = 1000;
                    //_timer.Tick += Timer_Tick;
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

            //if (_stopwatch.Start())
            //{
            //    playStopButton.Image = (Image)resources.GetObject("stop.Image");
            //    playStopButton.Enabled = false;
            //    _isStarted = true;
            //}
            //else
            //{
            //    playStopButton.Image = (Image)resources.GetObject("play.Image");
            //    playStopButton.Enabled = true;
            //    _isStarted = false;
            //}
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Aktualizace času v Labelu každých 100 ms
            //_stopwatch.GetElapsedTime(false);
            //TimeSpan ts = _stopwatch.GetElapsedTime(false);
            elapsedTimeLabel.Text = _stopwatch.GetElapsedTime(false).ToString(@"hh\:mm\:ss");
            //timeLabel.Text = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerView));
            if (_isStarted == false && _isPaused == false)
            {
                _stopwatch.Reset();
                //OnStopWatchTimer_Change(StopWatchTimerState.Start);
                _stopwatch.Start();
                _timer.Start();
                return;
            }
            if (_isStarted == true && _isPaused == false)
            {
                //OnStopWatchTimer_Change(StopWatchTimerState.Stop);
                _stopwatch.Stop();
                _timer.Stop();
                return;
            }

            //else
            //{
            //    _stopwatch.Stop();
            //}

            //if (_stopwatch.Start())
            //{
            //    playStopButton.Image = (Image)resources.GetObject("stop.Image");
            //    //playStopButton.Enabled = false;
            //    //_isStarted = true;
            //}
            //else
            //{
            //    playStopButton.Image = (Image)resources.GetObject("play.Image");
            //    //playStopButton.Enabled = true;
            //    _isStarted = false;
            //}
        }

        private void pausePlayButton_Click(object sender, EventArgs e)
        {
            if (_isStarted == true && _isPaused == false)
            {
                //OnStopWatchTimer_Change(StopWatchTimerState.Pause);
                _stopwatch.Pause();
                _timer.Stop();
                return;
            }
            if (_isStarted == true && _isPaused == true)
            {
                //OnStopWatchTimer_Change(StopWatchTimerState.Unpause);
                _stopwatch.Unpause();
                _timer.Start();
                return;
            }
            //if (!_isPaused)
            //{
            //    _stopwatch.Pause();
            //}
            //else
            //{
            //    _stopwatch.Unpause();
            //}
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerView));
            //if (_stopwatch.Pause())
            //{
            //    pausePlayButton.Image = (Image)resources.GetObject("pause.Image");
            //    //playStopButton.Enabled = false;
            //    ////pausePlayButton.Enabled = false;
            //    //_isPaused = true;
            //}
            //else
            //{
            //    pausePlayButton.Image = (Image)resources.GetObject("play.Image");
            //    //playStopButton.Enabled = true;
            //    ////pausePlayButton.Enabled = true;
            //    //_isPaused = false;
            //}
        }

        private void TimerView_Load(object sender, EventArgs e)
        {
            //pausePlayButton.Enabled = false;
            //pausePlayButton.Image = _pauseImage;
            //playStopButton.Image = _playImage;
            //elapsedTimeLabel.Text = " ";
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerView));
            //byte[] playData = (byte[])resources.GetObject("play.Image");
            //using (MemoryStream ms = new MemoryStream(playData))
            //{
            //    playStopButton.Image = Image.FromStream(ms);
            //}
            //byte[] pauseData = (byte[])resources.GetObject("pause.Image");
            //using (MemoryStream ms = new MemoryStream(pauseData))
            //{
            //    pausePlayButton.Image = Image.FromStream(ms);
            //}
            //byte[] stopData = (byte[])resources.GetObject("stop.Image"); // Obrázek vrácený jako byte[]
            //using (MemoryStream ms = new MemoryStream(stopData))
            //{
            //    pausePlayButton.Image = Image.FromStream(ms); // Převod byte[] na Image
            //}
        }

        private void alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _form.AlwaysOnTop = alwaysOnTopCheckBox.Checked;
            //alwaysOnTopCheckBox.Checked = !alwaysOnTopCheckBox.Checked;
        }
    }
}
