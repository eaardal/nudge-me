using System;

namespace NudgeMe.WinForms
{
    public sealed class TimeConverters
    {
        public static int FromMinutesToMilliseconds(int interval)
        {
            return interval * 60 * 1000;
        }

        public static int FromDaysToMilliseconds(int days)
        {
            return days * 24 * 60 * 60 * 1000;
        }

        public static int FromHoursToMilliseconds(int hrs)
        {
            return hrs*60*60*1000;
        }

        public static int FromSecondsToMilliseconds(int seconds)
        {
            return seconds * 1000;
        }

        public static int GetMillisecondsForIntervalUnit(IntervalUnit unit, int value)
        {
            switch (unit)
            {
                case IntervalUnit.Day:
                    return FromDaysToMilliseconds(value);
                case IntervalUnit.Hr:
                    return FromHoursToMilliseconds(value);
                case IntervalUnit.Min:
                    return FromMinutesToMilliseconds(value);
                case IntervalUnit.Sec:
                    return FromSecondsToMilliseconds(value);
            }
            throw new InvalidOperationException($"Could not parse {value}{unit} to milliseconds");
        }
    }
}