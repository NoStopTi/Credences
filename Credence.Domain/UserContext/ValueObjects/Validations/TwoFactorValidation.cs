using Flunt.Validations;

namespace Credence.Domain.UserContext.ValueObjects.Validations;

public class TwoFactorValidation : Contract<TwoFactor>
{
    public TwoFactorValidation(TwoFactor twoFactor)
    {

        // if (twoFactor.SendCodeByEmailDisabledAt != DateTime.MinValue)
        //     Requires()
        //         .IsGreaterThan(
        //             twoFactor.SendCodeByEmailDisabledAt,
        //             DateTime.UtcNow,
        //             PasswordConst.PwdExpirePropertyPath,
        //             PasswordConst.PwdExpireInvalidDate
        //         );
    }
}