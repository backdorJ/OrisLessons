using Newtonsoft.Json;

namespace HttpServerBattleNet.Configuration;

public class AppSettingsConfig
{
    [JsonProperty("address")]
    public string Address { get; set; }
    
    [JsonProperty("port")]
    public uint Port { get; set; }

    [JsonProperty("static_files_path")]
    public string StaticPathFiles { get; set; }
}