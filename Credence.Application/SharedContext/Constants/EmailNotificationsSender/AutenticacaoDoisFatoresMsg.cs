

namespace Credence.Application.SharedContext.Constants.EmailNotificationsSender;

public class AutenticacaoDoisFatoresMsg
{
  public const string Subject = "I.M: Autenticação de dois fatores.";

  public static string TwoFactorAuthentication(string TokenConfirmationUrl)
  {

    string styleCss = @"
          body {
            font-family: 'Segoe UI', Arial, sans-serif;
            line-height: 1.6;
            color: #333;
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f9f9f9;
        }
        .container {
            background-color: #ffffff;
            border-radius: 8px;
            padding: 30px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            border: 1px solid #e1e1e1;
        }
        .header {
            text-align: center;
            margin-bottom: 25px;
            border-bottom: 1px solid #eeeeee;
            padding-bottom: 20px;
        }
        .logo {
            color: #0556cb;
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 10px;
        }
        .title {
            font-size: 20px;
            font-weight: 600;
            margin: 15px 0;
            color: #1a1a1a;
        }
        .code-container {
            background-color: #f0f7ff;
            border: 1px dashed #0556cb;
            border-radius: 6px;
            padding: 20px;
            text-align: center;
            margin: 25px 0;
        }
        .verification-code {
            font-size: 42px;
            font-weight: bold;
            letter-spacing: 5px;
            color: #0556cb;
            margin: 15px 0;
        }
        .info-box {
            background-color: #f8f9fa;
            border-left: 4px solid #0556cb;
            padding: 15px;
            margin: 20px 0;
            border-radius: 0 4px 4px 0;
        }
        .details-grid {
            display: grid;
            grid-template-columns: 1fr;
            gap: 12px;
            margin: 20px 0;
        }
        .detail-item {
            display: flex;
        }
        .detail-label {
            font-weight: 600;
            min-width: 120px;
        }
        .footer {
            margin-top: 30px;
            padding-top: 20px;
            border-top: 1px solid #eeeeee;
            font-size: 14px;
            color: #666;
            text-align: center;
        }
        .warning {
            color: #d32f2f;
            font-weight: 600;
            margin: 15px 0;
        }
        .support-link {
            color: #0556cb;
            text-decoration: none;
        }
        .support-link:hover {
            text-decoration: underline;
        }
        @media (max-width: 480px) {
            body {
                padding: 10px;
            }
            .container {
                padding: 20px 15px;
            }
            .verification-code {
                font-size: 36px;
                letter-spacing: 3px;
            }
        }
       ";

    string htmlString = @$"
<!DOCTYPE html>
<html lang=""pt-BR"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <style>
     {styleCss}
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""header"">
            <div class=""logo"">I.M Integrações</div>
            <h1 class=""title"">Autenticação de Login 2FA</h1>
        </div>
        
        <p>Use o código abaixo para autenticar sua tentativa de login.</p>
  

        <div class=""code-container"">
            <div class=""verification-code"">{TokenConfirmationUrl}</div>
            <p>O código permanecerá válido pelos próximos 10 minutos.</p>
        </div>
        
        <div class="" warning"">⚠️ Não compartilhe este código com ninguém.</div>
        
        <p>Se você não reconhece esta tentativa de login, ignore este e-mail e verifique a segurança de sua conta.</p>
        
        <div class=""footer"">
            <p><strong>I.M Integrações</strong><br>
            Caso tenha fechado a tela apos o login.  <a href=""http://localhost:4200/two-factor-check"" class=""support-link"">Clique aqui</a>.</p>
        </div>
    </div>
</body>
</html>";

    return htmlString;
  }

}