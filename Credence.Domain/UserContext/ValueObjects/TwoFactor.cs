

using Credence.Domain.SharedContext.ValueObjects;
using Credence.Domain.UserContext.ValueObjects.Validations;

namespace Credence.Domain.UserContext.ValueObjects;

public class TwoFactor : ValueObject
{
    public TwoFactor()
    {

    }
    public TwoFactor(DateTime disabledAt)
    {
        SendCodeByEmailDisabledAt = disabledAt;
        AddNotifications(new TwoFactorValidation(this));
    }

    public DateTime SendCodeByEmailDisabledAt { get; private set; }

    public void SetPasswordChangedAt(DateTime disabledAt)
    {
        SendCodeByEmailDisabledAt = disabledAt;
        AddNotifications(new TwoFactorValidation(this));
    }


    public static implicit operator TwoFactor(DateTime date)
                                                            => new TwoFactor(date);

    public static implicit operator DateTime(TwoFactor twoFactor)
                                                                  => twoFactor.SendCodeByEmailDisabledAt;

    public override string ToString()
                                    => SendCodeByEmailDisabledAt.ToString("u");

    public bool Validate(string source)
    {
        AddNotifications(new TwoFactorValidation(this));
        return IsValid;
    }

}