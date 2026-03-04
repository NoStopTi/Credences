using Credence.Default.DomainContext.Entities.Constants.AuthContext;

namespace Credence.Default.Constants.JwtContext;

public class JwtConst
{
    public static int ExpiresFirstRegister;
    public static string ValidIssuer { get; set; } = string.Empty;
    public static string ValidAudience { get; set; } = string.Empty;
    public static string SecretKey { get; set; } = string.Empty;
    public static int LoginExpiresHours = IdentityConst.LoginLifeTimeToken;
    /// <summary>
    ///Email confirmation
    //Password reset
    //Change email
    //time renaming to complete second step twofactor
    /// </summary>
    public static int CompleProcessLifeTimeToken = IdentityConst.CompleProcessLifeTimeToken;

    public const string JwtSettingsValue = "JwtSettings";
    public const string ValidAudience_ = "validAudience";
    public const string SecretKey_ = "secretKey";
    public const string ValidIssuer_ = "validIssuer";
    // public const string LoginExpiresHours_ = "loginExpiresHours";
    // public const string _2FaExpiresMinutes_ = "_2FaExpiresMinutes";
    public const string ExpiresFirstRegister_ = "expiresFirstRegister";
    public const string GenerateTwoFactorTokenAsync = "Email";

    #region JWTConstants
    public const string Name = "Authorization";
    public const string Description = "Type only the JWT token here.";
    public const string TypeAuthorization = "Bearer";
    public const string BearerFormat = "JWT";
    public const string InvalidToken = "Invalid JWT token.";
    public const string EmailClaimNotFound = "Email claim not found.";
    #endregion


}

