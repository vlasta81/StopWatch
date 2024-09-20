using StopWatch.Properties;
using System.Resources;

namespace StopWatch.View.Timer
{
    partial class TimerView
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            playStopButton = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            startTimeLabel = new Label();
            stopTimeLabel = new Label();
            alwaysOnTopCheckBox = new CheckBox();
            pausePlayButton = new Button();
            pauseTimeLabel = new Label();
            elapsedTimeLabel = new Label();
            SuspendLayout();
            // 
            // playStopButton
            // 
            playStopButton.Location = new Point(16, 16);
            playStopButton.Name = "playStopButton";
            playStopButton.Size = new Size(64, 64);
            playStopButton.TabIndex = 0;
            playStopButton.UseVisualStyleBackColor = true;
            playStopButton.Click += startStopButton_Click;
            // 
            // startTimeLabel
            // 
            startTimeLabel.AutoSize = true;
            startTimeLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            startTimeLabel.ForeColor = Color.FromArgb(0, 192, 0);
            startTimeLabel.Location = new Point(160, 16);
            startTimeLabel.Name = "startTimeLabel";
            startTimeLabel.Size = new Size(12, 17);
            startTimeLabel.TabIndex = 2;
            startTimeLabel.Text = " ";
            // 
            // stopTimeLabel
            // 
            stopTimeLabel.AutoSize = true;
            stopTimeLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            stopTimeLabel.ForeColor = Color.Red;
            stopTimeLabel.Location = new Point(160, 64);
            stopTimeLabel.Name = "stopTimeLabel";
            stopTimeLabel.Size = new Size(12, 17);
            stopTimeLabel.TabIndex = 3;
            stopTimeLabel.Text = " ";
            // 
            // alwaysOnTopCheckBox
            // 
            alwaysOnTopCheckBox.AutoSize = true;
            alwaysOnTopCheckBox.Location = new Point(16, 88);
            alwaysOnTopCheckBox.Name = "alwaysOnTopCheckBox";
            alwaysOnTopCheckBox.Size = new Size(101, 19);
            alwaysOnTopCheckBox.TabIndex = 4;
            alwaysOnTopCheckBox.Text = "Always on top";
            alwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            alwaysOnTopCheckBox.CheckedChanged += alwaysOnTopCheckBox_CheckedChanged;
            // 
            // pausePlayButton
            // 
            pausePlayButton.Location = new Point(88, 16);
            pausePlayButton.Name = "pausePlayButton";
            pausePlayButton.Size = new Size(64, 64);
            pausePlayButton.TabIndex = 5;
            pausePlayButton.UseVisualStyleBackColor = true;
            pausePlayButton.Click += pausePlayButton_Click;
            // 
            // pauseTimeLabel
            // 
            pauseTimeLabel.AutoSize = true;
            pauseTimeLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            pauseTimeLabel.ForeColor = Color.FromArgb(255, 128, 0);
            pauseTimeLabel.Location = new Point(160, 40);
            pauseTimeLabel.Name = "pauseTimeLabel";
            pauseTimeLabel.Size = new Size(12, 17);
            pauseTimeLabel.TabIndex = 6;
            pauseTimeLabel.Text = " ";
            // 
            // elapsedTimeLabel
            // 
            elapsedTimeLabel.AutoSize = true;
            elapsedTimeLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            elapsedTimeLabel.Location = new Point(160, 88);
            elapsedTimeLabel.Name = "elapsedTimeLabel";
            elapsedTimeLabel.Size = new Size(12, 17);
            elapsedTimeLabel.TabIndex = 7;
            elapsedTimeLabel.Text = " ";
            // 
            // TimerView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(elapsedTimeLabel);
            Controls.Add(pauseTimeLabel);
            Controls.Add(pausePlayButton);
            Controls.Add(alwaysOnTopCheckBox);
            Controls.Add(stopTimeLabel);
            Controls.Add(startTimeLabel);
            Controls.Add(playStopButton);
            Name = "TimerView";
            Size = new Size(292, 122);
            Load += TimerView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button playStopButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label startTimeLabel;
        private Label stopTimeLabel;
        private CheckBox alwaysOnTopCheckBox;
        private Button pausePlayButton;
        private Label pauseTimeLabel;
        private Label elapsedTimeLabel;
    }
}
