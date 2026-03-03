
namespace Credence.Default.DomainContext.Entities.Constants.ProfileContext;
public record ContactConst
{
    #region MAPPING Website   
    public const string ToTable = "PF_Contacts"; //PF_ == ProFile
    public const string WebSiteValue = "WebSite";
    public const int WebSiteMax = 300;
    public const string WebSiteMaxMsg = "WebSite cannot exceed 255 digits.";
    public const string ContactInvalid = "The entity contact is invalid, or one of its value objects is";
    #endregion
}