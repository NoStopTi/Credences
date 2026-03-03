
namespace Credence.Default.DomainContext.Entities.Constants.SharedContext;

public record AgeConst
{
    #region Mapping
    public const string Required = "This field is required.";
    public const string HasColumnName = "Age";
    public const string HasColumnType = "INT";
    public const int AgeMax = 3;
    public const string AgeMaxMsg = "Age cannot exceed 3 characters.";
    #endregion

    #region ERRORS
    public const string AgeNegative = "Age must not be a negative number.";
    #endregion


}