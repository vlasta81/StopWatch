using StopWatch.Libraries;

namespace StopWatch.Entities
{
    public class ChangeLog
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public StopWatchTimerState Type { get; set; }
    }
}
