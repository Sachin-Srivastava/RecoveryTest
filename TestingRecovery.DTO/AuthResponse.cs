using Newtonsoft.Json;

namespace TestingRecovery.Common
{
    public class AuthResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}