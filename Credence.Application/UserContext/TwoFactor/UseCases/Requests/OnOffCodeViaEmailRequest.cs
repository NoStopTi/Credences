
using Credence.Domain.SharedContext.ValueObject.Abstractions;
using Credence.Domain.SharedContext.ValueObjects;
using Credence.Domain.SharedContext.ValueObjects.Validations;
using Flunt.Notifications;

namespace Credence.Application.UserContext.TwoFactor.UseCases.Requests;

public class OnOffCodeViaEmailRequest : Notifiable<Notification>, IValidate
{
    public OnOffCodeViaEmailRequest(string email, bool onOff)
    {
        Email = email;
        OnOff = onOff;
    }
    public string Email { get; private set; } = string.Empty;
    public bool OnOff { get; private set; }

    public bool Validate(string source)
    {
        AddNotifications(new EmailValidation(new Email(Email), source));
        return IsValid;
    }

}