using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Texter.Models
{
    public class Message
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }


        public void Send()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/ACd4cbc6457b1466d2bba396ef1bf8b525/Messages", Method.POST);
            request.AddParameter("To", To);
            request.AddParameter("From", From);
            request.AddParameter("Body", Body);
            request.AddParameter("Status", Status);
            client.Authenticator = new HttpBasicAuthenticator("ACd4cbc6457b1466d2bba396ef1bf8b525", "d45fdac232bd9a4b18ae63a78bdfe4ce");
            client.Execute(request);
        }
    }
}