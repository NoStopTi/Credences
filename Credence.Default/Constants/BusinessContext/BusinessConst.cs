
namespace Credence.Default.DomainContext.Entities.Constants.BusinessContext;

public record BusinessConst
{
    public const string ToTable = "PF_Businesses";//PF_ == ProFile
    public const string NameRequired = "Name is required.";
    public const string NameValue = "Name";
    public const string NameHasColumnType = "VARCHAR";
    public const int NameMax = 180;
    public const string NameMaxMsg = "Name cannot exceed 180 characters.";
}