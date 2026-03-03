

namespace Credence.Default.CommonContext;

public static class DateTimeOffsetExtensions
{
    public static TimeSpan? RemainingLockoutTime(this DateTimeOffset? lockoutEnd)
           => 
           lockoutEnd?.Subtract(DateTimeOffset.UtcNow);

    public static bool AreEquals(this DateTimeOffset? val, DateTimeOffset? comparer) 
            =>
            val == comparer;

}