namespace Credence.Default.Constants.UserContext;

public record UserConst
{
    #region MAPPING
    public const string ToTable = "AU_User";//AU_ == Authentication
    public const string IdHasColumnName = "Id";
    public const string IdHasColumnType = "BINARY(16)";
    public const int DisplayNameMax = 20;
    public const string DisplayNameMaxMsg = "DisplayName cannot exceed 180 characters";
    public const int NormalizedEmailMax = 180;
    public const string NormalizedEmailMaxMsg = "NormalizedEmail cannot exceed 180 characters";
    public const int UserNameMax = 180;
    public const string UserNameMaxMsg = "UserName cannot exceed 180 characters";
    public const int NormalizedUserNameMax = 180;
    public const string NormalizedUserNameMaxMsg = "NormalizedUserName cannot exceed 180 characters";
    public const int PhoneNumberMax = 20;
    public const string PhoneNumberMaxMsg = "PhoneNumber cannot exceed 20 characters";
    #endregion

    #region ENDPOINT API

    public const string GroupRoute = "api/v1/users";
    public const string GroupRouteTag = "Users Manager";

    #region LOGIN
    public const string Login = "login";
    public const string LoginDesc = "Authenticates the users.";
    public const int LoginOrder = 2;
    public const string LoginErroPlaceNotification = "Place: LoginHandler.LoginValidate";
    #endregion

    #region REGISTER
    public const string RegisterUser = "registeruser";
    public const string RegisterResponse = "Registered";
    public const int RegisterOrder = 2;
    public const string RegisterUserDesc = "Create subscription";
    #endregion
    #endregion

    #region WARNING
    public const string None = "NONE";
    #endregion

    #region ERRORS UserAccountStatus
    public const string InvalidAccessFailedCount = "Invalid number of access attempts.";
    public const string AccountHasBeenLocked = "Your account has been locked.";
    public const string AccountLockoutType = "LockoutType";
    public const string AccountTemporarilyLocked = "Your account is temporarily locked. See your email for more information.";
    #endregion

    #region ERRORS
    public const string InvalidUser = "Error: Invalid user.";
    public const string LastLoginMsg = "Last login must be later than the current date and time.";
    #endregion

    #region PROPERTIES_NAME
    public const string LastLoginValue = "LastLogin";
    public const string PasswordChangedAtValue = "PasswordChangedAt";
    public const string LockoutEndValue = "LockoutEnd";
    public const string UserValidationPath = "UserValidations.ResetLockoutVal";
    public const string LockoutFalse = "Lockout is disabled, so the user cannot be blocked.";
    #endregion
}