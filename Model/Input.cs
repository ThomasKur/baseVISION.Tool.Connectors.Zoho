
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class Input<T>
    {
        public Input()
        {
            Data = new List<T>();
            trigger = new List<string>();
        }
        [JsonProperty(PropertyName = "data")]

        public List<T> Data { get; set; }

        [JsonProperty(PropertyName = "trigger")]

        public List<string> trigger { get; set; }
    }
}
