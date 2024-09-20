using System.Windows.Forms;

namespace StopWatch.View.Statistics
{
    partial class StatisticsView
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
            dateFromPicker = new DateTimePicker();
            dateToPicker = new DateTimePicker();
            exportTypesComboBox = new ComboBox();
            exportButton = new Button();
            SuspendLayout();
            // 
            // dateFromPicker
            // 
            dateFromPicker.Location = new Point(16, 16);
            dateFromPicker.Name = "dateFromPicker";
            dateFromPicker.Size = new Size(176, 23);
            dateFromPicker.TabIndex = 0;
            dateFromPicker.Format = DateTimePickerFormat.Custom;
            dateFromPicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateFromPicker.Value = DateTime.Today;
            // 
            // dateToPicker
            // 
            dateToPicker.Location = new Point(16, 48);
            dateToPicker.Name = "dateToPicker";
            dateToPicker.Size = new Size(176, 23);
            dateToPicker.TabIndex = 1;
            dateToPicker.Format = DateTimePickerFormat.Custom;
            dateToPicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            // 
            // exportTypesComboBox
            // 
            exportTypesComboBox.FormattingEnabled = true;
            exportTypesComboBox.Items.AddRange(new object[] { "csv" });
            exportTypesComboBox.Location = new Point(16, 80);
            exportTypesComboBox.Name = "exportTypesComboBox";
            exportTypesComboBox.Size = new Size(176, 23);
            exportTypesComboBox.TabIndex = 2;
            // 
            // exportButton
            // 
            exportButton.Location = new Point(200, 16);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(72, 88);
            exportButton.TabIndex = 3;
            exportButton.Text = "Export";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // StatisticsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(exportButton);
            Controls.Add(exportTypesComboBox);
            Controls.Add(dateToPicker);
            Controls.Add(dateFromPicker);
            Name = "StatisticsView";
            Size = new Size(292, 122);
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateFromPicker;
        private DateTimePicker dateToPicker;
        private ComboBox exportTypesComboBox;
        private Button exportButton;
    }
}
