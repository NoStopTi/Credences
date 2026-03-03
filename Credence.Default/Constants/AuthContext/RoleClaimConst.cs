
namespace Credence.Default.DomainContext.Entities.Constants.AuthContext;

public record RoleClaimConst
{
    #region ERRORS
    public const int ClaimTypeMax = 255;
    public const string ClaimTypeMaxMsg = "ClaimType cannot exceed 255 characters.";
    public const int ClaimValueMax = 255;
    public const string ClaimValueMaxMsg = "ClaimValue cannot exceed 255 characters.";
    #endregion
}