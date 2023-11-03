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
        
        var cookieOfLogin = new System.Net.Cookie(account.Login, $"{account.Login}");
        var cookieOfPassword = new System.Net.Cookie(account.Password, $"{account.Password}");
        
        _cookieContainer.Add(_domain,cookieOfLogin);
        _cookieContainer.Add(_domain,cookieOfPassword);
        
        Console.WriteLine("Cookies has been added.");
    }

    public static bool IsExistCookieByProps(string firstName, string secondName)
    {
        return _cookieContainer.GetAllCookies()
            .Where(x => x.Name == firstName || x.Name == secondName)
            .ToList() == null;
    }
}