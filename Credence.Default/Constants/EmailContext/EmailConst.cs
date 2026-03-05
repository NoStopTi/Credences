
namespace Credence.Default.Constants.EmailContext;

public record EmailConst
{
    #region ENDPOINT

    #region EMAIL CONFIRM
    public const string GroupRoute = "api/v1/emails";
    public const int ConfirmEmailOrder = 1;
    public const string WithTags = "Email Notifications";
    public const string ConfirmEmail = "ConfirmEmailAsync";
    public const string ConfirmEmailDesc = "Send email confirmation token.";
    #endregion

    #region MAPPING
    public const string Required = "Email address is required.";
    public const string EmailHasColumnName = "Email";
    public const int Min = 5;
    public const string MinMsg = "Email address must be at least 5 characters long.";
    public const int Max = 180;
    public const string MaxMsg = $"Email address cannot exceed 180 characters.";
    public const int EmailMax = 180;
    public const string EmailMaxMsg = "Email cannot exceed 180 characters";
    public const string AccountTemporarilyLocked = "Your account is temporarily locked. See your email for more information.";
    #endregion

    #region WARNING
    public const string EmailNotConfirmed = "Email not confirmed. Please check your email and confirm your identity. Thank you!";
    public const string EmailAlreadyConfirmed = "Email already registered. If you don’t remember your password, click the \"I forgot my password\" link to reset it.";

    #endregion
    #region ERRORS
    public const string InvalidEmail = "Invalid email address.";
    public const string Path_01 = "User.EmailConfirmed";
    #endregion


    #endregion
}
