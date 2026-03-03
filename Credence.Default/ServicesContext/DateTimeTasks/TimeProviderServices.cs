
using Credence.Default.Abstractions;

namespace Credence.Default.ServicesContext.DateTimeTasks;

public class TimeProviderService : ITimeProviderServices
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    public TimeZoneInfo GetLocalTimeZone() => TimeZoneInfo.Local;
    public DateTimeOffset ConvertTime(DateTimeOffset now, TimeZoneInfo timeZone)
                                 => TimeZoneInfo.ConvertTime(now, timeZone);

    public TimeZoneInfo GetTimeZoneById(string timeZoneId)
    {
        try
        {
            //Linux Docker
            return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);//"America/Sao_Paulo"
        }
        catch (TimeZoneNotFoundException)
        {
            //Windows
            if (CrossPlatFormMap.TryGetValue(timeZoneId, out var windowsId))
                return TimeZoneInfo.FindSystemTimeZoneById(windowsId); //"E. South America Standard Time"
            throw;
        }
    }

    private static readonly Dictionary<string, string> CrossPlatFormMap = new()
    {
        ["America/Sao_Paulo"] = "E. South America Standard Time",
        // OTHERS
    };

}
