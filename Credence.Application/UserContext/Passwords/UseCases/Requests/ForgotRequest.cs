using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Credence.Application.SharedContext.Requests;


namespace Credence.Application.UserContext.Passwords.UseCases.Requests;

public class ForgotRequest : Request
{
    [JsonIgnore]
    public override Guid UserId {get; set;}  
}