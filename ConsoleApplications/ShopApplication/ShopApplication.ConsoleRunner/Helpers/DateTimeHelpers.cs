namespace ShopApplication.ConsoleRunner.Helpers
{
    public static class DateTimeHelpers
    {
        public static string FormatDateTime(DateTime dateTime)
        {
            return dateTime.ToString("MM/dd HH:mm:ss");
        }
    }
}
