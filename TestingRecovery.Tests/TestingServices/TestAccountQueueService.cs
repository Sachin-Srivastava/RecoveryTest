using System;
using Xunit;
using TestingRecovery.AzureService;
using Microsoft.Extensions.Options;
using TestingRecovery.Common;
using System.Threading.Tasks;
using RecoveryTest.AzureConnection;
using NSubstitute;
using System.Net.Http;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using TestingRecovery.AzureConnection;
using RecoveryTest.DTO;
using System.Collections.Generic;

namespace TestingRecovery.Tests
{
    public class TestAccountQueueService
    {
        [Fact]
        public async Task StorageAccountServiceTest_GetReturnsCorrectAccount()
        {
            var appSettings = new AppSettings();
            appSettings.TokenUrl = "http://good.uri";
            var config = Options.Create(appSettings);
            var resources = new Resources();
            
            var mockAzureClient = Substitute.For<IAzureClient>();
            var queueContent ="Testing";
            mockAzureClient.AzureGetResource(Arg.Any<string>(), Arg.Any<string>())
                            .Returns(Task.FromResult(queueContent));
            var storageAccountService = new AccountQueuesService(config, mockAzureClient, resources);
            var accounts = await storageAccountService.GetAccountQueues();  
            accounts.Equals("Testing");            
        }
    }
}
