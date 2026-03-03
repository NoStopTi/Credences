using Credence.Application.UserContext.Register.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Credence.Application.SharedContext.Contracts.Register;
public interface IRegisterHandler
{
   Task<Response<IReadOnlyCollection<Notification>>> RegisterAsync([FromBody] RegisterUserRequest request);
}
