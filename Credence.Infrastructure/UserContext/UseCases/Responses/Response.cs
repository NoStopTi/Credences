
using System.Text.Json.Serialization;
using Credence.Default.ApiContext.Configurations;
using Credence.Domain.UserContext.Entities;
using Flunt.Notifications;



namespace Credence.Infrastructure.UserContext.UseCases.Responses;

public sealed class Response : Notifiable<Notification>
{
    private readonly int _code;

    [JsonConstructor]
    public Response()
    => _code = ApiSettings.DefaultStatusCode;

    public Response(
        User? user,
        int code = ApiSettings.DefaultStatusCode,
        string? message = null!
    )
    {
        User = user;
        Message = message;
        _code = code;

        if (!IsSuccess)
            Console.WriteLine(message);
    }

    public User? User { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
}