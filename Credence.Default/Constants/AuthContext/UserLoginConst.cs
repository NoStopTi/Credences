namespace Credence.Default.DomainContext.Entities.Constants.AuthContext;

public record UserLoginConst
{
    #region MAPPING
    public const int LoginProviderMax = 128;
    public const string LoginProviderMaxMsg = "LoginProvider cannot exceed 128 characters.";
    public const int ProviderKeyMax = 128;
    public const string ProviderKeyMaxMsg = "ProviderKey cannot exceed 128 characters.";
    public const int ProviderDisplayNameMax = 255;
    public const string ProviderDisplayNameMaxMsg = "ProviderDisplayName cannot exceed 255 characters.";
    #endregion
    
}