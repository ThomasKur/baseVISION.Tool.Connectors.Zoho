
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class ActionResult
    {

        [JsonProperty(PropertyName = "message")]

        public string Message { get; set; }

        [JsonProperty(PropertyName = "details")]

        public ActionResultDetails Details { get; set; }

        [JsonProperty(PropertyName = "status")]

        public string Status { get; set; }

        [JsonProperty(PropertyName = "code")]

        public string Code { get; set; }

    }
}
