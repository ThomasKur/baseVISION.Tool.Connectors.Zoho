using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
namespace baseVISION.Tool.Connectors.Zoho.Model
{
    public enum SortOrder { asc, dsc }
    
    public enum AccountType { Analyst,Competitor,Customer,Investor,Partner,Press,Prospect,Other }
    public enum AccountRating { Acquired,Active,[EnumMember(Value = "Market Failed")]MarketFailed,[EnumMember(Value = "Project Canceled")] ProjectCanceled, [EnumMember(Value = "Shut Down")] Shutdown  }
    public enum Industry { Communications, Technology, [EnumMember(Value = "Government/Military")] Government,Manufacturing, [EnumMember(Value = "Financial Services")] FinancialServices, [EnumMember(Value = "IT Services")]ITServices,Education,Pharma, [EnumMember(Value = "Real Estate")]RealEstate,Consulting, [EnumMember(Value = "Health Care")]HealthCare }
    public enum Salutation {Mr, Mrs,  Ms, [EnumMember(Value = "Dr.")] Dr }
    public enum LeadSource { Advertisement, [EnumMember(Value = "Cold Call")]ColdCall, [EnumMember(Value = "Employee Referral")] EmployeeReferral, [EnumMember(Value = "External Referral")] ExternalReferral,Partner, [EnumMember(Value = "Public Relations")] PublicRelations, [EnumMember(Value = "MS Event")]MSEvent, [EnumMember(Value = "Own Event")] OwnEvent, [EnumMember(Value = "Web Form")]WebForm, [EnumMember(Value = "Search Engine")] SearchEngine,Facebook, Twitter,LinkedIn, [EnumMember(Value = "WebSite Visit")]  WebSiteVisit,Chat,ZohoDesk }

}
