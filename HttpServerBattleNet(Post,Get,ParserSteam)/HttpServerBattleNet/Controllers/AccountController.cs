using HttpServerBattleNet.Attribuets;
using HttpServerBattleNet.Cookie;
using HttpServerBattleNet.Model;
using MyDatabase;

namespace HttpServerBattleNet.Controllers;

[Controller("Account")]
public class AccountController
{
    private readonly MyDataContext _context = 
        new("User ID=postgres;Password=root;Host=localhost;Port=5432;Database=myhttpserver;");
    
    [Get("GetAccountById")]
    public Account GetAccountById(int id)
    {
        var account = _context.SelectById<Account>(id); 
        var access = CookieApply.IsExistCookieByProps(account.Login, account.Password);

        return access ? account : new Account(){Login = "key", Password = "not found"};
    }
}