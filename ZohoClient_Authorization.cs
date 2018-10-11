using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;
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
            RestSharp.RestRequest r = new RestSharp.RestRequest("oauth/v2/token", Method.POST);
            r.AlwaysMultipartFormData = true;
            r.AddParameter("client_id", clientId, ParameterType.GetOrPost);
            r.AddParameter("client_secret", clientSecret, ParameterType.GetOrPost);
            r.AddParameter("refresh_token", refreshToken, ParameterType.GetOrPost);
            r.AddParameter("grant_type", "refresh_token", ParameterType.GetOrPost);
            r.RequestFormat = DataFormat.Json;

            var response = restTokenClient.Execute<ZohoTokenInformation>(r);
            ResponseErrorCheck(response);
            Token = response.Data;
            restDataClient = new RestClient(Token.ApiDomain);
            restDataClient.AddHandler("application/json", serializer);
            restDataClient.AddHandler("text/json", serializer);
            restDataClient.AddHandler("text/x-json", serializer);
            restDataClient.AddHandler("text/javascript", serializer);
            restDataClient.AddHandler("*+json", serializer);

            restDataClient.AddDefaultHeader("Authorization", "Zoho-oauthtoken " + Token.AccessToken);
        }
    }
}
