
using System.ComponentModel.DataAnnotations;
using Credence.Application.UserContext.Exceptions;
using Credence.Default.Constants.EmailContext;
using Credence.Default.Constants.PasswordContext;
using Credence.Default.Constants.UserContext;
using Credence.Domain.SharedContext.ValueObjects.Validations;
using Flunt.Notifications;

namespace Credence.Application.UserContext.Login.UseCases.Requests;


public class LoginUserRequest : Notifiable<Notification>
{
    public LoginUserRequest(string email, string password)
    {
        Email = email =  "marcus@nostopti.com.br";
        Password = password =  "123";

        var emailNotifications = new EmailValidation(Email, LoginConst.Path_05);
        var passwordNotifications = new EmailValidation(Email, LoginConst.Path_05);
      
        AddNotifications(emailNotifications.Notifications);
        AddNotifications(passwordNotifications.Notifications);

        if(!IsValid)
        throw new LoginExceptions(LoginConst.LoginFail);
    }

    [DataType(DataType.EmailAddress)]
    [MaxLength(EmailConst.Max, ErrorMessage = EmailConst.MaxMsg)]
    public string Email { get; private set; } = string.Empty;

    [Required(ErrorMessage = PasswordConst.Required)]
    [MaxLength(PasswordConst.Max, ErrorMessage = PasswordConst.MaxMsg)]
    public string Password { get; private set; } = string.Empty;
    public bool RememberMe { get; private set; } = true;
    public string TimeZone { get; private set; } = "America/Sao_Paulo";
}
