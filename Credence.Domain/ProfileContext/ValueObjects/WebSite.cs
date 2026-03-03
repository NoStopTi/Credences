using System.ComponentModel.DataAnnotations;
using Credence.Default.DomainContext.Entities.Constants.ProfileContext;
using Credence.Domain.ProfileContext.ValueObjects.Validations;
using Credence.Domain.SharedContext.ValueObjects;

namespace Credence.Domain.ProfileContext.ValueObjects;

public class WebSite : ValueObject
{
    public WebSite(string url)
    {
        Url = url.Trim().ToLower();
        AddNotifications(new WebSiteValidation(this));
    }

    [MaxLength(ContactConst.WebSiteMax, ErrorMessage = ContactConst.WebSiteMaxMsg)]
    public string? Url { get; private set; } = null!;

    public static implicit operator WebSite(string url)
                                                => new WebSite(url);

    public static implicit operator string(WebSite webSite)
                                                => webSite.Url ?? null!;
    public override string ToString()
                                                => Url!.ToString();
}
