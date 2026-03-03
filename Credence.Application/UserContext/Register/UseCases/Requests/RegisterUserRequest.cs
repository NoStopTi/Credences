

using System.Text.Json.Serialization;
using Credence.Application.SharedContext.Requests;

namespace Credence.Application.UserContext.Register.UseCases.Requests;

public class RegisterUserRequest : Request
{
    public RegisterUserRequest() { }

    [JsonIgnore]
    public override Guid UserId { get => base.UserId; set => base.UserId = value; }
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}