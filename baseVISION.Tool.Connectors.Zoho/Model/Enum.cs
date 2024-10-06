using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public enum SortOrder { asc, dsc }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum AccountType { Analyst,Competitor,Customer,Investor,Partner,Press,Prospect,Other,Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum Currency { USD, CHF, EUR, Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum PartUnit { [EnumMember(Value = "Stk.")] Stk, [EnumMember(Value = "Std.")] Std, Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum AccountRating { Acquired,Active,Inactive, [EnumMember(Value = "Shut Down")] Shutdown,Unknown  }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum Industry { Communications, Technology, [EnumMember(Value = "Government/Military")] Government,Manufacturing, [EnumMember(Value = "Financial Services")] FinancialServices, [EnumMember(Value = "IT Services")]ITServices,Education,Pharma, [EnumMember(Value = "Real Estate")]RealEstate,Consulting, [EnumMember(Value = "Health Care")]HealthCare,Transportation,Retail,Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum Salutation {Mr, Mrs,  Ms, [EnumMember(Value = "Dr.")] Dr,Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum LeadSource { Advertisement, [EnumMember(Value = "Cold Call")]ColdCall, [EnumMember(Value = "Employee Referral")] EmployeeReferral, [EnumMember(Value = "External Referral")] ExternalReferral,Partner, [EnumMember(Value = "Public Relations")] PublicRelations, [EnumMember(Value = "MS Event")]MSEvent, [EnumMember(Value = "Own Event")] OwnEvent, [EnumMember(Value = "Web Form")]WebForm, [EnumMember(Value = "Search Engine")] SearchEngine,Facebook, Twitter,LinkedIn, [EnumMember(Value = "WebSite Visit")]  WebSiteVisit,Chat,ZohoDesk,Purchased,Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum AutoRenewalPeriod { [EnumMember(Value = "12")] Months12, [EnumMember(Value = "24")] Months24, [EnumMember(Value = "36")] Months36, Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum InitialPeriod { [EnumMember(Value = "1")] Months1, [EnumMember(Value = "2")] Months2, [EnumMember(Value = "3")] Months3, [EnumMember(Value = "4")] Months4, [EnumMember(Value = "12")] Months12, [EnumMember(Value = "24")] Months24, [EnumMember(Value = "36")] Months36, [EnumMember(Value = "∞")] Unlimited, Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum SocBillingModel {  User,Incident, Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum CCProducts { MEMCM, EMS, AVD,AD,PKI, [EnumMember(Value = "Entra Connect")] EntraConnect, [EnumMember(Value = "App-V")] AppV,MDE,Packaging, Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum CCLevel {  BestEffort,Normal,High,Urgent, [EnumMember(Value = "Urgent+24BestEffort")] UrgentAnd24BestEffort, [EnumMember(Value = "Urgent+7x24")] UrgentAnd7x24, Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum CCHoursType { SPO,SPA, [EnumMember(Value = "No Hours")] NoHours, Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum PartNumber { [EnumMember(Value = "MicrosoftCSP 24")] MicrosoftCSP, [EnumMember(Value = "netECM 24")] netECM, [EnumMember(Value = "PatchMyPc 24")] PatchMyPc, [EnumMember(Value = "WimAsAService 24")] WimAsAService, [EnumMember(Value = "Security Operation Center 24")] SOC, [EnumMember(Value = "I-doit 24")] Idoit, [EnumMember(Value = "Connected Care 24")] ConnectedCare, [EnumMember(Value = "Basic Agreement 24")] BasicAgreement, [EnumMember(Value = "Active Security Service 24")] ActiveSecurityService, Unknown }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum Month
    {
        NotSet = 0,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12,Unknown
    }
    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum ServiceOrProductCategory { 
        [EnumMember(Value = "Consulting and Engineering")] ConsultingAndEngineering,
        [EnumMember(Value = "Managed Service")] ManagedService, 
        [EnumMember(Value = "Reseller Product")] ResellerProduct,
        [EnumMember(Value = "Line Item only used in Estimates")] LineItemOnlyUsedInEstimates,
        Unknown }

    [JsonConverter(typeof(DefaultUnknownEnumConverter), (int)Unknown)]
    public enum TerminationPeriodMonths { [EnumMember(Value = "1")] Months1, [EnumMember(Value = "3")] Months3,[EnumMember(Value = "12")] Months12, Unknown }

}
