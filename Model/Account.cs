using baseVISION.Tool.Connectors.Zoho.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class Account : IZohoRecord
    {
        [JsonProperty("Owner")]
        public LookupObject Owner { get; set; }
        public virtual bool ShouldSerializeOwner()
        {
            return false;
        }
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("$currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("Account_Type")]
        public AccountType? AccountType { get; set; }

        [JsonProperty("Second_Account_Type")]
        public AccountType? SecondAccountType { get; set; }

        [JsonProperty("Rating")]
        public AccountRating? Rating { get; set; }

        [JsonProperty("HarvestCompanyId")]
        public long? HarvestCompanyId { get; set; }

        [JsonProperty("Website")]
        public Uri Website { get; set; }

        [JsonProperty("Employees")]
        public long? Employees { get; set; }

        [JsonProperty("Last_Activity_Time")]
        
        public DateTimeOffset? LastActivityTime { get; set; }
        public virtual bool ShouldSerializeLastActivityTime()
        {
            return false;
        }
        [JsonProperty("Industry")]
        public Industry? Industry { get; set; }

        [JsonProperty("Modified_By")]
        
        public LookupObject ModifiedBy { get; set; }
        public virtual bool ShouldSerializeModifiedBy()
        {
            return false;
        }
        [JsonProperty("$process_flow")]
        
        public bool ProcessFlow { get; set; }
        public virtual bool ShouldSerializeProcessFlow()
        {
            return false;
        }
        [JsonProperty("Billing_Country")]
        public string BillingCountry { get; set; }

        [JsonProperty(PropertyName = "Account_Name")]
        public string CompanyName { get; set; }

        [JsonProperty("id")]
        
        public string Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("O365TeamsUrl")]
        public Uri O365TeamsUrl { get; set; }

        [JsonProperty("Account_Number")]
        public long? AccountNumber { get; set; }

        [JsonProperty("$approved")]
        
        public bool Approved { get; set; }
        public virtual bool ShouldSerializeApproved()
        {
            return false;
        }
        [JsonProperty("Ticker_Symbol")]
        public string TickerSymbol { get; set; }

        [JsonProperty("$approval")]
        
        public Approval Approval { get; set; }
        public virtual bool ShouldSerializeApproval()
        {
            return false;
        }
        [JsonProperty("Modified_Time")]
        public DateTimeOffset? ModifiedTime { get; set; }
        public virtual bool ShouldSerializeModifiedTime()
        {
            return false;
        }
        [JsonProperty("Billing_Street")]
        public string BillingStreet { get; set; }
        [JsonProperty("Billing_Street_2")]
        public string BillingStreet2 { get; set; }

        [JsonProperty("Created_Time")]
        public DateTimeOffset? CreatedTime { get; set; }
        public virtual bool ShouldSerializeCreatedTime()
        {
            return false;
        }

        [JsonProperty("$followed")]
        
        public bool Followed { get; set; }
        public virtual bool ShouldSerializeFollowed()
        {
            return false;
        }
        [JsonProperty("$editable")]
        
        public bool Editable { get; set; }
        public virtual bool ShouldSerializeEditable()
        {
            return false;
        }
        [JsonProperty("Billing_Code")]
        public string BillingZipCode { get; set; }

        [JsonProperty("Parent_Account")]
        public LookupObject ParentAccount { get; set; }

        [JsonProperty("Billing_City")]
        public string BillingCity { get; set; }

        [JsonProperty("Billing_State")]
        public string BillingState { get; set; }

        [JsonProperty("Created_By")]
        
        public LookupObject CreatedBy { get; set; }
        public virtual bool ShouldSerializeCreatedBy()
        {
            return false;
        }
        [JsonProperty("Tag")]
        public List<LookupObject> Tag { get; set; }

        [JsonProperty("Annual_Revenue")]
        public long? AnnualRevenue { get; set; }

        [JsonProperty("Days_since_last_Timereport")]
        public long? DaysSinceLastTimereport { get; set; }

        [JsonProperty("Azure_Tenant_ID")]
        public string AzureTenantID { get; set; }

        [JsonProperty("Azure_AD_Primary_Domain_Name")]
        public string AzureADPrimaryDomainName { get; set; }

        [JsonProperty("Signed_NDA")]
        public DateTimeOffset? SignedNDA { get; set; }
        
    }
}
