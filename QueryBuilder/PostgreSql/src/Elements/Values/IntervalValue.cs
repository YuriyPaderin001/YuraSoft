using System;
using System.Text;

using YuraSoft.QueryBuilder.Common;

namespace YuraSoft.QueryBuilder.PostgreSql
{
    public class IntervalValue : Value
    {
        public IntervalValue(int years = 0, int months = 0, int days = 0, int hours = 0, int minutes = 0, int seconds = 0, int milliseconds = 0)
        {
            if (years == 0 && months == 0 && days == 0 && hours == 0 && minutes == 0 && seconds == 0 && milliseconds == 0)
            {
                throw new InvalidOperationException("All parameters can't be null");
            }

            Years = years;
            Months = months;
            Days = days;
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Milliseconds = milliseconds;
        }

        public readonly int Years;
        public readonly int Months;
        public readonly int Days;
        public readonly int Hours;
        public readonly int Minutes;
        public readonly int Seconds;
        public readonly int Milliseconds;

        public override void RenderValue(IRenderer renderer, StringBuilder sql) =>
            renderer.RenderValue(this, sql);
    }
}
