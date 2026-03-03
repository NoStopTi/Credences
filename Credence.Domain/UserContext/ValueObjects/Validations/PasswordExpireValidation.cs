using Credence.Default.Constants.PasswordContext;
using Flunt.Validations;

namespace Credence.Domain.UserContext.ValueObjects.Validations;

public class PasswordExpireValidation : Contract<PasswordExpire>
{
    public PasswordExpireValidation(PasswordExpire expire, string source)
    {
        if (expire != null)
        {

            if (expire.PasswordChangedAt.Date <= DateTime.UtcNow.Date)
                Requires()
                    .IsGreaterThan(
                        expire.PasswordChangedAt,
                        DateTime.UtcNow,
                        source,
                        PasswordConst.PwdExpireInvalidDate
                    );
        }
    }
}