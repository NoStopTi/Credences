
using System.ComponentModel.DataAnnotations;

using Credence.Default.Constants.EmailContext;
using Credence.Default.Constants.PasswordContext;

namespace Credence.Application.UserContext.Login.UseCases.Requests;


public record LoginUserRequest
{
    public LoginUserRequest(string email, string password)
    {
        Email = email;
        Password = password;
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
