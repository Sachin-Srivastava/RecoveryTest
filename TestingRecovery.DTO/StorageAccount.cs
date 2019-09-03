using Newtonsoft.Json;

namespace RecoveryTest.DTO
{
    public class StorageAccount
    {
        [JsonProperty("kind")]
        public string kind { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
        
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("location")]
        public string location { get; set; }
    }
}