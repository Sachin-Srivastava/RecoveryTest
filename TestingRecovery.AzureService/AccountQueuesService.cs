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
    public class AccountQueuesService : IAccountQueuesService
    {
        private readonly string _resourceUrl;
        private readonly IAzureClient _azureClient;
        private readonly AppSettings _config;

        public AccountQueuesService (IOptions<AppSettings> config, IAzureClient azureClient,
                                        Resources resources)
        {
            _azureClient = azureClient;
            _config = config.Value;
            _resourceUrl = resources.QueueUrl("ssactivateazure");
        }
        public async Task<string> GetAccountQueues()
        {
            var content = await _azureClient.AzureGetResource($"{_resourceUrl}?comp=list", _resourceUrl);
            //return JsonConvert.DeserializeObject<AccountQueueList>(content);
            return content.ToString();
        }
    }
}