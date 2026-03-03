
using System.ComponentModel.DataAnnotations;
using Credence.Default.DomainContext.Entities.Constants.CompanyContext;
using Credence.Domain.SharedContext.ValueObjects;

namespace Credence.Domain.CompanyContext.ValueObjects;

public class CompanyName : ValueObject
{
    protected CompanyName() { }
    public CompanyName(
        string legalName,
        string tradeName
        )
    {
        LegalName = legalName;
        TradeName = tradeName;
    }

    [Required(ErrorMessage = CompanyNameConst.Required)]
    [MinLength(CompanyNameConst.LegalNameMin, ErrorMessage = CompanyNameConst.LegalNameMinMsg)]
    [MaxLength(CompanyNameConst.LegalNameMax, ErrorMessage = CompanyNameConst.LegalNameMaxMsg)]
    public string LegalName { get; private set; } = string.Empty;

    [Required(ErrorMessage = CompanyNameConst.Required)]
    [MinLength(CompanyNameConst.TradeNameMin, ErrorMessage = CompanyNameConst.TradeNameMinMsg)]
    [MaxLength(CompanyNameConst.TradeNameMax, ErrorMessage = CompanyNameConst.TradeNameMaxMsg)]
    public string TradeName { get; private set; } = string.Empty;

}