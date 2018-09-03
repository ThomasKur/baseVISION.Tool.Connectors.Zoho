using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class ResponseInfo
    {
        [JsonProperty(PropertyName = "call")]

        public bool Call { get; set; }

        [JsonProperty(PropertyName = "per_page")]

        public long PerPage { get; set; }

        [JsonProperty(PropertyName = "count")]

        public long Count { get; set; }

        [JsonProperty(PropertyName = "page")]

        public long Page { get; set; }

        [JsonProperty(PropertyName = "email")]

        public bool Email { get; set; }

        [JsonProperty(PropertyName = "more_records")]

        public bool MoreRecords { get; set; }
    }
}
