namespace Credence.Default.Constants.UserContext;

public record ValidationsConst
{
    #region COMPLETE MESSAGES
    public const string RequiredUserName = "User name is required.";
    #endregion

    #region SNIPPETS MESSAGES
    public static string ClassName_001 = "IUserRepository";

    #region GET_BY_USERNAME
    public static string GetByUserName_001 = "GetByUserName";
    public static string GetByUserNameException = $"CLASS: {ClassName_001} METHOD: {GetByUserName_001}\\coming from the DB.";
    #endregion

    #region GET_BY_EMAIL
    public static string GetByEmail_001 = "GetByEmail";
    public static string GetByEmailException = $"CLASS: {ClassName_001} METHOD: {GetByEmail_001}\\coming from the DB.";
    #endregion

    #region GET_BY_ID
    public static string GetById_001 = "GetById";
    public static string GetById_Required = "GetById";
    public static string GetByIdException = $"CLASS: {ClassName_001} METHOD: {GetById_001}\\coming from the DB.";
    #endregion

    #region GET_USERMANAGER
    public static string UserManager_001 = "UserManager";
    public static string GetUserManagerException = $"CLASS: {ClassName_001} METHOD: {UserManager_001}\\coming from the DB.";
    #endregion
    
    #endregion

}