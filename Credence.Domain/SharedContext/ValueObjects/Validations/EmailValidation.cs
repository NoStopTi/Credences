
using Credence.Default.Constants.EmailContext;
using Credence.Default.Messages;
using Flunt.Validations;

namespace Credence.Domain.SharedContext.ValueObjects.Validations;

public class EmailValidation : Contract<Email>
{    public EmailValidation(Email email, string source)
    {
        Requires()
        .IsNotNullOrEmpty(email.Address, nameof(Email), $"{source}-{Errors.CannotBeNullOrEmpty}")
            .IsEmail(email.Address, $"{source}-{EmailConst.InvalidEmail}");
    }    
}
