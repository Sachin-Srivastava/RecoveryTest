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
    public class TestStorageAccountService
    {
        [Fact]
        public async Task StorageAccountServiceTest_GetReturnsCorrectAccount()
        {
            var appSettings = new AppSettings();
            appSettings.TokenUrl = "http://good.uri";
            var config = Options.Create(appSettings);
            var resources = new Resources();            
            var mockAzureClient = Substitute.For<IAzureClient>();
            var storageAccountList = new StorageAccountList();
            storageAccountList.accountList = new List<StorageAccount>(){
                new StorageAccount(){
                    Kind = "testkind"
                }
            };
            mockAzureClient.AzureGet(Arg.Any<string>(), Arg.Any<string>())
                            .Returns(Task.FromResult(JsonConvert.SerializeObject(storageAccountList)));
            var storageAccountService = new StorageAccountService(config, mockAzureClient, resources);
            var accounts = await storageAccountService.GetStorageAccounts();  
            accounts.accountList[0].Kind.Equals("testkind");            
        }
    }
}
