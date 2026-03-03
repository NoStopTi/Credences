
namespace Credence.Application.AuthContext.UseCases.Responses;

public class UpdateUserRoleResponse
{
    public required string UserName { get; set; }
    public required string Role { get; set; }
    public required string DisplayRole { get; set; }
    public bool Delete { get; set; }
}