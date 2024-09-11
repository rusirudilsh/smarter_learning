namespace Clean.Architecture.Application.Services.DateTimes
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;

        public DateTime Now => DateTime.Now;
    }
}
