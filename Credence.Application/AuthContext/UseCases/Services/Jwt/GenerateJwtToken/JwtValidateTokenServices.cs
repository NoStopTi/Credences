
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Credence.Default.Constants.JwtContext;
using Credence.Application.AuthContext.UseCases.Services.Jwt.Exceptions;
using Credence.Application.SharedContext.Contracts.Authorization.Jwt;

namespace Credence.Application.AuthContext.UseCases.Services.Jwt.GenerateJwtToken;

public class JwtValidateTokenServices() : IJwtValidateTokenServices
{
    public ClaimsPrincipal ExtractClaimsPrincipal(string token) => GetClaimsPrincipal(token, JwtConst.SecretKey);
    public string ExtractEmailFromPrincipalClaims(ClaimsPrincipal principal) => GetEmailFromPrincipalClaims(principal);

    private string GetEmailFromPrincipalClaims(ClaimsPrincipal principal)
    {
        var email = principal.FindFirst(ClaimTypes.Email)?.Value;
        if (string.IsNullOrEmpty(email)) throw new JwtException(JwtConst.EmailClaimNotFound);

        return email;
    }

    private TokenValidationParameters Parameters(string secretKey)
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JwtConst.ValidIssuer,
            ValidAudience = JwtConst.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(StringExtensions.Encoded_UTF8(secretKey)),
            ClockSkew = TimeSpan.Zero
        };
    }
    private ClaimsPrincipal GetClaimsPrincipal(string token, string secretKey)
    {
        try
        {
            var principal = new JwtSecurityTokenHandler().ValidateToken(token, Parameters(secretKey), out SecurityToken validatedToken);

            if (validatedToken is not JwtSecurityToken jwtToken || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new JwtException(JwtConst.InvalidToken);


            return principal;
        }

        catch (SecurityTokenExpiredException)
        {
            throw new JwtException("Token expired");
        }
        catch (SecurityTokenException)
        {
            throw new JwtException("Invalid token");
        }
        catch (Exception)
        {
            throw new JwtException(JwtConst.InvalidToken);
        }
    }

}
