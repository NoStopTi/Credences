namespace Credence.Default.Abstractions;

public interface ITimeProviderServices
{
    public DateTimeOffset UtcNow { get; }
    public TimeZoneInfo GetLocalTimeZone();
    public DateTimeOffset ConvertTime(DateTimeOffset now, TimeZoneInfo timeZone);
    TimeZoneInfo GetTimeZoneById(string timeZoneId);
}
