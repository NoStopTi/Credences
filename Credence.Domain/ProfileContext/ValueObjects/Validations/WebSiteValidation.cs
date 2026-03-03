using Credence.Default.DomainContext.Entities.Constants.SharedContext;
using Credence.Default.Messages;
using Credence.Domain.ProfileContext.Entities;
using Credence.Domain.SharedContext.ValueObjects;
using Flunt.Validations;

namespace Credence.Domain.ProfileContext.ValueObjects.Validations;

public class WebSiteValidation : Contract<Contact>
{
    public WebSiteValidation(WebSite webSite)
    {
        Requires()
        .IsNullOrEmpty(webSite.Url, nameof(Email), Errors.CannotBeNullOrEmpty)
            .IsUrl(webSite.Url, WebSiteConst.InvalidUrl);
    }

    
}
