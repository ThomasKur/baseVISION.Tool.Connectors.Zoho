using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Net;


namespace baseVISION.Tool.Connectors.Zoho
{
    public partial class ZohoClient
    {
        private void CheckToken()
        {
            if(Token == null || Token.ExpiryTime <= DateTime.Now.AddSeconds(60))
            {
                RefreshToken();
            }
        }
        private void RefreshToken()
        {
            RestSharp.RestRequest r = new RestSharp.RestRequest("oauth/v2/token", Method.Post);
            r.AlwaysMultipartFormData = true;
            r.AddParameter("client_id", clientId, ParameterType.GetOrPost);
            r.AddParameter("client_secret", clientSecret, ParameterType.GetOrPost);
            r.AddParameter("refresh_token", refreshToken, ParameterType.GetOrPost);
            r.AddParameter("grant_type", "refresh_token", ParameterType.GetOrPost);
            r.RequestFormat = DataFormat.Json;

            var response = restTokenClient.ExecuteAsync<ZohoTokenInformation>(r);
            response.Wait(asyncTaskTimeout);
            ResponseErrorCheck(response.Result);
            Token = response.Result.Data;
            InitializeDataClient();
        }
    }
}
