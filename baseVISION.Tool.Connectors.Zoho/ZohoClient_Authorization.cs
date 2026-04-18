using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Net;
using System.Diagnostics.Contracts;


namespace baseVISION.Tool.Connectors.Zoho
{
    public partial class ZohoClient
    {
        private void CheckToken()
        {
            if (Token == null || Token.ExpiryTime <= DateTime.Now.AddSeconds(60))
            {
                Logger?.LogDebug("Zoho token is missing or expires within 60 seconds. Refreshing.");
                RefreshToken();
            }
            else
            {
                Logger?.LogDebug("Zoho token is valid. Expires at {ExpiryTime}.", Token.ExpiryTime);
            }
        }

        private void RefreshToken()
        {
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    Logger?.LogDebug("Requesting new Zoho access token for client ID {ClientId} (attempt {Attempt}/{MaxRetries}).", clientId, attempt, maxRetries);

                    RestSharp.RestRequest r = new RestSharp.RestRequest("oauth/v2/token", Method.Post);
                    r.AlwaysMultipartFormData = true;
                    r.AddParameter("client_id", clientId, ParameterType.GetOrPost);
                    r.AddParameter("client_secret", clientSecret, ParameterType.GetOrPost);
                    r.AddParameter("refresh_token", refreshToken, ParameterType.GetOrPost);
                    r.AddParameter("grant_type", "refresh_token", ParameterType.GetOrPost);
                    r.RequestFormat = DataFormat.Json;

                    var response = restTokenClient.ExecuteAsync<ZohoTokenInformation>(r);
                    response.Wait(asyncTaskTimeout);

                    // Check for deserialization errors or unexpected content
                    if (response.Result.Data == null && !string.IsNullOrEmpty(response.Result.Content))
                    {
                        var contentPreview = response.Result.Content.Length > 500 
                            ? response.Result.Content.Substring(0, 500) 
                            : response.Result.Content;
                        Logger?.LogError("Zoho token refresh returned unexpected content. StatusCode: {StatusCode}, Content: {Content}", 
                            response.Result.StatusCode, contentPreview);
                        throw new InvalidOperationException($"Zoho API returned unexpected content (possibly HTML error page). Status: {response.Result.StatusCode}. Check endpoint URL and API status.");
                    }

                    ResponseErrorCheck(response.Result);
                    Token = response.Result.Data;
                    InitializeDataClient();

                    Logger?.LogInformation("Zoho access token refreshed successfully. Expires at {ExpiryTime}.", Token.ExpiryTime);
                    return;
                }
                catch (ZohoRateLimitException) when (attempt < maxRetries)
                {
                    int delay = retryDelayBaseMs * attempt;
                    Logger?.LogWarning("Zoho API rate limit reached during token refresh. Retrying attempt {Attempt}/{MaxRetries} after {Delay}ms.", attempt, maxRetries, delay);
                    System.Threading.Thread.Sleep(delay);
                }
                catch (Exception ex) when (attempt < maxRetries && (ex is InvalidOperationException || ex.InnerException is InvalidOperationException))
                {
                    int delay = retryDelayBaseMs * attempt;
                    Logger?.LogWarning(ex, "Zoho token refresh failed with deserialization error. Retrying attempt {Attempt}/{MaxRetries} after {Delay}ms.", attempt, maxRetries, delay);
                    System.Threading.Thread.Sleep(delay);
                }
            }

            throw new InvalidOperationException("Failed to refresh Zoho access token after maximum retry attempts.");
        }
    }
}
