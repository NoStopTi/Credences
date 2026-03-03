using System.ComponentModel.DataAnnotations;
using Credence.Domain.SharedContext.ValueObjects;
using Flunt.Notifications;


namespace Credence.Application.SharedContext.Requests;

public abstract class Request
{
    public virtual Guid UserId { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    public virtual List<Notification> Validate()
    {
        var emailValidated = new Email(Email);

        return emailValidated.Notifications.ToList();
    }

}