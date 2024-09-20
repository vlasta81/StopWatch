using StopWatch.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch.Entities
{
    public class ChangeLog
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public StopWatchTimerState Type { get; set; }
    }
}
