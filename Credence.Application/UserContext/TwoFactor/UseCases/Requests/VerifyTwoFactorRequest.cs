

namespace Credence.Application.UserContext.TwoFactor.UseCases.Requests;
public class VerifyTwoFactorRequest
{
    public VerifyTwoFactorRequest(string provider, string code, string token)
    {
        // Email = email;
        Provider = provider;
        Code = code;
        Token = token;
    }

    // public string Email { get; private set; }
    public string Code { get; private set; }
    public string Token { get; private set; }
    public string Provider { get; private set; }
    public void SetProvider(string value)
    {
        Provider = value;
    }
    // public VerifyTwoFactorRequest(string email, string provider, string code, string token)
    // {
    //     Email = email;
    //     Provider = provider;
    //     Code = code;
    //     Token = token;
    // }

    // public string Email { get; private set; }
    // public string Code { get; private set; }
    // public string Token { get; private set; }
    // public string Provider { get; private set; }
    // public void SetProvider(string value)
    // {
    //     Provider = value;
    // }

}