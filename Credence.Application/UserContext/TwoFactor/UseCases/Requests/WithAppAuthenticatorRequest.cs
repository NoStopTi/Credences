
using Credence.Domain.SharedContext.ValueObjects;

namespace Credence.Application.UserContext.TwoFactor.UseCases.Requests;

public class WithAppAuthenticatorRequest
{
    public WithAppAuthenticatorRequest(string email, bool onOff)
    {
        Email validEmail = new Email(email);
        Email = validEmail;
        OnOff = onOff;
    }

    public string Email { get; private set; } = string.Empty;
    public bool OnOff { get; private set; }

}