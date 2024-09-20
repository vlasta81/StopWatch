using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
