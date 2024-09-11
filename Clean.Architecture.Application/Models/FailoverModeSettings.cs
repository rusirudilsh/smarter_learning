namespace Clean.Architecture.Application.Models
{
    public class FailoverModeSettings
    {
        public bool IsFailoverModeEnabled { get; set; }
        public int NumberOfFailedRequestsToCheck { get; set; }
        public int FrequencyToCheckInMinutes { get; set; }
    }
}
