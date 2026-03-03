

namespace Credence.Application.SharedContext.Constants.EmailNotificationsSender;

public class MudancaSenhaMsg
{
  public const string FrontendUrl = "http://localhost:4200/confirm-email";
  public const string BackendUrl = @$"http://localhost:5093/v1/register/ConfirmEmailAddressAsync";
  public const string Subject = "I.M - Link para recadastramento de senha.";
  public static string PasswordReset(string displayName, string urlFront, string rawToken, string urlBack)
  {

    string passwordReset = $@"
<!DOCTYPE html>
<html lang=""pt-BR"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Redefinição de Senha - I.M Sistema</title>
    <style>
        body {{
            font-family: 'Segoe UI', Arial, sans-serif;
            line-height: 1.6;
            color: #333;
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f9f9f9;
        }}
        .container {{
            background-color: #ffffff;
            border-radius: 8px;
            padding: 30px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            border: 1px solid #e1e1e1;
        }}
        .header {{
            text-align: center;
            margin-bottom: 25px;
            border-bottom: 1px solid #eeeeee;
            padding-bottom: 20px;
        }}
        .logo {{
            color: #0556cb;
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 10px;
        }}
        .title {{
            font-size: 20px;
            font-weight: 600;
            margin: 15px 0;
            color: #1a1a1a;
        }}
        .content {{
            margin: 20px 0;
        }}
        .link-container {{
            background-color: #f0f7ff;
            border: 1px dashed #0556cb;
            border-radius: 6px;
            padding: 20px;
            text-align: center;
            margin: 25px 0;
        }}
        .reset-link {{
            display: inline-block;
            background-color: #0556cb;
            color: white;
            padding: 12px 24px;
            text-decoration: none;
            border-radius: 4px;
            font-weight: bold;
            margin: 10px 0;
        }}
        .reset-link:hover {{
            background-color: #0444a8;
        }}
        .warning {{
            color: #d32f2f;
            font-weight: 600;
            margin: 15px 0;
            background-color: #ffebee;
            padding: 10px;
            border-radius: 4px;
            border-left: 4px solid #d32f2f;
        }}
        .footer {{
            margin-top: 30px;
            padding-top: 20px;
            border-top: 1px solid #eeeeee;
            font-size: 14px;
            color: #666;
        }}
        .greeting {{
            font-weight: bold;
            margin-bottom: 15px;
        }}
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""header"">
            <div class=""logo"">I.M Sistema</div>
            <h1 class=""title"">Redefinição de Senha</h1>
        </div>
        
        <div class=""content"">
            <p class=""greeting"">Olá {displayName},</p>
            
            <p>Recebemos uma solicitação para redefinir a senha da sua conta no <strong>I.M – Sistema de Gestão de Ordens de Serviço</strong>.</p>
            
            <p>Para continuar com a recuperação de acesso, clique no botão abaixo e siga as instruções para criar uma nova senha:</p>
            
            <div class=""link-container"">
                <a href=""{urlFront}{rawToken.Replace(urlBack, "")}"" class=""reset-link"">
                    🔗 REDEFINIR MINHA SENHA
                </a>
                <p style=""margin-top: 10px; font-size: 14px; color: #666;"">
                    Ou copie e cole este link no seu navegador:<br>
                    <span style=""word-break: break-all;"">{urlFront}{rawToken.Replace(urlBack, "")}</span>
                </p>
            </div>
            
            <div class=""warning"">
                ⚠️ Este link é válido por tempo limitado 10 minutos e deve ser utilizado apenas por você.
            </div>
            
            <p>Se você não solicitou essa recuperação, recomendamos que ignore este e-mail. Nenhuma alteração será feita na sua conta sem sua autorização.</p>
            
            <p>O <strong>I.M</strong> está comprometido com a segurança e a praticidade no seu dia a dia. Se tiver qualquer dúvida ou dificuldade, nossa equipe de suporte está à disposição para ajudar.</p>
        </div>
        
        <div class=""footer"">
            <p><strong>Atenciosamente,</strong><br>
            Equipe I.M<br>
            <a href=""mailto:suporte@im.com.br"">suporte@im.com.br</a></p>
        </div>
    </div>
</body>
</html>";

    return passwordReset;

  }

}