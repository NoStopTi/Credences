using System.ComponentModel.DataAnnotations;
namespace Credence.Application.SharedContext.Requests;

public abstract class Request
{
    public virtual Guid UserId { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

}