﻿using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SoloProject.Models
{
    public class Message
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }


        public void Send()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01/");
            var request = new RestRequest("Accounts/AC511da8b64e69517082a8911962dfab8c/Messages", Method.POST);
            request.AddParameter("To", To);
            request.AddParameter("From", From);
            request.AddParameter("Body", Body);
            client.Authenticator = new HttpBasicAuthenticator("AC511da8b64e69517082a8911962dfab8c", "b07f4c2a9aaeac2f4d1feee0643dd25b");
            client.Execute(request);
        }
    }
}