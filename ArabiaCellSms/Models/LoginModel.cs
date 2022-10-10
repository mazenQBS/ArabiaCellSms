using Newtonsoft.Json;

namespace ArabiaCellSms.Models
{
    public class LoginModel
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}