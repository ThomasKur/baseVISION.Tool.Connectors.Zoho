using System;
using System.Threading.Tasks;
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
        private int asyncTaskTimeout = 5000;
        private RestClient restTokenClient = null;
        private RestClient restDataClient = null;
        public ZohoClient(Uri endpoint, string clientId, string clientSecret, string refreshToken, int asyncTaskTimeout = 5000) {
            restTokenClient = new RestClient(endpoint);
            restTokenClient.UseSerializer(() => new NewtonsoftJsonSerializer());

            this.endpoint = endpoint;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.refreshToken = refreshToken;
            this.asyncTaskTimeout = asyncTaskTimeout;

            
            // Check Token the first time
            CheckToken();

            // Prepare Client
            Leads = new Module<Lead>(this,"Leads");
            Accounts = new Module<Account>(this, "Accounts");
            Contacts = new Module<Contact>(this, "Contacts");
            Deals = new Module<Deal>(this, "Deals");
        }
        public ZohoClient(Uri endpoint, string clientId, string clientSecret, string refreshToken,ZohoTokenInformation accessToken, int asyncTaskTimeout = 5000)
        {
            restTokenClient = new RestClient(endpoint);
            restTokenClient.UseSerializer(() => new NewtonsoftJsonSerializer());

            this.Token = accessToken;
            this.endpoint = endpoint;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.refreshToken = refreshToken;
            this.asyncTaskTimeout = asyncTaskTimeout;



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
            restDataClient.UseSerializer(() => new NewtonsoftJsonSerializer());

            restDataClient.AddDefaultHeader("Authorization", "Zoho-oauthtoken " + Token.AccessToken);
        }

        internal T Execute<T>(RestRequest request) where T : new()
        {
            Task<T> response = this.ExecuteAsync<T>(request);
            response.Wait(asyncTaskTimeout);
            return response.Result;
        }
        internal async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            CheckToken();
            request.RequestFormat = DataFormat.Json;

            RestResponse<T> response = await restDataClient.ExecuteAsync<T>(request);

            ResponseErrorCheck(response);
            return response.Data;
        }

        public Module<Lead> Leads { get; private set; }
        public Module<Account> Accounts { get; private set; }
        public Module<Contact> Contacts { get; private set; }
        public Module<Deal> Deals { get; private set; }
    }
}
