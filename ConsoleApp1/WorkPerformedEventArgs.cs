using System;
using System.Collections.Generic;
using System.Text;

namespace InternalAssessment
{
    public class WorkPerformedEventArgs :System.EventArgs
    {
        public WorkPerformedEventArgs(int hours,WorkType work)
        {
            this.Hours = hours;
            this.Work = work;
        }
        public int Hours { get; set; }
        public WorkType Work { get; set; }
    }
}
