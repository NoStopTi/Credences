namespace Credence.Default.DomainContext.Entities.Constants.CompanyContext;

public record CompanyNameConst
{
    public const string Required = "Company name is required.";
    
   
    #region MAPPING LegalName
    
    public const int LegalNameMin = 2;
    public const string LegalNameMinMsg = "Company name must be at least 5 characters long.";
    public const int LegalNameMax = 180;
    public const string LegalNameMaxMsg = $"Company name cannot exceed 180 characters.";
    #endregion

    #region MAPPING TradeName
    
    public const int TradeNameMin = 2;
    public const string TradeNameMinMsg = "Company name must be at least 5 characters long.";
    public const int TradeNameMax = 180;
    public const string TradeNameMaxMsg = $"Company name cannot exceed 180 characters.";
    #endregion


}