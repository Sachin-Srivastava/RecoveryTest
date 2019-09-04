using System.Threading.Tasks;
using RecoveryTest.AzureConnection;
using Microsoft.Extensions.Options;
using TestingRecovery.Common;
using System.Xml.Serialization;
using RecoveryTest.TestingRecovery.DTO;
using System.IO;
using System;

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
            /*XmlSerializer serializer = new XmlSerializer(typeof(AzureQueueList));
            AzureQueueList result;
            using (TextReader reader = new StringReader(content))
            {
                 result = (AzureQueueList) serializer.Deserialize(reader);
            }
            Console.WriteLine(result);*/
            return content.ToString();
        }
    }
}