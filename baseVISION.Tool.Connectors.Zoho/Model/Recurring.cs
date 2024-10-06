using baseVISION.Tool.Connectors.Zoho.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class Recurring : IZohoRecord
    {
        [JsonProperty("$approval")]
        public Approval Approval { get; set; }
        public virtual bool ShouldSerializeApproval()
        {
            return false;
        }

        [JsonProperty("$approved")]
        public bool Approved { get; set; }
        public virtual bool ShouldSerializeApproved()
        {
            return false;
        }

        [JsonProperty("Account")]
        public LookupObject Account { get; set; }

        [JsonProperty("Active")]
        public bool Active { get; set; }

        [JsonProperty("Autorenewal")]
        public bool Autorenewal { get; set; }

        [JsonProperty("Autorenewal_Period_Months")]
        public AutoRenewalPeriod? AutorenewalPeriodMonths { get; set; }

        [JsonProperty("Billing_Model")]
        public SocBillingModel? SocBillingModel { get; set; }

        [JsonProperty("CC_Covered_Products")]
        public List<CCProducts> CCCoveredProducts { get; set; }

        [JsonProperty("CC_Level")]
        public CCLevel? ConnectedCareLevel { get; set; }

        [JsonProperty("CC_Tasks")]
        public bool ConnectedCareTasks { get; set; }

        [JsonProperty("Calculated_Price")]
        public Decimal? CalculatedPrice { get; set; }

        [JsonProperty("Comment")]
        public String? Comment { get; set; }

        [JsonProperty("Created_By")]
        public LookupObject CreatedBy { get; set; }
        public virtual bool ShouldSerializeCreatedBy()
        {
            return false;
        }

        [JsonProperty("Created_Time")]
        public DateTimeOffset? CreatedTime { get; set; }
        public virtual bool ShouldSerializeCreatedTime()
        {
            return false;
        }

        [JsonProperty("$currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("Currency1")]
        public Currency? Currency { get; set; }

        [JsonProperty("Deal")]
        public LookupObject Deal { get; set; }

        [JsonProperty("Initial_Period")]
        public InitialPeriod? InitialPeriodMonths { get; set; }

        [JsonProperty("EmailInvoiceAddress")]
        public String? EmailInvoiceAddress { get; set; }

        [JsonProperty("End_Date")]
        public DateTimeOffset? EndDate { get; set; }

        [JsonProperty("EstimateNr")]
        public string EstimateNr { get; set; }

        [JsonProperty("Harvest_Project_URL")]
        public Uri? HarvestProjectURL { get; set; }

        [JsonProperty("HarvestClientID")]
        public Int32? HarvestClientID { get; set; }

        [JsonProperty("Hours_Expire")]
        public bool CCHoursExpire { get; set; }

        [JsonProperty("Hours_Type")]
        public CCHoursType? CCHoursType { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
        public virtual bool ShouldSerializeId()
        {
            return false;
        }

        [JsonProperty("IntervalInMonth")]
        public Int32? IntervalInMonth { get; set; }

        [JsonProperty("InvoiceAddress")]
        public String InvoiceAddress { get; set; }

        [JsonProperty("InvoiceDescription")]
        public String InvoiceDescription { get; set; }

        [JsonProperty("InvoiceDueDays")]
        public Int32? InvoiceDueDays { get; set; }

        [JsonProperty("Last_Activity_Time")]
        public DateTimeOffset? LastActivityTime { get; set; }
        public virtual bool ShouldSerializeLastActivityTime()
        {
            return false;
        }

        [JsonProperty("LastInvoice")]
        public DateTimeOffset? LastInvoice { get; set; }

        [JsonProperty("LastInvoiceNumber")]
        public String LastInvoiceNumber { get; set; }

        [JsonProperty("Locked__s")]
        public bool Locked { get; set; }
        public virtual bool ShouldSerializeLocked()
        {
            return false;
        }
        [JsonProperty("Modified_By")]
        public LookupObject ModifiedBy { get; set; }
        public virtual bool ShouldSerializeModifiedBy()
        {
            return false;
        }

        [JsonProperty("Modified_Time")]
        public DateTimeOffset? ModifiedTime { get; set; }
        public virtual bool ShouldSerializeModifiedTime()
        {
            return false;
        }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("NextInvoice")]
        public DateTimeOffset? NextInvoice { get; set; }

        [JsonProperty("Next_Renewal_Date")]
        public DateTimeOffset? NextRenewalDate { get; set; }

        [JsonProperty("No_End_Date")]
        public bool NoEndDate { get; set; }

        [JsonProperty("Onboarding_Harvest_Project_URL")]
        public Uri? OnboardingHarvestProjectURL { get; set; }

        [JsonProperty("Onboarding_Start_Date")]
        public DateTimeOffset? OnboardingStartDate { get; set; }

        [JsonProperty("OrderNr")]
        public String OrderNr { get; set; }

        [JsonProperty("Owner")]
        public LookupObject Owner { get; set; }
        public virtual bool ShouldSerializeOwner()
        {
            return false;
        }

        [JsonProperty("partDescription")]
        public String partDescription { get; set; }

        [JsonProperty("partDiscount")]
        public decimal? partDiscount { get; set; }

        [JsonProperty("partNumber")]
        public String partNumber { get; set; }

        [JsonProperty("partQuantity")]
        public int? partQuantity { get; set; }

        [JsonProperty("partSellprice")]
        public decimal? partSellprice { get; set; }

        [JsonProperty("partUnit")]
        public PartUnit? partUnit { get; set; }

        [JsonProperty("RmaProject")]
        public String RmaProject { get; set; }

        [JsonProperty("Renewal_Month")]
        public Month RenewalMonth { get; set; }

        [JsonProperty("Reference")]
        public String Reference { get; set; }


        [JsonProperty("Service_or_Product_Category")]
        public ServiceOrProductCategory? ServiceOrProductCategory { get; set; }

        [JsonProperty("Services_and_Products")]
        public LookupObject ServicesAndProducts { get; set; }

        [JsonProperty("Start_Date")]
        public DateTimeOffset? StartDate { get; set; }

        [JsonProperty("Tag")]
        public List<LookupObject> Tag { get; set; }

        [JsonProperty("Termination_Period_Months")]
        public TerminationPeriodMonths? TerminationPeriodMonths { get; set; }

        [JsonProperty("$editable")]
        public bool Editable { get; set; }
        public virtual bool ShouldSerializeEditable()
        {
            return false;
        }
    }
}
