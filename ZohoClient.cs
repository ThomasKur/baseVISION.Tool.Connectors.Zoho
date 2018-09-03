using System;
using baseVISION.Tool.Connectors.Zoho.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace baseVISION.Tool.Connectors.Zoho
{
    public partial class ZohoClient
    {
        private ZohoTokenInformation token = null;
        private Uri endpoint = null;
        private string clientSecret = null;
        private string clientId = null;
        private string refreshToken = null;
        private RestClient restTokenClient = null;
        private RestClient restDataClient = null;
        public NewtonsoftJsonSerializer serializer = null;
        public ZohoClient(Uri endpoint, string clientId, string clientSecret, string refreshToken) {
            restTokenClient = new RestClient(endpoint);
            this.endpoint = endpoint;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.refreshToken = refreshToken;

            // Setting up JSON Serialization Engine
            serializer = NewtonsoftJsonSerializer.Default;
            
            // Request Token the first time
            RefreshToken();

            // Prepare Client
            Leads = new Module<Lead>(this,"Leads");
            Accounts = new Module<Account>(this, "Accounts");
            Contacts = new Module<Contact>(this, "Contacts");
            Deals = new Module<Deal>(this, "Deals");
        }
        internal T Execute<T>(RestRequest request) where T : new()
        {
            CheckToken();
            request.RequestFormat = DataFormat.Json;
            
            IRestResponse<T> response = restDataClient.Execute<T>(request);
            ResponseErrorCheck(response);
            return response.Data;
        }
        public Module<Lead> Leads { get; private set; }
        public Module<Account> Accounts { get; private set; }
        public Module<Contact> Contacts { get; private set; }
        public Module<Deal> Deals { get; private set; }
    }
}
