
using System.Text.Json.Serialization;
using Credence.Default.ApiContext.Configurations;



namespace Credence.Application.SharedContext.Responses;

public sealed class Response<TData>
{
    private readonly int _code;

    [JsonConstructor]
    public Response()
    => _code = ApiSettings.DefaultStatusCode;

    public Response(
        TData? data,
        int code = ApiSettings.DefaultStatusCode,
        string? message = null!
    )
    {
        Data = data;
        Message = message;
        _code = code;

        if (!IsSuccess)
            Console.WriteLine(message);

    }

    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
}