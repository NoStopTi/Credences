using Flunt.Notifications;

namespace Credence.Domain.ProfileContext.Entities;

public class SocialNetwork : Notifiable<Notification>
{
    protected SocialNetwork() { }
    public SocialNetwork(string name, string url)
    {
        Name = name;
        Url = url;
    }

    public long Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Url { get; private set; } = string.Empty;
    public Contact? Contact { get; set; }

}