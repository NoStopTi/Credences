

using Credence.Default.Constants.PasswordContext;

namespace Credence.Application.SharedContext.Constants.EmailNotificationsSender;

public class ContaUsuarioBloqueada
{
  public const string FrontendUrl = "http://localhost:4200/change-password";
  public const string Subject = "I.M - Conta de usuário bloqueada.";

  public static string AccountTemporarilyBlockedMessage(string displayName, string urlFront, string lockoutTime)
  {
    string blockedMessage = $@"
<!DOCTYPE html>
<html lang='pt-BR'>
<head>
  <meta charset='UTF-8'>
  <title>Conta Temporariamente Bloqueada - I.M</title>
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
      background-color: #ffc107;
      color: #000;
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

  <p>Sua conta foi <strong>temporariamente bloqueada</strong> após exceder o limite de 
  <strong>{PasswordConst.PwdMaxLoginFailed} tentativas de login com senha incorreta</strong>.</p>

  <p>Por motivos de segurança, o acesso ficará bloqueado por <strong>{lockoutTime} Horas</strong>.</p>

  <p>Após esse período, você poderá tentar acessar o sistema novamente normalmente.</p>

  <p>Se preferir, você também pode redefinir sua senha clicando no botão abaixo:</p>

  <p><a href='{urlFront}/redefinir-senha' class='button'>Redefinir Senha</a></p>

  <p>Se você não reconhece essa tentativa de acesso, recomendamos entrar em contato com nossa equipe de suporte.</p>

  <div class='footer'>
    <p>Atenciosamente,<br>
    Equipe I.M<br>
    <a href='mailto:suporte@im.com.br'>suporte@im.com.br</a></p>
  </div>
</body>
</html>";

    return blockedMessage;
  }

public static string AccountPermanentlyBlockedMessage(string displayName, string urlFront)
{
    string blockedMessage = $@"
<!DOCTYPE html>
<html lang='pt-BR'>
<head>
  <meta charset='UTF-8'>
  <title>Conta Bloqueada - I.M</title>
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
      background-color: #dc3545;
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

  <p>Sua conta foi <strong>bloqueada definitivamente</strong> após múltiplas tentativas de login com senha incorreta.</p>

  <p>Por motivos de segurança, o acesso ao sistema foi desativado e será necessário realizar uma nova definição de senha.</p>

  <p>Para recuperar o acesso, utilize a opção <strong>“Esqueci minha senha”</strong> clicando no botão abaixo:</p>

  <p><a href='{urlFront}/esqueci-minha-senha' class='button'>Esqueci Minha Senha</a></p>

  <p>Se você não reconhece essa atividade, recomendamos que entre em contato com nossa equipe de suporte imediatamente.</p>

  <p>Estamos comprometidos em manter sua conta segura.</p>

  <div class='footer'>
    <p>Atenciosamente,<br>
    Equipe I.M<br>
    <a href='mailto:suporte@im.com.br'>suporte@im.com.br</a></p>
  </div>
</body>
</html>";

    return blockedMessage;
}
}