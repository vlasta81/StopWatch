using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch.View.About
{
    public partial class AboutView : UserControl
    {
        public AboutView(ApplicationForm form)
        {
            InitializeComponent();
        }

        private void githubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://github.com/vlasta81/StopWatch",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void windowsFormsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://learn.microsoft.com/en-us/dotnet/desktop/winforms/?view=netdesktop-8.0",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void sqliteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://www.sqlite.org/",
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }
}
