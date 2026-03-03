
namespace Credence.Default.DomainContext.Entities.Constants.SharedContext;

public record WebSiteConst
{
    #region Mapping
    public const string InvalidUrl = "Invalid url.";
    public const string HasColumnName = "Age";
    public const string HasColumnType = "INT";
    public const int AgeMax = 3;
    public const string AgeMaxMsg = "Age cannot exceed 3 characters.";
    #endregion

    #region ERRORS
    public const string AgeNegative = "Age must not be a negative number.";
    #endregion


}