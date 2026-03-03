using Credence.Default.Constants.EmailContext;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;


namespace Credence.Application.AuthContext.UseCases.Responses;

public class JwtToken
{
    public JwtToken(
        bool authenticated,
        DateTime expires,
        string token,
        string email,
        Guid userId,
        bool isEnable2FA
        )
    {
        Authenticated = authenticated;
        Expires = expires;
        Token = token;
        Email = email;
        UserId = userId;
        IsEnable2FA = isEnable2FA;
    }

    public bool Authenticated { get; private set; }
    public DateTime Expires { get; private set; }
    public string Token { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public Guid UserId { get; private set; }
    public bool IsEnable2FA { get; private set; } = false;
    // public Guid CompanyId { get; private set; }
    // public IList<string> Roles { get; private set; } = Array.Empty<string>();


    public JwtToken BuildJwtToken()
    {
        return new JwtToken(
                            Authenticated,
                            Expires,
                            Token,
                            Email,
                            UserId,
                            IsEnable2FA
                            );
    }

    public static JwtToken CreateResponseLoginFailed()
    {
        return new JwtToken(
                             false,
                             DateTime.MinValue,
                             IdentityConst.UnableGenerateToken,
                             EmailConst.InvalidEmail,
                             new Guid(),
                             false
        );
    }

}