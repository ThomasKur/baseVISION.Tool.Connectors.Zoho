using baseVISION.Tool.Connectors.Zoho.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class Contact : IZohoRecord
    {
        [JsonProperty("Owner")]
        public LookupObject Owner { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("$currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("Vendor_Name")]
        public LookupObject VendorName { get; set; }

        [JsonProperty("Mailing_Zip")]
        public string MailingZipCode { get; set; }

        [JsonProperty("Reports_To")]
        public string ReportsTo { get; set; }

        [JsonProperty("Other_Phone")]
        public string OtherPhone { get; set; }

        [JsonProperty("Mailing_State")]
        public string MailingState { get; set; }

        [JsonProperty("Twitter")]
        public string Twitter { get; set; }

        [JsonProperty("Mailing_Street")]
        public string MailingStreet { get; set; }
        [JsonProperty("Mailing_Street_2")]
        public string MailingStreet2 { get; set; }
        [JsonProperty("Salutation")]
        public Salutation? Salutation { get; set; }

        [JsonProperty("Last_Activity_Time")]
        
        public DateTimeOffset? LastActivityTime { get; set; }
        public virtual bool ShouldSerializeLastActivityTime()
        {
            return false;
        }
        [JsonProperty("HarvestContactId")]
        public long? HarvestContactId { get; set; }

        [JsonProperty("First_Name")]
        public string FirstName { get; set; }

        [JsonProperty("Full_Name")]
        public string FullName { get; set; }


        [JsonProperty("Asst_Phone")]
        public string AssistantPhone { get; set; }

        [JsonProperty("Modified_By")]
        
        public LookupObject ModifiedBy { get; set; }
        public virtual bool ShouldSerializeModifiedBy()
        {
            return false;
        }
        [JsonProperty("Department")]
        public string Department { get; set; }

        [JsonProperty("Skype_ID")]
        public string SkypeId { get; set; }

        [JsonProperty("$process_flow")]
        
        public bool ProcessFlow { get; set; }
        public virtual bool ShouldSerializeProcessFlow()
        {
            return false;
        }
        [JsonProperty("Assistant")]
        public string Assistant { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Mailing_Country")]
        public string MailingCountry { get; set; }

        [JsonProperty("Account_Name")]
        public LookupObject AccountName { get; set; }

        [JsonProperty("Data_Processing_Basis_Details")]
        
        public string DataProcessingBasisDetails { get; set; }
        public virtual bool ShouldSerializeDataProcessingBasisDetails()
        {
            return false;
        }
        [JsonProperty("id")]
        
        public string Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }
        [JsonProperty("Data_Source")]
        public string DataSource { get; set; }

        [JsonProperty("Email_Opt_Out")]
        public bool EmailOptOut { get; set; }

        [JsonProperty("$approved")]
        
        public bool Approved { get; set; }
        public virtual bool ShouldSerializeApproved()
        {
            return false;
        }
        [JsonProperty("$approval")]
        
        public Approval Approval { get; set; }

        [JsonProperty("Modified_Time")]
        public DateTimeOffset? ModifiedTime { get; set; }

        [JsonProperty("Mailing_City")]
        public string MailingCity { get; set; }


        public virtual bool ShouldSerializeDataSourceDetails()
        {
            return false;
        }
        [JsonProperty("Created_Time")]
        public DateTimeOffset? CreatedTime { get; set; }

        [JsonProperty("$followed")]
        
        public bool Followed { get; set; }
        public virtual bool ShouldSerializeFollowe()
        {
            return false;
        }
        [JsonProperty("Title")]
        public string JobTitle { get; set; }

        [JsonProperty("$editable")]
        
        public bool Editable { get; set; }
        public virtual bool ShouldSerializeEditable()
        {
            return false;
        }
        [JsonProperty("Mobile")]
        public string Mobile { get; set; }

        [JsonProperty("$stop_processing")]
        
        public bool StopProcessing { get; set; }
        public virtual bool ShouldSerializeStopProcessing()
        {
            return false;
        }
        [JsonProperty("Last_Name")]
        public string LastName { get; set; }

        [JsonProperty("Lead_Source")]
        public LeadSource? LeadSource { get; set; }

        [JsonProperty("Created_By")]
        
        public LookupObject CreatedBy { get; set; }
        public virtual bool ShouldSerializeCreatedBy()
        {
            return false;
        }
        [JsonProperty("Tag")]
        public List<LookupObject> Tag { get; set; }

        [JsonProperty("Secondary_Email")]
        public string SecondaryEmail { get; set; }
    }
}
