using Newtonsoft.Json;

namespace MyHttpServer;

public class HttpListener
{
    private HttpListener _listener;
    private bool _running = false;

    public HttpListener()
    {
        _listener = new HttpListener();
    }

    public void Start()
    {
        var threadServer = new Thread(new ThreadStart(Run));
        threadServer.Start();
    }

    private async Task Run()
    {
        _running = true;
        var config = await GetConnectConfigurationServer("appsettings.json");
        _listener
        _listener.Start();;
    }

    private async Task<AppSettingsConfig> GetConnectConfigurationServer(string fileName)
    {
        try
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл appsettings.json не найден");
                throw new FileNotFoundException();
            }
            
            var json = await File.OpenText(fileName).ReadToEndAsync();
            return JsonConvert.DeserializeObject<AppSettingsConfig>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}