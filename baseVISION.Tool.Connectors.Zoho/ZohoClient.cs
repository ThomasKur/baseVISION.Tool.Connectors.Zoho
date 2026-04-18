using System;
using System.Threading.Tasks;
using baseVISION.Tool.Connectors.Zoho.Model;
using Microsoft.Extensions.Logging;
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
        private int maxRetries = 3;
        private int retryDelayBaseMs = 5000;
        private RestClient restTokenClient = null;
        private RestClient restDataClient = null;
        internal ILogger Logger { get; private set; }

        public ZohoClient(Uri endpoint, string clientId, string clientSecret, string refreshToken, int asyncTaskTimeout = 5000, ILogger logger = null, int maxRetries = 3, int retryDelayBaseMs = 5000)
        {
            JsonSerializer j = new JsonSerializer() { DateFormatHandling = DateFormatHandling.IsoDateFormat };
            restTokenClient = new RestClient(endpoint, configureSerialization: s => s.UseSerializer(() => new NewtonsoftJsonSerializer(j)));

            this.Logger = logger;
            this.endpoint = endpoint;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.refreshToken = refreshToken;
            this.asyncTaskTimeout = asyncTaskTimeout;
            this.maxRetries = maxRetries;
            this.retryDelayBaseMs = retryDelayBaseMs;

            // Check Token the first time
            CheckToken();

            // Prepare Client
            Leads = new Module<Lead>(this, "Leads");
            Accounts = new Module<Account>(this, "Accounts");
            Contacts = new Module<Contact>(this, "Contacts");
            Deals = new Module<Deal>(this, "Deals");
            ResourcePlans = new Module<ResourcePlans>(this, "ResourcePlans");
            Recurrings = new Module<Recurring>(this, "Recurrings");
            Products = new Module<Product>(this, "Products");
        }

        public ZohoClient(Uri endpoint, string clientId, string clientSecret, string refreshToken, ZohoTokenInformation accessToken, int asyncTaskTimeout = 5000, ILogger logger = null, int maxRetries = 3, int retryDelayBaseMs = 5000)
        {
            JsonSerializer j = new JsonSerializer() { DateFormatHandling = DateFormatHandling.IsoDateFormat };
            restTokenClient = new RestClient(endpoint, configureSerialization: s => s.UseSerializer(() => new NewtonsoftJsonSerializer(j)));

            this.Logger = logger;
            this.Token = accessToken;
            this.endpoint = endpoint;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.refreshToken = refreshToken;
            this.asyncTaskTimeout = asyncTaskTimeout;
            this.maxRetries = maxRetries;
            this.retryDelayBaseMs = retryDelayBaseMs;

            // Check Token the first time
            CheckToken();
            InitializeDataClient();

            // Prepare Client
            Leads = new Module<Lead>(this, "Leads");
            Accounts = new Module<Account>(this, "Accounts");
            Contacts = new Module<Contact>(this, "Contacts");
            Deals = new Module<Deal>(this, "Deals");
            ResourcePlans = new Module<ResourcePlans>(this, "ResourcePlans");
            Recurrings = new Module<Recurring>(this, "Recurrings");
            Products = new Module<Product>(this, "Products");
        }

        private void InitializeDataClient()
        {
            restDataClient = new RestClient(Token.ApiDomain, configureSerialization: s => s.UseSerializer(() => new NewtonsoftJsonSerializer()));
            restDataClient.AddDefaultHeader("Authorization", "Zoho-oauthtoken " + Token.AccessToken);
        }

        internal T Execute<T>(RestRequest request) where T : new()
        {
            Task<T> response = this.ExecuteAsync<T>(request);
            try
            {
                response.Wait(asyncTaskTimeout);
                return response.Result;
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        internal async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                CheckToken();
                request.RequestFormat = DataFormat.Json;

                Logger?.LogDebug("Zoho API request (attempt {Attempt}/{MaxRetries}): {Method} {Resource}", attempt, this.maxRetries, request.Method, request.Resource);

                RestResponse<T> response = await restDataClient.ExecuteAsync<T>(request);

                try
                {
                    ResponseErrorCheck(response);
                }
                catch (ZohoRateLimitException) when (attempt < this.maxRetries)
                {
                    int delay = this.retryDelayBaseMs * attempt;
                    Logger?.LogWarning("Zoho API rate limit reached. Retrying attempt {Attempt}/{MaxRetries} after {Delay}ms. Resource: {Resource}.", attempt, this.maxRetries, delay, request.Resource);
                    await Task.Delay(delay);
                    continue;
                }

                Logger?.LogInformation("Zoho API response: {Method} {Resource} -> {StatusCode}", request.Method, request.Resource, (int)response.StatusCode);

                return response.Data;
            }

            throw new InvalidOperationException("Retry loop exited unexpectedly.");
        }

        public Module<Lead> Leads { get; private set; }
        public Module<Account> Accounts { get; private set; }
        public Module<Contact> Contacts { get; private set; }
        public Module<Deal> Deals { get; private set; }
        public Module<ResourcePlans> ResourcePlans { get; private set; }
        public Module<Recurring> Recurrings { get; private set; }
        public Module<Product> Products { get; private set; }

        public Result<Product> GetProductsForRecurring(string recurringId) => Recurrings.GetRelatedRecords<Product>(recurringId, "Products");
        public Task<Result<Product>> GetProductsForRecurringAsync(string recurringId) => Recurrings.GetRelatedRecordsAsync<Product>(recurringId, "Products");

        public Result<Product> GetProductsForAccount(string accountId) => Accounts.GetRelatedRecords<Product>(accountId, "Products");
        public Task<Result<Product>> GetProductsForAccountAsync(string accountId) => Accounts.GetRelatedRecordsAsync<Product>(accountId, "Products");

        public Result<Product> GetProductsForDeal(string dealId) => Deals.GetRelatedRecords<Product>(dealId, "Products");
        public Task<Result<Product>> GetProductsForDealAsync(string dealId) => Deals.GetRelatedRecordsAsync<Product>(dealId, "Products");
    }
}
