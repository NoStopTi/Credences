using Credence.Application.SharedContext.Contracts.EmailNotifications;
using Credence.Application.SharedContext.Contracts.GetUser;
using Credence.Application.SharedContext.Contracts.Register;
using Credence.Application.UserContext.Register.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Default.Constants.EmailContext;
using Credence.Default.Constants.UserContext;
using Credence.Default.Messages;
using Credence.Domain.UserContext.Entities;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Credence.Application.UserContext.Register.UseCases;

public class RegisterHandler([FromServices] IRegisterService userRegister,
                             [FromServices] IGetService get,
                             [FromServices] IConfirmationService sendConfirmationService) : IRegisterHandler
{
    public async Task<Response<IReadOnlyCollection<Notification>>> RegisterAsync([FromBody] RegisterUserRequest request)
    {

        //MUDAR ISSO
        //Retornos com flunt
        
        try
        {
            // var requestValidate = request.Validate();

            var getUser = await get.EnsureNameOrEmailIsUniqueAsync(request.Email, RegisterConst.NotePath_01);

            if (getUser.User != null)
                return await SendEmailConfirmationAsync(getUser.User, request.Email, sendConfirmationService, true, []);

            var result = await userRegister.RegisterUserAsync(request);

            return await SendEmailConfirmationAsync(getUser.User ?? null!, request.Email, sendConfirmationService, result.Data!.Succeeded, []);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Response<IReadOnlyCollection<Notification>>([], StatusCodes.Status500InternalServerError, Errors.CreateFail);
        }
    }

    private async Task<Response<IReadOnlyCollection<Notification>>> SendEmailConfirmationAsync(User user,
                                                                                                         string email,
                                                                                                         [FromServices] IConfirmationService sendConfirmationService,
                                                                                                         bool isRegistered,
                                                                                                         IReadOnlyCollection<Notification> notifications
                                                                                                         )
    {
        if (user is null)
        {
            var response = await get.GetByEmail(email, RegisterConst.NotePath_01) ?? null!;
            user = response.User ?? null!;
        }

        if (!isRegistered) return new Response<IReadOnlyCollection<Notification>>(notifications.Count > 0 ? notifications : [],
                                                                                                             StatusCodes.Status500InternalServerError, Errors.CreateFail);

        if (!user.EmailConfirmed && isRegistered)
        {
            var urlToken = await sendConfirmationService.BuildToken(user);

            await sendConfirmationService.SendEmailConfirmationAsync(urlToken,
                                        user.Name?.DisplayName!,
                                        user.Email!);
            if (urlToken is null)
                return new Response<IReadOnlyCollection<Notification>>(notifications.Count > 0 ? notifications : [], StatusCodes.Status500InternalServerError, Errors.EmailSendFailed);
            else
                return new Response<IReadOnlyCollection<Notification>>(notifications.Count > 0 ? notifications : [], StatusCodes.Status200OK, Successes.EmailSent);
        }
        return new Response<IReadOnlyCollection<Notification>>(notifications.Count > 0 ? notifications : [], StatusCodes.Status400BadRequest, EmailConst.EmailAlreadyConfirmed);
    }

}