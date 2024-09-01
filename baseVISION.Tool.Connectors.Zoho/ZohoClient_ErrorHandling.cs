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
                    throw new OperationCanceledException("Aborted requesting " + response.Request.Resource + ".");
                case ResponseStatus.Error:
                    throw response.ErrorException;
                case ResponseStatus.TimedOut:
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
                    throw new Exception("BAD REQUEST: The request or the authentication considered is invalid. Details: " + response.Content);
                case 401:
                    throw new Exception("AUTHORIZATION ERROR: Invalid API key provided. Details: " + response.Content);
                case 403:
                    throw new Exception("FORBIDDEN: No permission to do the operation. Details: " + response.Content);
                case 404:
                    throw new Exception("NOT FOUND: Invalid request. Details: " + response.Content);
                case 405:
                    throw new Exception("METHOD NOT ALLOWED: The specified method is not allowed. Details: " + response.Content);
                case 413:
                    throw new Exception("REQUEST ENTITY TOO LARGE: The server did not accept the request while uploading a file, since the limited file size has exceeded. Details: " + response.Content);
                case 415:
                    throw new Exception("UNSUPPORTED MEDIA TYPE: The server did not accept the request while uploading a file, since the media/ file type is not supported. Details: " + response.Content);
                case 429:
                    throw new Exception("TOO MANY REQUESTS: Number of API requests per minute / day has exceeded the limit. Details: " + response.Content);
                case 500:
                    throw new Exception("INTERNAL SERVER ERROR:  Generic error that is encountered due to an unexpected server error. Details: " + response.Content);
                default:
                    break;
            }
            if(response.Content.Contains("invalid_client_secret"))
                throw new Exception("Invalid Client Secret:  Update the client secret to a correct one. Details: " + response.Content);
        }
    }
}
