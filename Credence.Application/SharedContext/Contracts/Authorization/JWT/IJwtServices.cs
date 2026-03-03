
using Credence.Application.AuthContext.UseCases.Services.Jwt.Enums;
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.Authorization.Jwt;

public interface IJwtServices
{
  Task<string> GenerateJwtToken(
                                 User user,
                                 DateTime expires,
                                 ETokenType tokenType
                                 );

}