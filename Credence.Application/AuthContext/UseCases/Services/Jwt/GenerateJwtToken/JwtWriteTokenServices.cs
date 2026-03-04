using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Credence.Domain.UserContext.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Credence.Default.Constants.JwtContext;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Credence.Application.SharedContext.Contracts.Authorization.Role;
using Credence.Application.SharedContext.Contracts.Authorization.Jwt;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;
using Credence.Application.AuthContext.UseCases.Services.Jwt.Enums;
using Credence.Application.AuthContext.UseCases.Services.Jwt.Exceptions;

namespace Credence.Application.AuthContext.UseCases.Services.Jwt.GenerateJwtToken;

public class JwtWriteTokenServices(IRolesServices rolesServices) : IJwtWriteTokenServices
{


    public async Task<string> GenerateJwtToken(User user, DateTime expires, ETokenType tokenType)
    {
        var claimsIdentity = await BuilderClaimsIdentity(user, tokenType);

        var tokenJwt = BuildToken(
                                    expires,
                                    JwtConst.ValidIssuer,
                                    JwtConst.ValidAudience,
                                    SigningCredentials,
                                    claimsIdentity
                                  );


        return tokenJwt;
    }

    private string BuildToken(
                                DateTime expires,
                                string issuer,
                                string audience,
                                Func<SigningCredentials> signing,
                                ClaimsIdentity? claimsIdentity
                             )
    {

        var handler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = claimsIdentity,
            Issuer = issuer,
            Audience = audience,
            Expires = expires,
            SigningCredentials = signing()
        };

        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }

    private SigningCredentials SigningCredentials()
    {

        var key = StringExtensions.Encoded_UTF8(JwtConst.SecretKey);

        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
    private async Task<ClaimsIdentity> BuilderClaimsIdentity(User user, ETokenType tokenType) => tokenType switch
    {
        ETokenType.Authenticated => await Authenticated(user),
        ETokenType.TwoFactorPending => TwoFactorPending(user),
        ETokenType.Unauthorized => Unauthorized(),
        _ => throw new JwtException(TwoFactorConst.ProviderInvalidError),//Modificar isso 
    };
    private async Task<ClaimsIdentity> Authenticated(User user)
    {
        var getRoles = await rolesServices.GetRolesAsync(user);

        var claims = new ClaimsIdentity(IdentityConstants.TwoFactorUserIdScheme);

        claims.AddClaim(new Claim(ClaimTypes.Email, user.Email!));
        claims.AddClaim(new Claim(ClaimTypes.Name, user.Email!));

        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claims.AddClaim(new Claim(ClaimTypes.GivenName, user.UserName!));

        claims.AddClaim(new Claim(IdentityConst.AuthenticationMethodsReference, IdentityConst.TwoFactorWithEmailTokenProvider));

        foreach (var role in getRoles)
            claims.AddClaim(new Claim(ClaimTypes.Role, role));
        return claims;
    }
    private ClaimsIdentity TwoFactorPending(User user)
    {
        var claims = new ClaimsIdentity(IdentityConstants.TwoFactorUserIdScheme);

        claims.AddClaim(new Claim(ClaimTypes.Email, user.Email ?? user.Id.ToString()));
        // claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        return claims;
    }
    private ClaimsIdentity Unauthorized()
    {
        var claims = new ClaimsIdentity(IdentityConstants.TwoFactorUserIdScheme);

        claims.AddClaim(new Claim(ClaimTypes.Email, JwtConst.InvalidToken!));

        return claims;
    }

}
