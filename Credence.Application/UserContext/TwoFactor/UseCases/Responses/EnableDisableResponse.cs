using Credence.Application.UserContext.Exceptions;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;


namespace Credence.Application.UserContext.TwoFactor.UseCases.Responses;

public class EnableDisableResponse
{
    public EnableDisableResponse(string[] recoveryCodes, bool isTwoFactorEnabled)
    {
        if (!recoveryCodes.Any())
            throw new TwoFactorException(TwoFactorConst.EnableDisableRoute);

        RecoveryCodes = recoveryCodes;
        IsTwoFactorEnabled = isTwoFactorEnabled;

    }

    public string[] RecoveryCodes { get; private set; } = [];
    public bool IsTwoFactorEnabled { get; private set; } = false;
}