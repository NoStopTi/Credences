namespace Credence.Default.Constants.PasswordContext;

public record PasswordConst
{
    #region MAPPING INFRA/DOMAIN
    public const string Required = "Password is required.";
    public const string PasswordChangedAtHasColumnName = "PasswordChangedAt";
    public const int Min = 5;
    public const string MinMsg = "Password must be at least 5 characters long.";
    public const int Max = 20;
    public const string MaxMsg = "Password cannot exceed 180 characters.";
    #endregion

    #region ENDPOINT API
    public const string GroupRoute = "api/v1/passwords";
    public const string GroupRouteTag = "Manager Password";

    #region FORGOT
    public const int ForgotPasswordOrder = 1;
    public const string ForgotPassword = "ForgotPasswordAsync";
    public const string ForgotPasswordDesc = "Email notification password reset.";
    #endregion

    #region RESET
    public const int PasswordResetOrder = 2;
    public const string PasswordReset = "PasswordResetAsync";
    public const string PasswordResetDesc = "Change password after token validate.";

    #endregion

    #endregion

    #region WARNING
    public const int PwdMaxLoginFailed = 3;
    public const string PwdWillExpiresMsg = "Password will expire.";
    public const string PwdHasExpiresMsg = "Password has expired.";
    public static string PwdMaxLoginFailedMsg = $"The maximum of {PwdMaxLoginFailed} failed login attempts has been exceeded.";
    #endregion

    #region ERRORS
    public const string PwdNotNullOrEmpyt = "Password cannot be null or empty.";
    public const string PwdConfirmNotNullOrEmpyt = "Password or Confirm cannot be null or empty";

    public const string PwdOrUserInvalid = "Password or username is not valid.";
    public const string PwdNotMatch = "Passwords don’t match.";
    public const string PwdResetToken = "An error occurred while trying to generate a password reset token";
    public const string PwdForgotTokenPWDReset = "A verification token has been sent to your email. Thank you.";
    public const string PwdResetAction = "An error occurred while trying to change the password.";
    public const string PwdCannotContains = "password cannot be the the word";
    public const string UsernameCannotSame = "Username cannot be the same as the password.";
    // public const string PwdExpirePropertyPath = "PasswordExpire.PasswordChangedAt";
    public const string PwdExpireInvalidDate = "Expiration date must be greater than current date.";
   
    #endregion

    #region DATA
    public const string PwdContainsPas = "PASSWORD";
    public const string PwdContainsSen = "SENHA";

    #endregion
}
