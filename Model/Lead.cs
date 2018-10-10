using System;
using System.Collections.Generic;
using baseVISION.Tool.Connectors.Zoho.Contracts;
using Newtonsoft.Json;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class Lead : IZohoRecord
    {
        public LookupObject Owner { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        [JsonProperty(PropertyName = "$currency_symbol")]
        public string CurrencySymbol { get; set; }

        public string VisitorScore { get; set; }

        [JsonProperty(PropertyName = "Last_Activity_Time")]
        
        public DateTimeOffset? LastActivityTime { get; set; }
        public virtual bool ShouldSerializeLastActivityTime()
        {
            return false;
        }
        public string Industry { get; set; }

        [JsonProperty(PropertyName = "$converted")]
        
        public bool Converted { get; set; }
        public virtual bool ShouldSerializeConverted()
        {
            return false;
        }
        [JsonProperty(PropertyName = "$process_flow")]
        
        public bool ProcessFlow { get; set; }
        public virtual bool ShouldSerializeProcessFlow()
        {
            return false;
        }
        public string Street { get; set; }
        [JsonProperty(PropertyName = "Street_2")]
        public string Street2 { get; set; }

        [JsonProperty(PropertyName = "Data_Processing_Basis_Details")]
        
        public string DataProcessingBasisDetails { get; set; }
        public virtual bool ShouldSerializeDataProcessingBasisDetails()
        {
            return false;
        }
        [JsonProperty(PropertyName = "Zip_Code")]
        public string ZipCode { get; set; }

        [JsonProperty(PropertyName = "id")]
        
        public string Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }
        public string City { get; set; }

        [JsonProperty(PropertyName = "No_of_Employees")]

        public int? NoOfEmployees { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        [JsonProperty(PropertyName = "Last_Visited_Time")]
        

        public DateTimeOffset? LastVisitedTime { get; set; }
        public virtual bool ShouldSerializeLastVisitedTime()
        {
            return false;
        }
        [JsonProperty(PropertyName = "Created_By")]
        

        public LookupObject CreatedBy { get; set; }

        [JsonProperty(PropertyName = "Annual_Revenue")]

        public int? AnnualRevenue { get; set; }

        [JsonProperty(PropertyName = "Secondary_Email")]

        public string SecondaryEmail { get; set; }

        public string Description { get; set; }
        
        public string Rating { get; set; }

        public string Website { get; set; }

        public string Twitter { get; set; }

        public Salutation? Salutation { get; set; }

        [JsonProperty(PropertyName = "First_Name")]

        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "Full_Name")]

        public string FullName { get; set; }

        [JsonProperty(PropertyName = "Lead_Status")]

        public string LeadStatus { get; set; }

        [JsonProperty(PropertyName = "Modified_By")]
        

        public LookupObject ModifiedBy { get; set; }
        public virtual bool ShouldSerializeModifiedBy()
        {
            return false;
        }
        [JsonProperty(PropertyName = "Skype_ID")]

        public string SkypeId { get; set; }

        public string Phone { get; set; }

        [JsonProperty(PropertyName = "Email_Opt_Out")]
        
        public bool EmailOptOut { get; set; }
        public virtual bool ShouldSerializeEmailOptOut()
        {
            return false;
        }
        [JsonProperty(PropertyName = "Designation")]
        public string JobTitle { get; set; }

        [JsonProperty(PropertyName = "Modified_Time")]
        
        public DateTimeOffset? ModifiedTime { get; set; }
        public virtual bool ShouldSerializeModifiedTime()
        {
            return false;
        }

        public string Mobile { get; set; }

        [JsonProperty(PropertyName = "$stop_processing")]
        

        public bool StopProcessing { get; set; }
        public virtual bool ShouldSerializeStopProcessing()
        {
            return false;
        }
        [JsonProperty(PropertyName = "First_Visited_Time")]
        
        public DateTimeOffset? FirstVisitedTime { get; set; }
        public virtual bool ShouldSerializeFirstVisitedTime()
        {
            return false;
        }
        [JsonProperty(PropertyName = "Last_Name")]

        public string LastName { get; set; }

        
        public string Referrer { get; set; }
        

        [JsonProperty(PropertyName = "Lead_Source")]
        public LeadSource? LeadSource { get; set; }

        public List<LookupObject> Tag { get; set; }

        public string Fax { get; set; }
    }
}
