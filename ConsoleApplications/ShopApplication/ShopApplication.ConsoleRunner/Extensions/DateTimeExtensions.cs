namespace ShopApplication.ConsoleRunner.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToFormatString(this DateTime dateTime)
        {
            return dateTime.ToString("MM/dd HH:mm:ss");
        }
    }
}
