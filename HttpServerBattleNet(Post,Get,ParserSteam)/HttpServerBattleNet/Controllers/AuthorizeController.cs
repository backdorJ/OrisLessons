using HttpServerBattleNet.Attribuets;
using HttpServerBattleNet.Cookie;
using HttpServerBattleNet.Model;
using HttpServerBattleNet.Services;
using MyDatabase;

namespace HttpServerBattleNet.Controllers;

[Controller("Authorize")]
public class AuthorizeController
{
    private readonly MyDataContext _context = new("User ID=postgres;Password=root;Host=localhost;Port=5432;Database=myhttpserver;");
    
    [Post("SendToEmail")]
    public void SendToEmail(string emailFromUser, string passwordFromUser)
    {
        new EmailSenderService().SendEmail(emailFromUser, passwordFromUser, "");
        Console.WriteLine("Email has been sent.");
    }
    
    [Get("GetEmailList")]
    public string GetEmailList()
    {
        var htmlCode = "<h1>You are open GetEmailList method</h1>";
        return htmlCode;
    }
    
    [Get("GetAccountsList")]
    public Account[] GetAccountsList()
    {
        var accounts = new[]
        {
            new Account(){Login = "email-1", Password = "password-1"},
            new Account(){Login = "email-2", Password = "password-2"},
        };
        
        return accounts;
    }

    [Post("Login")]
    public void Login(string login, string password)
    {
        var accounts = _context.Select(new Account());
        var account = accounts.FirstOrDefault(account =>
            account.Password == password && account.Login == login);

        if (account == null)
        {
            Console.WriteLine("Account not found");
            return;
        }

        CookieApply.CreateCookieForAccount(account!);
    }
}