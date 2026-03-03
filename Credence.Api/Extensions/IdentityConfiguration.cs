using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Credence.Infrastructure.Data;
using Credence.Domain.UserContext.Entities;
using Credence.Domain.AuthContext.Entities;
using Credence.Api.Identity;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;


namespace Credence.Api.Extensions;

public static class IdentityConfiguration
{
    public static void AddIdentityCustomSettings(this WebApplicationBuilder builder)
    {
        #region IDENTITY CUSTOMIZATION
        builder.Services.AddIdentity<User, IdentityRole<Guid>>(opt =>
            {
                opt.User.RequireUniqueEmail = IdentityConst.RequireUniqueEmail;

                opt.SignIn.RequireConfirmedEmail = IdentityConst.RequireConfirmedEmail;
                // opt.SignIn.RequireConfirmedAccount = IdentityConst.RequireConfirmedAccount;
                opt.Password.RequireDigit = IdentityConst.RequireDigit;
                opt.Password.RequireNonAlphanumeric = IdentityConst.RequireNonAlphanumeric;
                opt.Password.RequireLowercase = IdentityConst.RequireLowercase;
                opt.Password.RequireUppercase = IdentityConst.RequireUppercase;
                opt.Password.RequiredLength = IdentityConst.RequiredLength;
                //
                opt.Lockout.AllowedForNewUsers = IdentityConst.AllowedForNewUsers;
                opt.Lockout.DefaultLockoutTimeSpan = IdentityConst.DefaultLockoutTimeSpan(60);
                opt.Lockout.MaxFailedAccessAttempts = IdentityConst.MaxFailedAccessAttempts;
                // 
                // Define token providers
                opt.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider; //App Authenticator
                opt.Tokens.ChangeEmailTokenProvider =
                                            TokenOptions.DefaultProvider;
                opt.Tokens.ChangePhoneNumberTokenProvider =
                                            TokenOptions.DefaultPhoneProvider;
                opt.Tokens.EmailConfirmationTokenProvider =
                                            TokenOptions.DefaultProvider;
                opt.Tokens.PasswordResetTokenProvider =
                                            TokenOptions.DefaultProvider;

                //allow 2FA
                opt.Tokens.ProviderMap.Add(
                    IdentityConst.TwoFactorWithAppTokenProvider, 
                    new TokenProviderDescriptor(typeof(AuthenticatorTokenProvider<User>)));

            })
                .AddEntityFrameworkStores<CredenceDbContext>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<AuthenticatorTokenProvider<User>>(TokenOptions.DefaultAuthenticatorProvider)
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddPasswordValidator<IdentityPasswordValidatorPolicies<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddUserStore<UserStore<
                              User,
                              Role,
                              CredenceDbContext,
                              Guid,
                              IdentityUserClaim<Guid>,
                              UserRole,
                              IdentityUserLogin<Guid>,
                              IdentityUserToken<Guid>,
                              IdentityRoleClaim<Guid>>>()
                .AddRoleStore<RoleStore<Role,
                                        CredenceDbContext,
                                        Guid,
                                        UserRole,
                                        IdentityRoleClaim<Guid>>>();
        #endregion

        #region LIFE TIME TOKEN CONFIGURATIOn
        //Email confirmation
        //Password reset
        //Change email
        builder.Services.Configure<DataProtectionTokenProviderOptions>(
                   opt => opt.TokenLifespan = TimeSpan.FromMinutes(10)
               );

        #endregion

        #region REGISTER DI PRINCIPALFACTORY
        builder.Services.AddScoped<UserClaimsPrincipalFactory<User>>();
        #endregion

        #region LIFE TIME TOKEN TWO-FACTOR AUTHENTICATION PROCESS.

        //Add an authentication cookie with a {JwtConst._2FaExpiresMinutes}
        // expiration to complete the two-factor authentication process.”

        builder.Services.Configure<CookieAuthenticationOptions>(
                                   IdentityConstants.TwoFactorUserIdScheme,
                                   options =>
                                   {
                                       options.Cookie.Name = IdentityConstants.TwoFactorUserIdScheme;
                                       options.ExpireTimeSpan = TimeSpan.FromMinutes(IdentityConst.CompleProcessLifeTimeToken);
                                   });
        #endregion
    }
    
}