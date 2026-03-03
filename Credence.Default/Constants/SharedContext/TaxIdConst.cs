
namespace Credence.Default.DomainContext.Entities.Constants.SharedContext;

public record TaxIdConst
{
    #region Mapping
    public const string Required = "This field is required.";
    public const string Invalid = "document is not valid.";
    public const int CnpjMax = 14;
    public const string CnpjMaxMsg = "CNPJ must be at least 5 characters long.";
    public const int CpfMax = 11;
    public const string CpfMaxMsg = $"CPF address cannot exceed 180 characters.";
    #endregion

}