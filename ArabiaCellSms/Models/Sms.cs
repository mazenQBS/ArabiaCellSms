using Newtonsoft.Json;

namespace ArabiaCellSms.Models;





public class Sms
{
    [JsonProperty(PropertyName = "data1")]
    public Data1 Data { get; set; }
}

public class Data1
{
    [JsonProperty(PropertyName = "msisdn")]
    public string Msisdn { get; set; }

    [JsonProperty(PropertyName = "text")]
    public string Text { get; set; }

    [JsonProperty(PropertyName = "header")]
    public string Header { get; set; }

    [JsonProperty(PropertyName = "messageTypeId")]
    public int MessageTypeId { get; set; }
}
