using Credence.Default.DomainContext.Entities.Constants.BusinessContext;
using Credence.Domain.BusinessContext.Entities;
using Flunt.Validations;

namespace Credence.Domain.ProfileContext.Entities.Validations;

public class BusinessValidation : Contract<Business>
{
    //Não esta aplicada em lugar algum.
    public BusinessValidation(Business business)
    {
        Requires()
            .IsNullOrEmpty(business.Name?.FirstName, nameof(business.Name.FirstName), BusinessConst.NameRequired)
            .IsGreaterThan(business.Name?.FirstName, BusinessConst.NameMax, BusinessConst.NameMaxMsg);
    }
}
