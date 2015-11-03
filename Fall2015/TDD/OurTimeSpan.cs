using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fall2015.TDD
{
    public class OurTimeSpan
    {
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }

        public Boolean Overlap(OurTimeSpan ourTimeSpan)
        {
            //return true if ourTimeSpan overlaps the timespan in this class
            if (ourTimeSpan.FromTime <= FromTime && ourTimeSpan.ToTime >= ToTime)
                return true;
            else if (ourTimeSpan.FromTime < ToTime && ourTimeSpan.ToTime >= ToTime)
                return true;
            else if (ourTimeSpan.FromTime < FromTime && ourTimeSpan.ToTime > FromTime)
                return true;
            else if(ourTimeSpan.FromTime > FromTime && ourTimeSpan.ToTime < ToTime)
                return true;
            else
            {
                return false;
            }
        }
    }
}