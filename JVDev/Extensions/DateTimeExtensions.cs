namespace JVDev.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetTimeByTimeZone(this DateTime current, string timeZone = "Central Standard Time (Mexico)")
        {
            current = DateTime.UtcNow.ToTimeZoneTime(timeZone);
            return current;
        }

        public static DateTime ToTimeZoneTime(this DateTime time, string timeZoneId = "Central Standard Time")
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return time.ToTimeZoneTime(tzi);
        }

        public static DateTime ToTimeZoneTime(this DateTime time, TimeZoneInfo tzi)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(time, tzi);
        }
    }
}
