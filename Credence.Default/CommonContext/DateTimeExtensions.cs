

namespace Credence.Default.CommonContext;

public static class DateTimeExtensions
{
    public static bool IsLowerThan(this DateTime val, DateTime comparer) =>
     val >= comparer;

    public static bool AreEquals(this DateTime val, DateTime comparer) => 
    val == comparer;

}
