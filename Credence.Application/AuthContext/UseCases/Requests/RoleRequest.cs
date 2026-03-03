
namespace Credence.Application.AuthContext.UseCases.Requests;

public class RoleRequest
{
    public required string Name { get; set; }
    public required string DisplayRoleName { get; set; }
}