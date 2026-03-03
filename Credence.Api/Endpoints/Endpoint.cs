using Credence.Api.Endpoints.CategoryContext;
using Credence.Api.Endpoints.EmailContext;
using Credence.Api.Endpoints.PasswordContext;
using Credence.Api.Endpoints.TransactionsContext;
using Credence.Api.Endpoints.TwoFactorContext;
using Credence.Api.Endpoints.UserContext;

namespace Credence.Api.Endpoints;

public static class Endpoint
{
    public static void MapEnpoints(this WebApplication app)
    {
       app.EnpointsPasswordMap();
       app.EnpointsEmailMap();
       app.EnpointsUserMap();
       app.TwoFactorEndpointMap();
       app.EnpointsCatecoriesMap();
       app.EnpointsTransactionsMap();
       app.TestsEndpointMap();
    }
}