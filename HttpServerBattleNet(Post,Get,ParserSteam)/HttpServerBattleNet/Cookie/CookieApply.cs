using HttpServerBattleNet.Model;
using System.Net;
using System.Reflection;

namespace HttpServerBattleNet.Cookie;

public class CookieApply
{
    private static Uri _domain = new Uri("http://127.0.0.1:2323/authorize/login");
    private static CookieContainer _cookieContainer = new CookieContainer();
    public static void CreateCookieForAccount(Account account)
    {
        
        var cookieOfLogin = new System.Net.Cookie(nameof(account.Login), $"{account.Login}");
        var cookieOfPassword = new System.Net.Cookie(nameof(account.Password), $"{account.Password}");
        
        _cookieContainer.Add(_domain,cookieOfLogin);
        _cookieContainer.Add(_domain,cookieOfPassword);
        
        Console.WriteLine("Cookies has been added.");
    }

    public static bool IsExistCookieByProps(Account account)
    {
        var cookies = _cookieContainer.GetAllCookies();
        var currentCookie = cookies
            .Where(x =>
                x.Name == nameof(account.Login) || x.Name == nameof(account.Password) 
                                                && x.Value == account.Login || x.Value == account.Password)
            .ToList();
        return currentCookie.Count != 0;
    }
}