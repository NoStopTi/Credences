namespace Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;

public record TwoFactorConst
{
    #region MAPPING
    public const string HasColumnNameCodeByEmail = "SendCodeByEmailDisabledAt";
    #endregion

    #region ENDPOINT API
    public const string GroupRoute = "api/v1/twofactor";
    public const string GroupRouteTag = "Two Factor Authentication.";

    #region TWOFACTOR ENABLE_DISABLE
     public const string GenerateTokenSendEmailRoute = "EnableDisable";
    public const string EnableDisableRoute = "EnableDisable";
    public const int EnableDisableRouteOrder = 2;
    public const string EnableDisableRouteDesc = "Enable or disable 2FA authentication.";
    #endregion
     #region TWOFACTOR VERIFYTOKEN
    // public const string GenerateTokenSendEmailRoute = "VerifyToken";
    public const string VerifyTokenRoute = "VerifyToken";
    public const int VerifyTokenRouteOrder = 2;
    public const string VerifyTokenRouteDesc = "Check code two factor authenticate.";
    #endregion
    // #region TWOFACTOR EnableDisable
    // public const string EnableDisableRoute = "EnableDisable";
    // public const string EnableDisableRouteDesc = "Enable or disable 2FA authentication.";
    // public const int EnableDisableRouteOrder = 2;
    // #endregion

    #region TWOFACTOR VIA CODE EMAIL
    public const string OnOffCodeEmailRoute = "OnOffCodeEmail";
    public const string OnOffCodeEmailDesc = "Enable or disable sending tokens via email.";
    public const int OnOffCodeEmailOrder = 3;
    #endregion

    #region SETUP VERIFY WITH APP 
    public const string SetupTwoFactorWithApp = "SetupTwoFactorWithApp";
    public const string WithAppSetupDesc = "Setup 2Fa using QrCode with app authenticator.";
    public const int WithAppSetupOrder = 1;
    #endregion

    #endregion

    #region ERRORS
    public const string ToggleOnOffCodeViaEmailError = "Error while changing the state.";
    public static string EnableDisableError = "An error occurred while enabling or disabling two-factor authentication.";
    public static string CodeIsInvalidError = "The code is invalid.";
    public static string ProviderInvalidError = "The provider is invalid.";
    #endregion

    #region SUCCESS
    public static string Enabled2FA(bool flag) => $"Two-factor authentication {StateToggle(flag)} successfully.";
    public static string StateToggle(bool flag) => flag ? "enabled" : "disabled";

    #endregion

    #region DATA
    public const string DisplayNameAppAuth = "I.M Integrações";
    public const string QrCode = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
    public const string APP_DefaultAuthenticatorProvider = "Authenticator";
    public const string EMAIL_DefaultAuthenticatorProvider = "Email";
    public const string CodeViaEmail = "code via email:";


    #endregion
    #region NOTIFICATIONS
    public const string NotePath_01 = @"CLASS:TwoFactorHandler METHOD:OnOffCodeViaEmail SNIPPET: var getUser = await get.GetByEmail(request.Email);";  
    #endregion
}
