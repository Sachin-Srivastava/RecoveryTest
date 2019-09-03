using System.Collections.Generic;
using Newtonsoft.Json;

namespace RecoveryTest.DTO
{
    public class StorageAccountList
    {
        [JsonProperty("value")]
        public IList<StorageAccount> storageAccountList;
    }
}