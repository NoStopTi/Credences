using Credence.Api.Endpoints;
using Credence.Api.Extensions;
using Credence.Application.AuthContext.UseCases.Services.Jwt.Extensions;
using Credence.Default.ApiContext.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();

#region API
builder.AddAuthorizationSettings();
#endregion

builder.AddEmailService();

#region APPLICATION
#region JWT
builder.LoadJwtSettings();
builder.AddSecurityWithJwt();
#endregion
#endregion
#region INFRA
builder.AddDataContexts();
builder.AddRepositories();
#endregion

builder.AddIdentityCustomSettings();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();
builder.AddInfraValidations();
builder.AddDefaultHelpers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiSettings.CorsPolicyName);
app.UseRouting(); //aways after app.UseAuthentication(); app.UseAuthorization();
app.UseSecurity(); //<-- app.UseAuthentication(); app.UseAuthorization();
app.MapEnpoints();

app.Run();
