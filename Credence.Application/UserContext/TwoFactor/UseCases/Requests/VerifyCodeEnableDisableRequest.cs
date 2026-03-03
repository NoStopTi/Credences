
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;

namespace Credence.Application.UserContext.TwoFactor.UseCases.Requests;

public class VerifyCodeEnableDisableRequest
{
    public VerifyCodeEnableDisableRequest(string code, bool changeState, string provider = TwoFactorConst.EMAIL_DefaultAuthenticatorProvider)
    {
        Code = code;
        Provider = provider;
        ChangeState = changeState;
    }
    public string Code { get; private set; }
    public string Provider { get; private set; }
    public bool ChangeState { get; private set; }
}