using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    static class DateTimeUtil
    {
        public static DateTime ChangeTime(this DateTime dateTime, TimeSpan timespan)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                timespan.Hours,
                timespan.Minutes,
                timespan.Seconds,
                0,
                dateTime.Kind);
        }
    }
}
