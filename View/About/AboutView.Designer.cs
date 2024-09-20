namespace StopWatch.View.About
{
    partial class AboutView
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
            aboutLabel = new Label();
            githubLinkLabel = new LinkLabel();
            poweredByLabel = new Label();
            windowsFormsLinkLabel = new LinkLabel();
            sqliteLinkLabel = new LinkLabel();
            SuspendLayout();
            // 
            // aboutLabel
            // 
            aboutLabel.AutoSize = true;
            aboutLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            aboutLabel.Location = new Point(16, 16);
            aboutLabel.Name = "aboutLabel";
            aboutLabel.Size = new Size(109, 25);
            aboutLabel.TabIndex = 0;
            aboutLabel.Text = "StopWatch";
            // 
            // githubLinkLabel
            // 
            githubLinkLabel.AutoSize = true;
            githubLinkLabel.Location = new Point(128, 24);
            githubLinkLabel.Name = "githubLinkLabel";
            githubLinkLabel.Size = new Size(43, 15);
            githubLinkLabel.TabIndex = 1;
            githubLinkLabel.TabStop = true;
            githubLinkLabel.Text = "Github";
            // 
            // poweredByLabel
            // 
            poweredByLabel.AutoSize = true;
            poweredByLabel.Location = new Point(16, 64);
            poweredByLabel.Name = "poweredByLabel";
            poweredByLabel.Size = new Size(69, 15);
            poweredByLabel.TabIndex = 2;
            poweredByLabel.Text = "Powered by";
            // 
            // windowsFormsLinkLabel
            // 
            windowsFormsLinkLabel.AutoSize = true;
            windowsFormsLinkLabel.Location = new Point(88, 64);
            windowsFormsLinkLabel.Name = "windowsFormsLinkLabel";
            windowsFormsLinkLabel.Size = new Size(92, 15);
            windowsFormsLinkLabel.TabIndex = 3;
            windowsFormsLinkLabel.TabStop = true;
            windowsFormsLinkLabel.Text = "Windows Forms";
            // 
            // sqliteLinkLabel
            // 
            sqliteLinkLabel.AutoSize = true;
            sqliteLinkLabel.Location = new Point(88, 88);
            sqliteLinkLabel.Name = "sqliteLinkLabel";
            sqliteLinkLabel.Size = new Size(41, 15);
            sqliteLinkLabel.TabIndex = 4;
            sqliteLinkLabel.TabStop = true;
            sqliteLinkLabel.Text = "SQLite";
            // 
            // AboutView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sqliteLinkLabel);
            Controls.Add(windowsFormsLinkLabel);
            Controls.Add(poweredByLabel);
            Controls.Add(githubLinkLabel);
            Controls.Add(aboutLabel);
            Name = "AboutView";
            Size = new Size(292, 122);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label aboutLabel;
        private LinkLabel githubLinkLabel;
        private Label poweredByLabel;
        private LinkLabel windowsFormsLinkLabel;
        private LinkLabel sqliteLinkLabel;
    }
}
