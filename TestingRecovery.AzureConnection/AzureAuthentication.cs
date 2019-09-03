using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TestingRecovery.Common;

namespace TestingRecovery.AzureConnection
{
    public class AzureAuthentication : IAzureAuthentication
    {
        private readonly AppSettings _config;
        private readonly HttpClient _client;
        public AzureAuthentication(IOptions<AppSettings> config, 
                                        IHttpClientFactory clientFactory)
        {
            _config = config.Value;            
            _client = clientFactory.CreateClient();            
        } 
        public async Task<string> GetTokenAsync(string resourceUrl)
        {
            Dictionary <string,string> content = new Dictionary<string, string>()
            {
                {"grant_type", "client_credentials"},
                {"client_id", _config.ClientId},
                {"client_secret", _config.ClientSecret},
                {"resource", resourceUrl},                
            };            
            var response = await _client.PostAsync(_config.TokenUrl, new FormUrlEncodedContent(content));
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AuthResponse>(responseContent).AccessToken;
        }       
    }
}