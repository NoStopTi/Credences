using Credence.Default.Constants.JwtContext;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Microsoft.OpenApi.Models;

namespace Credence.Default.ApiContext.Configurations;

public static class ApiExtensions
{
    #region AUTHORIZATION SCHEME
    public static void AddAuthorizationSettings(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(auth =>
        {
            auth.AddPolicy(IdentityConst.AddAuthorizationPolicy, policy =>
            {
                policy.RequireClaim(IdentityConst.AuthenticationMethodsReference, IdentityConst.AuthenticationMultifator);
                // policy.RequireAssertion(context => context.User.HasClaim(c => c.Type == IdentityConst.AuthenticationMethodsReference && c.Value == "sub"));
            });
        });
    }
    #endregion

    #region GET_APPSETTINGS_DATA
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration
                                           .GetConnectionString(ApiSettings.DefaultKey)
                                                ?? string.Empty;

        ApiSettings.SetConnectionString(connectionString);

        string stripeApiKey = builder.Configuration
                                       .GetValue<string>(ApiSettings.StripeApiKeyValue)
                                            ?? string.Empty;

        ApiSettings.SetStripeApiKey(stripeApiKey);
    }
    #endregion

    #region CROSS_ORIGIN
    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => options.AddPolicy(
                ApiSettings.CorsPolicyName,
                policy => policy.WithOrigins([
                    ApiSettings.FrontEndUrl
                ])
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            )
        );
    }
    #endregion

    #region API_DOCUMENTATION
    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Credences",
                Version = "v1"
            });

            options.AddSecurityDefinition(JwtConst.TypeAuthorization, new OpenApiSecurityScheme
            {
                Name = JwtConst.Name,
                Type = SecuritySchemeType.Http,
                Scheme = JwtConst.TypeAuthorization.ToLower(),
                BearerFormat = JwtConst.BearerFormat,
                In =ParameterLocation.Header,
                Description = JwtConst.Description
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtConst.TypeAuthorization
                        }
                    },
                    Array.Empty<string>()
                }
            });

        });








        // builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });
    }
    #endregion
}