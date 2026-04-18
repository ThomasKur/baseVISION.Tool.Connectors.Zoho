using Microsoft.Extensions.Logging;
using RestSharp;
using System;


namespace baseVISION.Tool.Connectors.Zoho
{
    public partial class ZohoClient
    {
        private void ResponseErrorCheck(RestResponse response)
        {
            switch (response.ResponseStatus)
            {
                case ResponseStatus.Aborted:
                    Logger?.LogError("Zoho API request aborted. Resource: {Resource}. Response content: {Content}", response.Request?.Resource, response.Content);
                    throw new OperationCanceledException("Aborted requesting " + response.Request.Resource + ".");
                case ResponseStatus.Error:
                    if (response.Content?.Contains("You have made too many requests continuously") == true)
                    {
                        Logger?.LogWarning("Zoho API rate limit hit (transport-level). Resource: {Resource}.", response.Request?.Resource);
                        throw new ZohoRateLimitException("You have made too many requests continuously.", response.ErrorException);
                    }
                    Logger?.LogError(
                        response.ErrorException,
                        "Zoho API transport error. Resource: {Resource}. Error: {ErrorMessage}. Inner: {InnerMessage}",
                        response.Request?.Resource,
                        response.ErrorException?.Message,
                        response.ErrorException?.InnerException?.Message);
                    throw response.ErrorException;
                case ResponseStatus.TimedOut:
                    Logger?.LogError("Zoho API request timed out after {Timeout}ms. Resource: {Resource}. Response content: {Content}", response.Request?.Timeout, response.Request?.Resource, response.Content);
                    throw new TimeoutException("Timeout(" + response.Request.Timeout + ") reached for requesting " + response.Request.Resource + ".");
                case ResponseStatus.None:
                    break;
                case ResponseStatus.Completed:
                    break;
                default:
                    break;
            }

            switch ((int)response.StatusCode)
            {
                case 400:
                    Logger?.LogError("Zoho API 400 Bad Request. Resource: {Resource}. Response content: {Content}", response.Request?.Resource, response.Content);
                    throw new Exception("BAD REQUEST: The request or the authentication considered is invalid. Details: " + response.Content);
                case 401:
                    Logger?.LogError("Zoho API 401 Authorization Error. Resource: {Resource}. Response content: {Content}", response.Request?.Resource, response.Content);
                    throw new Exception("AUTHORIZATION ERROR: Invalid API key provided. Details: " + response.Content);
                case 403:
                    Logger?.LogError("Zoho API 403 Forbidden. Resource: {Resource}. Response content: {Content}", response.Request?.Resource, response.Content);
                    throw new Exception("FORBIDDEN: No permission to do the operation. Details: " + response.Content);
                case 404:
                    Logger?.LogError("Zoho API 404 Not Found. Resource: {Resource}. Response content: {Content}", response.Request?.Resource, response.Content);
                    throw new Exception("NOT FOUND: Invalid request. Details: " + response.Content);
                case 405:
                    Logger?.LogError("Zoho API 405 Method Not Allowed. Resource: {Resource}. Response content: {Content}", response.Request?.Resource, response.Content);
                    throw new Exception("METHOD NOT ALLOWED: The specified method is not allowed. Details: " + response.Content);
                case 413:
                    Logger?.LogError("Zoho API 413 Request Entity Too Large. Resource: {Resource}. Response content: {Content}", response.Request?.Resource, response.Content);
                    throw new Exception("REQUEST ENTITY TOO LARGE: The server did not accept the request while uploading a file, since the limited file size has exceeded. Details: " + response.Content);
                case 415:
                    Logger?.LogError("Zoho API 415 Unsupported Media Type. Resource: {Resource}. Response content: {Content}", response.Request?.Resource, response.Content);
                    throw new Exception("UNSUPPORTED MEDIA TYPE: The server did not accept the request while uploading a file, since the media/ file type is not supported. Details: " + response.Content);
                case 429:
                    Logger?.LogWarning("Zoho API 429 Too Many Requests. Resource: {Resource}. Response content: {Content}", response.Request?.Resource, response.Content);
                    throw new ZohoRateLimitException("TOO MANY REQUESTS: Number of API requests per minute / day has exceeded the limit. Details: " + response.Content);
                case 500:
                    Logger?.LogError("Zoho API 500 Internal Server Error. Resource: {Resource}. Response content: {Content}", response.Request?.Resource, response.Content);
                    throw new Exception("INTERNAL SERVER ERROR:  Generic error that is encountered due to an unexpected server error. Details: " + response.Content);
                default:
                    break;
            }
            if (response.Content?.Contains("invalid_client_secret") == true)
            {
                Logger?.LogError("Zoho API invalid client secret. Resource: {Resource}. Response content: {Content}", response.Request?.Resource, response.Content);
                throw new Exception("Invalid Client Secret:  Update the client secret to a correct one. Details: " + response.Content);
            }
        }
    }
}
