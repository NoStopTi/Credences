
using Credence.Default.DomainContext.Entities.Constants.ProfileContext;
using Credence.Domain.ProfileContext.Exceptions;
using Credence.Domain.ProfileContext.ValueObjects;
using Credence.Domain.SharedContext.Entities;
using Credence.Domain.SharedContext.ValueObjects;

namespace Credence.Domain.ProfileContext.Entities;

public class Contact : Entity
{
    private readonly ICollection<SocialNetwork>? _socialNetworks = [];
    protected Contact() { }
    public Contact(
                    Email email,
                    WebSite webSite,
                    Phone phone
                   )
    {
        Email = email;
        WebSite = webSite;
        Phone = phone;

        if (!email.IsValid && WebSite.IsValid && Phone.IsValid)
            throw new ProfileException($@"{ContactConst.ContactInvalid} 
                                        Email: {email.IsValid} 
                                        WebSite:{webSite.IsValid}
                                        Phone: {phone.IsValid}");

    }

    public Phone Phone { get; private set; } = null!;
    public WebSite WebSite { get; private set; } = null!;
    public IReadOnlyCollection<SocialNetwork>? SocialNetworks => _socialNetworks!.ToList();

    public void AddSocialNetwork(SocialNetwork sc)
    {
        _socialNetworks!.Add(sc);
    }

}
