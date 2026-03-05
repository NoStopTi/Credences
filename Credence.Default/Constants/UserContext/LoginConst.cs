namespace Credence.Default.Constants.UserContext;

public record LoginConst
{
    #region NOTIFICATIONS
    public const string LoginFail = "Password or username is invalid. See notifications.";
    public const string RequestErroValidation = "Credence.Application.UserContext.Login.UseCases.Requests.LoginUserRequest";
    public const string Path_01 = @"CLASS:LoginHandler METHOD:Login SNIPPET: if (!_userValidations.IsValidForLogin(user ?? null!, ""))";
    public const string Path_02 = @"CLASS:LoginHandler METHOD:Login SNIPPET: var isValid = _userValidations.IsValidForLogin(user, $'LoginHandler.Login');";
    public const string Path_03 = @"CLASS:LoginHandler METHOD:Login METHOD:IsEmailConfirm";
    public const string Path_04 = @"CLASS:LoginHandler METHOD:Login SNIPPET: var isValid = _userValidations.IsValidForLogin(getUser.User ?? null!, LoginConst.Path_02);";
    // public const string Path_05 = @"CLASS:LoginHandler METHOD:Login METHOD:RequestValidate SNIPPET: var isValid = var emailChecked = new Email(email);";
    // public const string Path_06 = @"CLASS:LoginHandler METHOD:Login METHOD:RequestValidate SNIPPET: var isValid = var passwordChecked = new Password(pass);";
    //  public const string Path_07 = @"CLASS:LoginHandler METHOD:Login";
     public const string Path_05 = @"Full_Path: Credence.Application.UserContext.Login.UseCases.Requests CLASS:LoginUserRequest";
    public const string UserNotFound = "User not found.";
    #endregion

}
