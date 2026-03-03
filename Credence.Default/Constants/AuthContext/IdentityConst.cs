namespace Credence.Default.DomainContext.Entities.Constants.AuthContext;

public record IdentityConst
{

    #region CONFIGURATION DATA
    public const string TwoFactorWithAppTokenProvider = "Authenticator";
    public const string TwoFactorWithEmailTokenProvider = "Email";
    public const bool RequireConfirmedEmail = true;
    public const bool RequireConfirmedAccount = true;
    public const bool RequireUniqueEmail = true;
    public const bool RequireDigit = false;
    public const bool RequireNonAlphanumeric = false;
    public const bool RequireLowercase = false;
    public const bool RequireUppercase = false;
    public const int RequiredLength = 3;
    public const bool AllowedForNewUsers = true;
    public static TimeSpan DefaultLockoutTimeSpan(int minutes) => TimeSpan.FromMinutes(minutes);
    public const int MaxFailedAccessAttempts = 5;
    public const string AuthenticationMethodsReference = "amr";
    public const string AuthenticationMultifator = "multifator";
    public const string AddAuthorizationPolicy = "TwoFactorEnable";
    #endregion
    #region ERRORS

    public const string UnableGenerateConfirmationToken = "Unable to generate email confirmation URL.";
    public const string UnableGenerateToken = "Unable to generate token.";
    public const string UnableGenerateTwoFactorToken = "Unable to generate a two-factor authentication token.";
    #endregion

    #region Times
    public const int LoginLifeTimeToken = 8;//Hours
    public const int CompleProcessLifeTimeToken = 15;//Minutes

    // public static DateTime LoginLifeTimeToken = DateTime.UtcNow.AddHours(LoginExpiresHours);
    // public static DateTime LoginTwoFactorFinishProcessLifeTimeToken = DateTime.UtcNow.AddMinutes(_2FaExpiresMinutes);
    #endregion
}
