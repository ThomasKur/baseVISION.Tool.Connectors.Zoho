using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class Approval
    {
        [JsonProperty("delegate")]
        public bool Delegate { get; set; }

        [JsonProperty("approve")]
        public bool Approve { get; set; }

        [JsonProperty("reject")]
        public bool Reject { get; set; }

        [JsonProperty("resubmit")]
        public bool Resubmit { get; set; }
    }
}
