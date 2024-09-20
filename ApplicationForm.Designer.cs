namespace StopWatch
{
    partial class ApplicationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationForm));
            menu = new MenuStrip();
            timerMenuItem = new ToolStripMenuItem();
            statisticsMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            panel = new Panel();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { timerMenuItem, statisticsMenuItem, aboutMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(181, 24);
            menu.TabIndex = 0;
            menu.Text = "menu";
            // 
            // timerMenuItem
            // 
            timerMenuItem.Name = "timerMenuItem";
            timerMenuItem.Size = new Size(49, 20);
            timerMenuItem.Text = "Timer";
            timerMenuItem.Click += timerMenuItem_Click;
            // 
            // statisticsMenuItem
            // 
            statisticsMenuItem.Name = "statisticsMenuItem";
            statisticsMenuItem.Size = new Size(65, 20);
            statisticsMenuItem.Text = "Statistics";
            statisticsMenuItem.Click += statisticsMenuItem_Click;
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new Size(52, 20);
            aboutMenuItem.Text = "About";
            aboutMenuItem.Click += aboutMenuItem_Click;
            // 
            // panel
            // 
            panel.AutoSize = true;
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 24);
            panel.Name = "panel";
            panel.Size = new Size(181, 42);
            panel.TabIndex = 1;
            // 
            // ApplicationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(181, 66);
            Controls.Add(panel);
            Controls.Add(menu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menu;
            Name = "ApplicationForm";
            Text = "StopWatch";
            Load += ApplicationForm_Load;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem timerMenuItem;
        private ToolStripMenuItem statisticsMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private Panel panel;
    }
}
