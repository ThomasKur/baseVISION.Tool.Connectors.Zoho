
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Zoho
{
    public class ZohoTokenInformation
    {
        [JsonProperty(PropertyName =  "access_token")]
        public string AccessToken { get; set; }
        [JsonProperty(PropertyName =  "api_domain")]
        public string ApiDomain { get; set; }
        [JsonProperty(PropertyName =  "token_type")]
        public string TokenType { get; set; }
        [JsonProperty(PropertyName =  "expires_in_sec")]
        public int ExpiresIn {
            get { try { return Convert.ToInt32((ExpiryTime - DateTime.Now).TotalSeconds); } catch { return 0; }  }
            set { if (ExpiryTime == default(DateTime)) { ExpiryTime = DateTime.Now.AddSeconds(value); }; }
        }
        public DateTime ExpiryTime { get; protected set; }

    }
}
