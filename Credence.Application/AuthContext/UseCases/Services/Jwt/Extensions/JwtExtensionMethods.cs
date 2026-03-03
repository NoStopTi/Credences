using Credence.Default.Constants.JwtContext;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;


namespace Credence.Application.AuthContext.UseCases.Services.Jwt.Extensions;

public static class JwtExtensionMethods
{
    public static void AddSecurityWithJwt(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(x =>
             {
                 x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 //
                 x.DefaultScheme = IdentityConstants.ApplicationScheme;
                 x.DefaultSignInScheme = IdentityConstants.ExternalScheme;
             }).AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = false;
                 x.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = JwtConst.ValidIssuer,
                     ValidAudience = JwtConst.ValidAudience,
                     IssuerSigningKey = new SymmetricSecurityKey(StringExtensions.Encoded_UTF8(JwtConst.SecretKey)),
                 };
             });
    }

    public static void LoadJwtSettings(this WebApplicationBuilder builder)
    {
        var jwtSettings = builder.Configuration.GetSection(JwtConst.JwtSettingsValue);

        JwtConst.ValidAudience = jwtSettings[JwtConst.ValidAudience_] ?? string.Empty;
        JwtConst.SecretKey = jwtSettings[JwtConst.SecretKey_] ?? string.Empty;
        JwtConst.ValidIssuer = jwtSettings[JwtConst.ValidIssuer_] ?? string.Empty;
        JwtConst.LoginExpiresHours = IdentityConst.LoginLifeTimeToken;
        JwtConst.CompleProcessLifeTimeToken = IdentityConst.CompleProcessLifeTimeToken;
        
    }


}