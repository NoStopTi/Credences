using Credence.Application.SharedContext.Contracts.GetUser;
using Credence.Application.UserContext.Exceptions;
using Credence.Domain.UserContext.Entities;
using Credence.Domain.UserContext.ValueObjects.Validations;
using Flunt.Notifications;

namespace Credence.Application.UserContext.UseCases.Validations;

public class UserValidations : Notifiable<Notification>, IUserValidations
{
    public UserValidations()
    {

    }

    public void IsValidForLogin(User user, string source)
    {
        if (user == null) throw new LoginExceptions(source);

        new ResetLockoutValidation(user, source);

        if (!IsValid)
            throw new LoginExceptions(source);

    }

    // public bool FullValidation(User user, string source)
    // {
    //     new ResetLockoutValidation(user, source);

    //     user.Name!.Validate(source);

    //     user.LoginOptions!.Validate(source);

    //     user.PasswordExpire!.Validate(source);

    //     user.SendCodeByEmailDisabledAt!.Validate(source);

    //     user.Image!.Validate(source);

    //     user.Age!.Validate(source);

    //     return IsValid;
    // }


}
// using Credence.Application.SharedContext.Contracts.GetUser;
// using Credence.Domain.UserContext.Entities;
// using Credence.Domain.UserContext.ValueObjects.Validations;
// using Flunt.Notifications;

// namespace Credence.Application.UserContext.UseCases.Validations;

// public class UserValidations : Notifiable<Notification>, IUserValidations
// {
//     public UserValidations()
//     {

//     }



//     public bool FullValidation(User user, string source)
//     {


//         new ResetLockoutValidation(user, "User.ResetLockout()");

//         user.Name!.Validate
//                         ("User.IsUserValid() - User.Name");

//         user.LoginOptions!.Validate
//                         ("User.IsUserValid() - User.LoginOptions");

//         user.PasswordExpire!.Validate
//                         ("User.IsUserValid() - User.PasswordExpire");

//         user.SendCodeByEmailDisabledAt!.Validate
//                         ("User.IsUserValid() - User.SendCodeByEmailDisabledAt");

//         user.Image!.Validate
//                         ("User.IsUserValid() - User.Image");

//         user.Age!.Validate
//                         ("User.IsUserValid() - User.Age");

//     }


// }