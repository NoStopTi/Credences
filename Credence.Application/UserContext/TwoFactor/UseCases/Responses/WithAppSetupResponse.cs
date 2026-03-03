namespace Credence.Application.UserContext.TwoFactor.UseCases.Responses;
public class WithAppSetupResponse
{
    public WithAppSetupResponse(string sharedKey, string authenticatorUri, bool isTwoFactorEnabled)
    {
        SharedKey = sharedKey;
        AuthenticatorUri = authenticatorUri;
        IsTwoFactorEnabled = isTwoFactorEnabled;
    }

    public string SharedKey { get; private set; } = string.Empty;
    public string AuthenticatorUri { get; private set; } = string.Empty;
    public bool IsTwoFactorEnabled { get; private set; }
}