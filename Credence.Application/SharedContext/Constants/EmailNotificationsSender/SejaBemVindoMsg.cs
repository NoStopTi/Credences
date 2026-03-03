

namespace Credence.Application.SharedContext.Constants.EmailNotificationsSender;

public class SejaBemVindoMsg
{
  public const string FrontendUrl = "http://localhost:4200/confirm-email";
  public const string BackendUrl = @$"http://localhost:5093/v1/register/ConfirmEmailAddressAsync";
  public const string Subject = "I.M - Link para confirmação de e-mail";
  public static string SejaBemVindo(string displayName, string urlFront, string rawToken, string urlBack)
  {
    string sejaBemVindo = $@"
            <!DOCTYPE html>
            <html lang='pt-BR'>
            <head>
              <meta charset='UTF-8'>
              <title>Bem-vindo ao I.M</title>
              <style>
                body {{
                  font-family: Arial, sans-serif;
                  color: #333;
                  line-height: 1.6;
                  padding: 20px;
                }}
                .button {{
                  display: inline-block;
                  padding: 12px 20px;
                  margin: 20px 0;
                  background-color: #007bff;
                  color: white;
                  text-decoration: none;
                  border-radius: 5px;
                }}
                .footer {{
                  margin-top: 40px;
                  font-size: 0.9em;
                  color: #666;
                }}
              </style>
            </head>
            <body>
              <p>Olá <strong>{displayName}</strong>,</p>
            
              <p>Seja muito bem-vindo ao <strong>I.M</strong>, o seu novo sistema de gestão de ordens de serviço!</p>
            
              <p>Estamos felizes por tê-lo conosco. Este e-mail confirma que o endereço utilizado no cadastro está correto e ativo. Para concluir seu registro e começar a usar o sistema, basta clicar no botão abaixo:</p>
            
              <p><a href='{urlFront}{rawToken.Replace(urlBack, "")}' class='button'>Confirmar e-mail</a></p>
            
              <p>O I.M foi criado para tornar sua rotina mais eficiente, organizada e segura. A partir de agora, você poderá acompanhar suas ordens de serviço com mais agilidade e controle.</p>
            
              <p>Se você não realizou esse cadastro, por favor ignore este e-mail.</p>
            
              <p>Ficou com alguma dúvida? Nossa equipe está pronta para ajudar.</p>
            
              <div class='footer'>
                <p>Atenciosamente,<br>
                Equipe I.M<br>
                <a href='mailto:suporte@im.com.br'>suporte@im.com.br</a></p>
              </div>
            </body>
            </html>";
    return sejaBemVindo;
  }
}