namespace Credence.Default.DomainContext.Entities.Constants.AuthContext;

public record IdentityUserTokenConst
{
    #region MAPPING
    public const int LoginProviderMax = 120;
    public const string LoginProviderMaxMsg = "LoginProvider cannot exceed 255 characters.";
    public const int NameMax = 80;
    public const string NameMaxMsg = "Name cannot exceed 255 characters.";
    #endregion
}