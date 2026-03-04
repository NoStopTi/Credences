

using System.Security.Claims;

namespace Credence.Application.SharedContext.Contracts.Authorization.Jwt;

public interface IJwtValidateTokenServices
{
  ClaimsPrincipal ExtractClaimsPrincipal(string token);
  string ExtractEmailFromPrincipalClaims(ClaimsPrincipal principal);
}