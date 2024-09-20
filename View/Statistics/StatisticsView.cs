using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using StopWatch.Entities;
using StopWatch.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using StopWatch.Libraries;
using System.Diagnostics;

namespace StopWatch.View.Statistics
{
    public partial class StatisticsView : UserControl
    {
        private ApplicationForm _form;
        private ApplicationDbContext _db;
        private static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;

        public StatisticsView(ApplicationForm form)
        {
            _form = form;
            _db = new ApplicationDbContext();
            InitializeComponent();
        }

        public void ExportToCsv(DateTime startDate, DateTime endDate)
        {
            try
            {
                endDate = endDate.Date.AddDays(1).AddTicks(-1);
                _db.Database.OpenConnection();
                DateTime minDate = _db.ChangeLogs.Min(cl => cl.TimeStamp);
                DateTime maxDate = _db.ChangeLogs.Max(cl => cl.TimeStamp);
                var logsQuery = _db.ChangeLogs
                    .Where(cl => cl.TimeStamp >= startDate.Date && cl.TimeStamp <= endDate)
                    .OrderBy(cl => cl.TimeStamp);
                List<ChangeLog>? logs = logsQuery.ToList();
                if (logs.Count == 0)
                {
                    MessageBox.Show("No data found for the specified date range.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.FileName = "StopWatch_export.csv";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            writer.WriteLine("StartTime,StopTime,PauseTime,ActiveTime");
                            TimeSpan totalActiveTime = TimeSpan.Zero;
                            List<SequenceData> sequences = ProcessLogs(logs);
                            foreach (SequenceData sequence in sequences)
                            {
                                writer.WriteLine($"{FormatDateTime(sequence.StartTime)}," +
                                                 $"{FormatDateTime(sequence.StopTime)}," +
                                                 $"{FormatTimeSpan(sequence.PauseTime)}," +
                                                 $"{FormatTimeSpan(sequence.ActiveTime)}");

                                totalActiveTime += sequence.ActiveTime;
                            }

                            writer.WriteLine($"Total Active Time:,,," + $"{FormatTimeSpan(totalActiveTime)}");
                        }
                        MessageBox.Show("Export completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during export: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _db.Database.CloseConnection();
            }
        }

        private List<SequenceData> ProcessLogs(List<ChangeLog> logs)
        {
            List<SequenceData> sequences = new List<SequenceData>();
            List<ChangeLog> currentSequence = null;
            foreach (ChangeLog log in logs)
            {
                if (log.Type == StopWatchTimerState.Start)
                {
                    if (currentSequence != null)
                    {
                        sequences.Add(ProcessSequence(currentSequence));
                    }
                    currentSequence = new List<ChangeLog> { log };
                }
                else if (currentSequence != null)
                {
                    currentSequence.Add(log);
                    if (log.Type == StopWatchTimerState.Stop)
                    {
                        sequences.Add(ProcessSequence(currentSequence));
                        currentSequence = null;
                    }
                }
            }
            if (currentSequence != null && currentSequence.Any(l => l.Type == StopWatchTimerState.Stop))
            {
                sequences.Add(ProcessSequence(currentSequence));
            }

            return sequences;
        }

        private SequenceData ProcessSequence(List<ChangeLog> sequence)
        {
            ChangeLog start = sequence.First(l => l.Type == StopWatchTimerState.Start);
            ChangeLog stop = sequence.Last(l => l.Type == StopWatchTimerState.Stop);

            TimeSpan pauseTime = CalculatePauseTime(sequence);
            TimeSpan activeTime = (stop.TimeStamp - start.TimeStamp) - pauseTime;

            return new SequenceData
            {
                StartTime = start.TimeStamp,
                StopTime = stop.TimeStamp,
                PauseTime = pauseTime,
                ActiveTime = activeTime
            };
        }

        private TimeSpan CalculatePauseTime(List<ChangeLog> sequence)
        {
            TimeSpan pauseTime = TimeSpan.Zero;
            DateTime? lastPauseTime = null;

            foreach (ChangeLog log in sequence)
            {
                if (log.Type == StopWatchTimerState.Pause)
                {
                    lastPauseTime = log.TimeStamp;
                }
                else if (log.Type == StopWatchTimerState.Unpause && lastPauseTime.HasValue)
                {
                    pauseTime += log.TimeStamp - lastPauseTime.Value;
                    lastPauseTime = null;
                }
            }

            return pauseTime;
        }

        private string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss.ffffff", InvariantCulture);
        }

        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            return timeSpan.ToString(@"hh\:mm\:ss\.ffffff", InvariantCulture);
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateFromPicker.Value.Date;
            DateTime toDate = dateToPicker.Value.Date;
            string? format = exportTypesComboBox.Text;

            if (format is not null)
            {
                switch(format)
                {
                    case "csv":
                        ExportToCsv(fromDate, toDate);
                        break;
                }
            }

        }

    }
}
