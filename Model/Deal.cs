using baseVISION.Tool.Connectors.Zoho.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class Deal : IZohoRecord
    {
        [JsonProperty("Owner")]
        public LookupObject Owner { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("$currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("Campaign_Source")]
        public LookupObject CampaignSource { get; set; }

        [JsonProperty("Closing_Date")]
        public DateTimeOffset? ClosingDate { get; set; }

        [JsonProperty("Last_Activity_Time")]
        public DateTimeOffset? LastActivityTime { get; set; }

        [JsonProperty("Modified_By")]
        public LookupObject ModifiedBy { get; set; }
        public bool ShouldSerializeModifiedBy()
        {
            return false;
        }
        [JsonProperty("Lead_Conversion_Time")]
        public Decimal? LeadConversionTime { get; set; }
        public bool ShouldSerializeLeadConversionTime()
        {
            return false;
        }
        [JsonProperty("$process_flow")]
        public bool ProcessFlow { get; set; }
        public bool ShouldSerializeProcessFlow()
        {
            return false;
        }
        [JsonProperty("Deal_Name")]
        public string DealName { get; set; }

        [JsonProperty("Expected_Revenue")]
        public decimal? ExpectedRevenue { get; set; }

        [JsonProperty("Stage")]
        public string Stage { get; set; }

        [JsonProperty("Account_Name")]
        public LookupObject AccountName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
        public bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("$approved")]
        public bool Approved { get; set; }
        public bool ShouldSerializeApproved()
        {
            return false;
        }
        [JsonProperty("$approval")]
        public Approval Approval { get; set; }
        public bool ShouldSerializeApproval()
        {
            return false;
        }
        [JsonProperty("Modified_Time")]
        public DateTimeOffset ModifiedTime { get; set; }
        public bool ShouldSerializeModifiedTime()
        {
            return false;
        }
        [JsonProperty("Created_Time")]
        public DateTimeOffset CreatedTime { get; set; }
        public bool ShouldSerializeCreatedTime()
        {
            return false;
        }
        [JsonProperty("Amount")]
        public long Amount { get; set; }

        [JsonProperty("$followed")]
        public bool Followed { get; set; }
        public bool ShouldSerializeFollowed()
        {
            return false;
        }
        [JsonProperty("Next_Step")]
        public string NextStep { get; set; }

        [JsonProperty("Probability")]
        public decimal Probability { get; set; }

        [JsonProperty("$editable")]
        public bool Editable { get; set; }

        [JsonProperty("Contact_Name")]
        public LookupObject ContactName { get; set; }

        [JsonProperty("Sales_Cycle_Duration")]
        public object SalesCycleDuration { get; set; }
        public bool ShouldSerializeSalesCycleDuration()
        {
            return false;
        }
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Service_Type")]
        public string ServiceType { get; set; }

        [JsonProperty("Lead_Source")]
        public string LeadSource { get; set; }

        [JsonProperty("HarvestEstimateID")]
        public string HarvestEstimateID { get; set; }

        [JsonProperty("HarvestEstimateUrl")]
        public Uri HarvestEstimateUrl { get; set; }
        
        [JsonProperty("Tag")]
        public List<LookupObject> Tag { get; set; }

        [JsonProperty("Created_By")]
        public LookupObject CreatedBy { get; set; }
        public bool ShouldSerializeCreatedBy()
        {
            return false;
        }
    }
}
