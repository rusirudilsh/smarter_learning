namespace Clean.Architecture.Application.Services.DateTimes
{
    public interface IDateTimeService
    {
        DateTime UtcNow { get; }

        DateTime Now { get; }
    }
}
