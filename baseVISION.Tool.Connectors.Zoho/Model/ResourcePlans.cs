using baseVISION.Tool.Connectors.Zoho.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class ResourcePlans : IZohoRecord
    {

        [JsonProperty("Created_By")]
        public LookupObject CreatedBy { get; set; }
        public virtual bool ShouldSerializeCreatedBy()
        {
            return false;
        }

        [JsonProperty("Deal")]
        public LookupObject Deal { get; set; }
        public virtual bool ShouldSerializeDeal()
        {
            return false;
        }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Job_Role")]
        public string JobRole { get; set; }
        [JsonProperty("Preferred_Employee")]
        public LookupObject Preferred_Employee { get; set; }
        public string Employee { get { return this.Preferred_Employee.Name; } }

        [JsonProperty("Estimated_Effort_in_Days")]
        public int EstimatedEffortInDays { get; set; }
        [JsonProperty("Estimated_End")]
        public DateTime EstimatedEnd { get; set; }
        [JsonProperty("Estimated_Start")]
        public DateTime EstimatedStart { get; set; }

        [JsonProperty("Owner")]
        public LookupObject Owner { get; set; }

        [JsonProperty("Modified_By")]
        public LookupObject ModifiedBy { get; set; }
        public virtual bool ShouldSerializeModifiedBy()
        {
            return false;
        }

        [JsonProperty("id")]

        public string Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }

    }
}
