

using Credence.Domain.SharedContext.ValueObjects;

namespace Credence.Domain.UserContext.ValueObjects;

public class TwoFactorCodeSecondStepByEmail : ValueObject
{
    public TwoFactorCodeSecondStepByEmail()
    {

    }
    public TwoFactorCodeSecondStepByEmail(DateTime disabledAt)
    {
        SendCodeByEmailDisabledAt = disabledAt;
    }

    public DateTime SendCodeByEmailDisabledAt { get; private set; }

    public static implicit operator TwoFactorCodeSecondStepByEmail(DateTime date)
                                                            => new TwoFactorCodeSecondStepByEmail(date);

    public static implicit operator DateTime(TwoFactorCodeSecondStepByEmail TwoFactorCodeSecondStepByEmail)
                                                                  => TwoFactorCodeSecondStepByEmail.SendCodeByEmailDisabledAt;

    public override string ToString()
                                    => SendCodeByEmailDisabledAt.ToString("u");

  
}