using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DurationSelector
    {
        private readonly LightDuration normalHours;
        private readonly LightDuration peakHours;
        public bool IsPeakHours { get; set; }
        public LightDuration Duration
        {
            get
            {
                return IsPeakHours ? peakHours ?? normalHours : normalHours;
            }
            private set { }
        }

        public DurationSelector(LightDuration normalHours, LightDuration peakHours)
        {
            this.normalHours = normalHours;
            this.peakHours = peakHours;
        }
    }
}
