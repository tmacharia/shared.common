using System;
using System.Text;
using Common.Properties;

namespace Common.Structs
{
    /// <summary>
    /// Represents extension methods on <see cref="DateTime"/> instances.
    /// </summary>
    public static class DateTimeExts
    {
        public static string ShortDayFormat = "ddd";
        public static string TimeFormat = "h:mm tt";
        public static string DateFormat = "MMM. d, yyyy";
        public static string DayMonthFormat = "dd/MM";

        /// <summary>
        /// Total number of seconds in One Second.
        /// </summary>
        public const double OneSec = 1;
        /// <summary>
        /// Total number of seconds in One Minute.
        /// </summary>
        public const double OneMin = OneSec * 60;
        /// <summary>
        /// Total number of seconds in One Hour.
        /// </summary>
        public const double OneHr = OneMin * 60;
        /// <summary>
        /// Total number of seconds in One Day.
        /// </summary>
        public const double OneDay = OneHr * 24;
        /// <summary>
        /// Total number of seconds in One Week.
        /// </summary>
        public const double OneWeek = OneDay * 7;
        /// <summary>
        /// Total number of seconds in One Month.
        /// </summary>
        public const double OneMonth = OneDay * 30;
        /// <summary>
        /// Total number of seconds in One Year.
        /// </summary>
        public const double OneYear = OneMonth * 12;


        /// <summary>
        /// Returns a human readable and comprehensible time format to know the exact
        /// relative time in the past.
        /// </summary>
        /// <param name="pastDate">This DateTime instance that should represent a time in the past</param>
        /// <param name="currentTime">Current datetime instance to compare to. If not specified
        /// <see cref="DateTime.Now"/> will be used by default.
        /// </param>
        /// <returns>Human readable time</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToMoment(this DateTime pastDate, DateTime? currentTime = null)
        {
            if (pastDate == null)
                throw new ArgumentNullException(nameof(pastDate));

            TimeSpan ts;
            bool is_past;

            // check if datetime is in the past or the future
            if (currentTime.HasValue)
            {
                is_past = pastDate < currentTime;
                ts = is_past ? currentTime.Value.Subtract(pastDate) : pastDate.Subtract(currentTime.Value);
            }
            else
            {
                is_past = pastDate < DateTime.Now;
                ts = is_past ? DateTime.Now.Subtract(pastDate) : pastDate.Subtract(DateTime.Now);
            }

            return ts.ToMoment(is_past);
        }
        /// <summary>
        /// Converts a <see cref="TimeSpan"/> to human-readable format.
        /// </summary>
        /// <param name="span">Timespan instance.</param>
        /// <returns>Moment time.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToMoment(this TimeSpan span) => span.ToMoment(true);
        /// <summary>
        /// Converts a <see cref="TimeSpan"/> to human-readable format.
        /// </summary>
        /// <param name="span">Timespan instance.</param>
        /// <param name="isInThePast"></param>
        /// <returns>Moment time.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToMoment(this TimeSpan span, bool isInThePast=true)
        {
            if (span == null)
                throw new ArgumentNullException(nameof(span));

            double delta = span.TotalSeconds;
            // Seconds
            if (delta == 0 || (delta > 0 && delta < OneSec)) return Resources.JustNow;
            if (delta == OneSec) return isInThePast ? Resources.OneSecAgo : Resources.InOneSec;
            if (delta < OneMin) return isInThePast ? $"{span.Seconds} {Resources.SecsAgo}" : $"{Resources.In} {span.Seconds} {Resources.Secs}";

            // Minutes
            if (delta > OneMin && delta < OneMin * 2) return isInThePast ? Resources.OneMinAgo : Resources.InOneMin;
            if (delta > OneMin && delta < OneHr) return isInThePast ? $"{span.Minutes} {Resources.MinsAgo}" : $"{Resources.In} {span.Minutes} {Resources.Mins}";

            // Hours
            if (delta > OneHr && delta < OneHr * 2) return isInThePast ? Resources.OneHrAgo : Resources.InOneHr;
            if (delta > OneHr && delta < OneDay) return isInThePast ? $"{span.Hours} {Resources.HoursAgo}" : $"{Resources.In} {span.Hours} {Resources.Hours}";

            // Days
            int days = span.Days;
            if (days == 1) return isInThePast ? Resources.Yesterday : Resources.Tomorrow;
            if (delta > OneDay && delta < OneMonth) return isInThePast ? $"{days} {Resources.DaysAgo}" : $"{Resources.In} {days} {Resources.Days}";

            // Months
            if (delta == OneMonth || (delta > OneMonth && delta < OneMonth * 2)) return isInThePast ? Resources.OneMonthAgo : Resources.InOneMonth;
            int months = (int)(delta / OneMonth);
            if (delta > OneMonth && delta < OneYear) return isInThePast ? $"{months} {Resources.MonthsAgo}" : $"{Resources.In} {months} {Resources.Months}";

            int yrs = (int)(delta / OneYear);
            if (yrs == 1) return isInThePast ? Resources.OneYearAgo : Resources.InOneYear;
            return isInThePast ? $"{yrs} {Resources.YearsAgo}" : $"{Resources.In} {yrs} {Resources.Years}";
        }
        public static string ToDateTimeMoment(this DateTimeOffset dt)
        {
            var span = DateTimeOffset.Now.Subtract(dt);
            if (dt.Year != DateTimeOffset.Now.Year)
            {
                return dt.ToString(DateFormat);
            }
            else if (span.TotalDays >= 7)
            {
                return $"{dt.ToString(ShortDayFormat)} {dt.ToString(DayMonthFormat)}";
            }
            else if (span.TotalDays > 2)
            {
                return $"{dt.ToString(ShortDayFormat)} {dt.ToString(TimeFormat)}";
            }
            else if (span.TotalDays >= 1 && span.TotalDays <= 2)
            {
                return $"{Resources.Yesterday.Capitalize()}, {dt.ToString(TimeFormat)}";
            }
            else
            {
                if (span.TotalHours < 12)
                {
                    return span.ToMoment();
                }

                return $"{Resources.Today.Capitalize()}, {dt.ToString(TimeFormat)}";
            }
        }
        public static string ToDateTimeMoment(this DateTime dt)
        {
            var span = DateTime.Now.Subtract(dt);
            if (dt.Year != DateTime.Now.Year)
            {
                return dt.ToString(DateFormat);
            }
            else if (span.TotalDays >= 7)
            {
                return $"{dt.ToString(ShortDayFormat)} {dt.ToString(DayMonthFormat)}";
            }
            else if (span.TotalDays > 2)
            {
                return $"{dt.ToString(ShortDayFormat)} {dt.ToString(TimeFormat)}";
            }
            else if (span.TotalDays >= 1 && span.TotalDays <= 2)
            {
                return $"{Resources.Yesterday.Capitalize()}, {dt.ToString(TimeFormat)}";
            }
            else
            {
                if (span.TotalHours < 12)
                {
                    return span.ToMoment();
                }

                return $"{Resources.Today.Capitalize()}, {dt.ToString(TimeFormat)}";
            }
        }
        public static string FormatTimespan(this TimeSpan span, bool padFirst = false, bool padSecond = true)
        {
            StringBuilder sb = new StringBuilder();
            if (span.Hours > 0)
            {
                sb.Append(span.Hours.PadInt(padFirst));
                sb.Append(":" + span.Minutes.PadInt(padSecond));
                sb.Append(":" + span.Seconds.PadInt(padSecond));
            }
            else
            {
                sb.Append(span.Minutes.PadInt(padFirst));
                sb.Append(":" + span.Seconds.PadInt(padSecond));
            }
            return sb.ToString();
        }
        public static string TimespanMoment(this TimeSpan span)
        {
            StringBuilder sb = new StringBuilder();
            if (span.Hours > 0)
            {
                sb.Append(span.Hours);
                sb.Append(" ");
                sb.Append(span.Hours == 1 ? Resources.Hour : Resources.Hours);
                sb.Append(" ");
                sb.Append(span.Minutes);
                sb.Append(" ");
                sb.Append(span.Minutes == 1 ? Resources.Min : Resources.Mins);
            }
            else if (span.Minutes > 0)
            {
                sb.Append(span.Minutes);
                sb.Append(" ");
                sb.Append(span.Minutes == 1 ? Resources.Min : Resources.Mins);
                sb.Append(" ");
                sb.Append(span.Seconds);
                sb.Append(" ");
                sb.Append(span.Seconds == 1 ? Resources.Sec : Resources.Secs);
            }
            else if (span.Seconds > 0)
            {
                sb.Append(span.Seconds);
                sb.Append(" ");
                sb.Append(span.Seconds == 1 ? Resources.Sec : Resources.Secs);
            }
            return sb.ToString();
        }
    }
}