
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class ActionResultDetails
    {
        [JsonProperty(PropertyName = "created_by")]

        public LookupObject CreatedBy { get; set; }

        [JsonProperty(PropertyName = "id")]

        public string Id { get; set; }

        [JsonProperty(PropertyName = "modified_by")]

        public LookupObject ModifiedBy { get; set; }

        [JsonProperty(PropertyName = "modified_time")]

        public DateTimeOffset ModifiedTime { get; set; }

        [JsonProperty(PropertyName = "created_time")]

        public DateTimeOffset CreatedTime { get; set; }
    }
}
