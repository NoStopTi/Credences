namespace Credence.Default.Constants.UserContext;

public record NameConst
{
    #region First Name
    public const string FirstNameHasColumnName = "FirstName";
    public const string FirstNameRequired = "First name is required.";
    public const int FirstNameMin = 2;
    public const string FirstNameMinMsg = "Name must be at least 2 characters long.";
    public const int FirstNameMax = 180;
    public const string FirstNameMaxMsg = $"Name cannot exceed 180 characters.";
    #endregion

    #region Last Name

    public const string LastNameHasColumnName = "LastName";
    public const string LastNameMaxMsg = $"Last Name cannot exceed 180 characters.";
    public const int LastNameMax = 180;
    public const string LastNameMinMsg = "Last  Name must be at least 2 characters long.";
    public const int LastNameMin = 2;
    #endregion 
    
    #region DisplayName

    public const string DisplayNameHasColumnName = "DisplayName";
    public const string DisplayNameMaxMsg = $"Display name cannot exceed 50 characters.";
    public const int DisplayNameMax = 50;
    public const string DisplayNameMinMsg = "Display name must be at least 2 characters long.";
    public const int DisplayNameMin = 2;
    #endregion 

}
