using System.Text.Json.Serialization;
using Credence.Application.SharedContext.Responses;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;


namespace Credence.Application.UserContext.TwoFactor.UseCases.Responses;

public class OnOffCodeViaEmailResponse
{
    public OnOffCodeViaEmailResponse(){}
    public OnOffCodeViaEmailResponse(bool onOff)
    {
        CurrentState = onOff;
    }

    [JsonIgnore]
    private List<Notification> notifications { get; set; } = new List<Notification>();
    public IReadOnlyCollection<Notification> Notifications => notifications;

    public void AddNotifications(List<Notification> notifications)
    {
        notifications.AddRange(notifications);
    }
    public bool CurrentState { get; private set; }


    public Response<OnOffCodeViaEmailResponse> BuilderOnOffCodeViaEmailResponse(bool onOff, List<Notification> notifications)
    {
        var response = new OnOffCodeViaEmailResponse(onOff);

        response.AddNotifications(notifications.ToList());

        return new Response<OnOffCodeViaEmailResponse>(response, notifications.Count > 0
                                                        ? StatusCodes.Status400BadRequest
                                                        : StatusCodes.Status200OK);
    }


}