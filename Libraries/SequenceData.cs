
namespace StopWatch.Libraries
{
    public class SequenceData
    {
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public TimeSpan PauseTime { get; set; }
        public TimeSpan ActiveTime { get; set; }
    }
}
