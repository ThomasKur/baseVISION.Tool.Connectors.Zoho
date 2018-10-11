using System; 
using baseVISION.Tool.Connectors.Zoho.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace baseVISION.Tool.Connectors.Zoho
{
    public partial class ZohoClient
    {
        public ZohoTokenInformation Token { get; private set; }
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
            
            // Check Token the first time
            CheckToken();

            // Prepare Client
            Leads = new Module<Lead>(this,"Leads");
            Accounts = new Module<Account>(this, "Accounts");
            Contacts = new Module<Contact>(this, "Contacts");
            Deals = new Module<Deal>(this, "Deals");
        }
        public ZohoClient(Uri endpoint, string clientId, string clientSecret, string refreshToken,ZohoTokenInformation accessToken)
        {
            this.Token = accessToken;
            restTokenClient = new RestClient(endpoint);
            this.endpoint = endpoint;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.refreshToken = refreshToken;

            // Setting up JSON Serialization Engine
            serializer = NewtonsoftJsonSerializer.Default;

            // Check Token the first time
            CheckToken();
            InitializeDataClient();
            // Prepare Client
            Leads = new Module<Lead>(this, "Leads");
            Accounts = new Module<Account>(this, "Accounts");
            Contacts = new Module<Contact>(this, "Contacts");
            Deals = new Module<Deal>(this, "Deals");
        }

        private void InitializeDataClient()
        {
            restDataClient = new RestClient(Token.ApiDomain);
            restDataClient.AddHandler("application/json", serializer);
            restDataClient.AddHandler("text/json", serializer);
            restDataClient.AddHandler("text/x-json", serializer);
            restDataClient.AddHandler("text/javascript", serializer);
            restDataClient.AddHandler("*+json", serializer);

            restDataClient.AddDefaultHeader("Authorization", "Zoho-oauthtoken " + Token.AccessToken);
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
