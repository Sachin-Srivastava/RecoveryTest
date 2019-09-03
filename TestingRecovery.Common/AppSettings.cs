using System.Json;
using Newtonsoft.Json;

namespace TestingRecovery.Common
{
    [JsonObject("azureEnvironment")]
    public class AppSettings
    {
        [JsonProperty("tenantId")]
        public string TenantId {get;set;}

        [JsonProperty("clientId")]
        public string ClientId {get;set;}

        [JsonProperty("clientSecret")]
        public string ClientSecret {get;set;}

        [JsonProperty("subscriptionId")]
        public string SubscriptionId {get;set;}

        [JsonProperty("tokenUrl")]
        public string TokenUrl {get;set;}
    }    
}
