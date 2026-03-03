using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Credence.Application.SharedContext.Requests;
using Credence.Application.UserContext.Exceptions;
using Credence.Default.Constants.PasswordContext;
using Credence.Domain.UserContext.ValueObjects;
using Flunt.Notifications;


namespace Credence.Application.UserContext.Passwords.UseCases.Requests;

public class ResetRequest : Request
{
    [JsonIgnore]
    public override Guid UserId { get; set; }
    [Required]
    public string Token { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
    public required string ConfirmPassword { get; set; } = string.Empty;

    public List<Notification> Notifications()
    {
        var val = new Password(Password, ConfirmPassword);

        return val.IsValid ? [] : val.Notifications.ToList();
    }
    public void PasswordValidate()
    {
        var val = new Password(Password, ConfirmPassword);

        if (!val.IsValid)
            throw new ResetPasswordException(PasswordConst.PwdNotMatch);
    }
}
