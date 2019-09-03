using System.Threading.Tasks;
using RecoveryTest.AzureConnection;
using Microsoft.Extensions.Options;
using TestingRecovery.Common;
using Newtonsoft.Json;
using RecoveryTest.DTO;
using System.Collections.Generic;
using RecoveryTest.common;

namespace TestingRecovery.AzureService
{
    public class StorageAccountService : IStorageAccountService
    {
        private readonly IAzureClient _azureClient;
        private readonly AppSettings _config;
        private readonly string _resourceUrl;
        public StorageAccountService (IOptions<AppSettings> config, IAzureClient azureClient,
                                    Resources resources)
        {
            _azureClient = azureClient;
            _config = config.Value;
            _resourceUrl = resources.ManagementUrl;
        }
        public async Task<StorageAccountList> GetStorageAccounts()
        {
            var content = await _azureClient.AzureGet($"{_resourceUrl}/subscriptions/{_config.SubscriptionId}/providers/Microsoft.Storage/storageAccounts?api-version=2019-04-01", _resourceUrl);
            return JsonConvert.DeserializeObject<StorageAccountList>(content);

        }
    }
}