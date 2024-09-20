using StopWatch.Libraries;
using StopWatch.View.About;
using StopWatch.View.Statistics;
using StopWatch.View.Timer;

namespace StopWatch
{
    public partial class ApplicationForm : Form
    {
        public event Action? OnApplicationClosing;

        public bool AlwaysOnTop
        {
            get { return this.TopMost; }
            set
            {
                Properties.Settings.Default.AlwaysOnTop = value;
                Properties.Settings.Default.Save();
                this.TopMost = value;
            }
        }
        public bool MenuEnabled
        {
            get { return this.menu.Enabled; }
            set { this.menu.Enabled = value; }
        }

        public ApplicationForm()
        {
            this.TopMost = Properties.Settings.Default.AlwaysOnTop;
            InitializeComponent();
            panel.Enabled = true;
        }

        private void ApplicationForm_Load(object sender, EventArgs e)
        {
            NavigateTo(typeof(TimerView));
        }

        public void NavigateTo(Type name)
        {
            panel.Controls.Clear();
            panel.AutoSize = true;
            panel.Dock = DockStyle.Fill;
            UserControl view = (UserControl)Activator.CreateInstance(name, this);
            panel.Controls.Add(view);
        }

        private void timerMenuItem_Click(object sender, EventArgs e)
        {
            NavigateTo(typeof(TimerView));
        }

        private void statisticsMenuItem_Click(object sender, EventArgs e)
        {
            NavigateTo(typeof(StatisticsView));
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigateTo(typeof(AboutView));
        }
        private void ApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnApplicationClosing?.Invoke();
        }
    }
}
