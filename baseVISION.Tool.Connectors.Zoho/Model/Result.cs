
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class Result<T>
    {
        [JsonProperty(PropertyName = "data")]

        public List<T> Data { get; set; }

        [JsonProperty(PropertyName = "info")]

        public ResponseInfo Info { get; set; }
    }
}
