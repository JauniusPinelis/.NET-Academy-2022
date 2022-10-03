namespace FirstWebApi.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetNowUtc()
        {
            return DateTime.UtcNow;
        }
    }
}
