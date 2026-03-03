
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Credence.Application.SharedContext.Requests;
using Credence.Domain.SharedContext.ValueObjects;



namespace Credence.Application.UserContext.EmailConfirmation.UseCases.Requests;

public class EmailConfirmationRequest : Request
{
    [JsonIgnore]
    public override Guid UserId { get; set; }

    [Required]
    public required string Token { get; set; } = string.Empty;
}