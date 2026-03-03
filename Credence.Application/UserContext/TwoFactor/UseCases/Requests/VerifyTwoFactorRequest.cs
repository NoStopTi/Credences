

namespace Credence.Application.UserContext.TwoFactor.UseCases.Requests;
public class VerifyTwoFactorRequest
{
    public VerifyTwoFactorRequest(string email, string provider, string code)
    {
        Email = email;
        Provider = provider;
        Code = code;
    }

    public string Email { get; private set; }
    public string Code { get; private set; }
    public string Provider { get; private set; }
    public void SetProvider(string value)
    {
        Provider = value;
    }

}