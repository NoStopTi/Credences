
namespace Credence.Default.ApiContext.Configurations;

public class ApiSettings
{
    public const string CorsPolicyName = "wasm";
    public const int DefaultStatusCode = 200;
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 25;

    public static string ConnectionString { get; private set; } = string.Empty;
    public static string DefaultKey { get; private set; } = "credenceConnection";
    public static string StripeApiKeyValue { get; private set; } = "StripeApiKey";
    public static string StripeApiKey { get; private set; } = string.Empty;
    public static string FrontEndUrl { get; private set; } = string.Empty;

    public static void SetConnectionString(string value)
    {
        ConnectionString = value;
    }
    public static void SetStripeApiKey(string value)
    {
        StripeApiKey = value;
    }
}