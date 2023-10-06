using HttpServerBattleNet.Attribuets;
using HttpServerBattleNet.Model;
using HttpServerBattleNet.Services;

namespace HttpServerBattleNet.Controllers;

[Controller("Authorize")]
public class AuthorizeController
{
    [Post("SendToEmail")]
    public void SendToEmail(string emailFromUser, string passwordFromUser)
    {
        new EmailSenderService().SendEmail(emailFromUser, passwordFromUser, "");
        Console.WriteLine("Email has been sent.");
    }
    
    [Get("GetEmailList")]
    public string GetEmailList()
    {
        var htmlCode = "<html><head></head><body><h1>Вы вызвали GetEmailList</h1></body></html>";
        return htmlCode;
    }
    
    [Get("GetAccountsList")]
    public Account[] GetAccountsList()
    {
        var accounts = new[]
        {
            new Account(){Email = "email-1", Password = "password-1"},
            new Account(){Email = "email-2", Password = "password-2"},
        };
        
        return accounts;
    }
}