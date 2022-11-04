namespace Revision.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDefaultDateTimeString(this DateTime dateTime)
        {
            return dateTime.Date.ToLongDateString();
        }
    }
}
