using Credence.Default.Constants.UserContext;
using Flunt.Validations;

namespace Credence.Domain.UserContext.ValueObjects.Validations;

public class NameValidation : Contract<Name>
{
    public NameValidation(Name name, string source)
    {
        #region FIRST_NAME
        Requires()
        .IsNotNullOrEmpty(name.FirstName, NameConst.FirstNameRequired)
          .IsLowerOrEqualsThan(name?.FirstName ?? string.Empty,
                             NameConst.FirstNameMax,
                             $"{source}-{NameConst.FirstNameMaxMsg}")

          .IsGreaterOrEqualsThan(name?.FirstName ?? string.Empty,
                                NameConst.FirstNameMin,
                                $"{source}-{NameConst.FirstNameMinMsg}");
        #endregion

        #region LAST_NAME
        IsLowerOrEqualsThan(name?.LastName ?? string.Empty,
                                                    NameConst.LastNameMax,
                                                    $"{source}-{NameConst.LastNameMaxMsg}")

                        .IsGreaterOrEqualsThan(name?.LastName ?? string.Empty,
                                                        NameConst.LastNameMin,
                                                        $"{source}-{NameConst.LastNameMinMsg}");

        #endregion

        #region DISPLAY_NAME
        IsLowerOrEqualsThan(name?.DisplayName ?? string.Empty,
                                                  NameConst.DisplayNameMax,
                                                  $"{source}-{NameConst.DisplayNameMaxMsg}")

                    .IsGreaterOrEqualsThan(name?.DisplayName ?? string.Empty,
                                               NameConst.DisplayNameMin,
                                               $"{source}-{NameConst.DisplayNameMinMsg}");

        #endregion

    }
}
