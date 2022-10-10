using ArabiaCellSms.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

//Username = "unicef_HDT",
//Password = "Tdh@36fcn#$"


namespace ArabiaCellSms.Controllers
{

    public class ArabiaCellSmsApiController : Controller
    {

        public async Task<ActionResult> SendSms()

        {
            var u = new SmsDto()
            {
                Username = "unicef_HDT",
                Password = "Tdh@36fcn#$",
                Msisdn = "00962799932764",
                Header = "ma",
                Text = "hi",
                MessageTypeId = 1
            };


            SendSmsf(u);


            return View();
        }
        //please rename this function
        public void SendSmsf(SmsDto smsDto)
        {
            var userLogin = new LoginModel
            {
                Username = smsDto.Username,
                Password = smsDto.Password
            };


            var data = new Data1
            {
                Msisdn = smsDto.Msisdn,
                Text = smsDto.Text,
                Header = smsDto.Header,
                MessageTypeId = smsDto.MessageTypeId
            };

            var sms = new Sms { Data = data };



            SendSms(userLogin, sms);

        }

        [HttpPost]
        public async Task<string> SendSms(LoginModel login, Sms sms)
        {

            using var client = new HttpClient();


            using var authRequest = AddApiLink("POST", ArabiaCellApiLink.Authentication);

            AddContent(authRequest, login);
            SetContentType(authRequest, "application/json");

            var authApiResponse = await client.SendAsync(authRequest).ConfigureAwait(false);
            var token = await authApiResponse.Content.ReadAsStringAsync();



            using var request = AddApiLink("POST", ArabiaCellApiLink.SendSms);

            AddAuthorizationHeader(request, GetTokenValue(token));
            AddContent(request, sms);
            SetContentType(request, "application/json");

            var response = await client.SendAsync(request);
            var smsApiResponse = await response.Content.ReadAsStringAsync();



            return smsApiResponse;

        }


        private static void AddContent<TType>(HttpRequestMessage request, TType type)
            => request.Content = new StringContent(ConvertToJson(type));

        private static void SetContentType(HttpRequestMessage request, string type)
            => request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(type);

        private static void AddAuthorizationHeader(HttpRequestMessage request, Token tokenValue)
            => request.Headers.TryAddWithoutValidation("Authorization", tokenValue.Value);

        private static HttpRequestMessage AddApiLink(string method, string apiLink)
            => new(new HttpMethod(method), apiLink);

        private static Token GetTokenValue(string token)
            => JsonConvert.DeserializeObject<Token>(token);

        private static string ConvertToJson<TType>(TType obj)
            => JsonConvert.SerializeObject(obj);



    }
}

