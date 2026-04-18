using baseVISION.Tool.Connectors.Zoho;
using baseVISION.Tool.Connectors.Zoho.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public class Product : IZohoRecord
    {
        [JsonProperty("Commission_Rate")]
        public decimal? CommissionRate { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("Service_Catalog")]
        public Uri ServiceCatalog { get; set; }

        [JsonProperty("Connected_To__s")]
        public List<LookupObject> ConnectedTo { get; set; }

        [JsonProperty("ContributingCPORWorkload")]
        public List<string> ContributingCPORWorkload { get; set; }

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

        [JsonProperty("Currency_6")]
        public decimal? Currency6 { get; set; }

        [JsonProperty("DeliveryHours")]
        public decimal? DeliveryHours { get; set; }

        [JsonProperty("Delivery_Hours_Titel")]
        public string DeliveryHoursTitle { get; set; }

        [JsonProperty("Delivery_Hours_LineItem_Description")]
        public string DeliveryHoursLineItemDescription { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Do_not_Associate_to_Account")]
        public bool? DoNotAssociateToAccount { get; set; }

        [JsonProperty("FixedPrice")]
        public decimal? FixedPrice { get; set; }

        [JsonProperty("Fixed_Price_Documents")]
        public decimal? FixedPriceDocuments { get; set; }

        [JsonProperty("German_Line_Item_Description")]
        public string GermanLineItemDescription { get; set; }

        [JsonProperty("German_Line_Item_Titel")]
        public string GermanLineItemTitle { get; set; }

        [JsonProperty("GitHub_Repo")]
        public Uri GitHubRepository { get; set; }

        [JsonProperty("Handler")]
        public LookupObject Handler { get; set; }

        [JsonProperty("InternalHours")]
        public decimal? InternalHours { get; set; }

        [JsonProperty("Deliverable")]
        public string Deliverable { get; set; }

        [JsonProperty("Manufacturer")]
        public string Manufacturer { get; set; }

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

        [JsonProperty("Monhtly_Price")]
        public decimal? MonthlyPrice { get; set; }

        [JsonProperty("Pages")]
        public string Pages { get; set; }

        [JsonProperty("Partner_Price")]
        public decimal? PartnerPrice { get; set; }

        [JsonProperty("Qty_Ordered")]
        public decimal? QuantityOrdered { get; set; }

        [JsonProperty("Qty_in_Demand")]
        public decimal? QuantityInDemand { get; set; }

        [JsonProperty("Qty_in_Stock")]
        public decimal? QuantityInStock { get; set; }

        [JsonProperty("Rate")]
        public decimal? Rate { get; set; }

        [JsonProperty("Recuring_Invoice")]
        public string RecurringInvoice { get; set; }

        [JsonProperty("Recurring_Service_or_Recurring_Product")]
        public bool? RecurringServiceOrProduct { get; set; }

        [JsonProperty("Reorder_Level")]
        public decimal? ReorderLevel { get; set; }

        [JsonProperty("Sales_End_Date")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTimeOffset? SalesEndDate { get; set; }

        [JsonProperty("Sales_Start_Date")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTimeOffset? SalesStartDate { get; set; }

        [JsonProperty("Service_Fee")]
        public decimal? ServiceFee { get; set; }

        [JsonProperty("Product_Active")]
        public bool ProductActive { get; set; }

        [JsonProperty("Product_Category")]
        public string ProductCategory { get; set; }

        [JsonProperty("Product_Code")]
        public string ProductCode { get; set; }

        [JsonProperty("Record_Image")]
        public string RecordImage { get; set; }

        [JsonProperty("Product_Name")]
        public string ProductName { get; set; }

        [JsonProperty("Owner")]
        public LookupObject Owner { get; set; }
        public virtual bool ShouldSerializeOwner()
        {
            return false;
        }

        [JsonProperty("Service_Status")]
        public string ServiceStatus { get; set; }

        [JsonProperty("Currency1")]
        public string SoldCurrency { get; set; }

        [JsonProperty("Support_Expiry_Date")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTimeOffset? SupportExpiryDate { get; set; }

        [JsonProperty("Support_Start_Date")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTimeOffset? SupportStartDate { get; set; }

        [JsonProperty("Tag")]
        public List<LookupObject> Tag { get; set; }

        [JsonProperty("Tax")]
        public List<string> Tax { get; set; }

        [JsonProperty("Taxable")]
        public bool? Taxable { get; set; }

        [JsonProperty("Technical_Lead")]
        public List<string> TechnicalLead { get; set; }

        [JsonProperty("Technology")]
        public string Technology { get; set; }

        [JsonProperty("Unit_Price")]
        public decimal? UnitPrice { get; set; }

        [JsonProperty("Usage_Unit")]
        public string UsageUnit { get; set; }

        [JsonProperty("Variable_Price")]
        public bool? VariablePrice { get; set; }

        [JsonProperty("Variable_Price_Calculation")]
        public string VariablePriceCalculation { get; set; }

        [JsonProperty("Vendor_Name")]
        public LookupObject VendorName { get; set; }
        public virtual bool ShouldSerializeVendorName()
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
