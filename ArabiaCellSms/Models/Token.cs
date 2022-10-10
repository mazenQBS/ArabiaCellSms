using Newtonsoft.Json;

namespace ArabiaCellSms.Models;

public class Token
{
    [JsonProperty(PropertyName = "token")]
    public string Value { get; set; }
}