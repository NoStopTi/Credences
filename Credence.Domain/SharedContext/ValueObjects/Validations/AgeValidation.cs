using Credence.Default.DomainContext.Entities.Constants.SharedContext;
using Flunt.Validations;

namespace Credence.Domain.SharedContext.ValueObjects.Validations;

public class AgeValidation : Contract<Age>
{
    public AgeValidation(Age age, string source)
    {
        Requires()
        .IsLowerOrEqualsThan(age.Value, 0, $"{source} - {AgeConst.AgeNegative}")
        .IsGreaterThan(age.Value, AgeConst.AgeMax, $"{source} - {AgeConst.AgeMaxMsg}");
    }

    
}
