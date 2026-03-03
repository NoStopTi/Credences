using Credence.Domain.SharedContext.ValueObjects;
using Credence.Infrastructure.UserContext.UseCases.Responses;

namespace Credence.Application.SharedContext.Contracts.GetUser;
public interface IGetService
{
    Task<Response> EnsureNameOrEmailIsUniqueAsync(string nameOrEmail, string source);
    Task<Response?> GetByUserName(string name, string source);
    Task<Response?> GetByEmail(Email email, string source);
    Task<Response?> GetById(Guid id, string source);
}