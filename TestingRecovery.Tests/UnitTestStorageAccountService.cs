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

namespace TestingRecovery.Tests
{
    public class UnitTestStorageAccountService
    {
        [Fact]
        public async Task Test1()
        {
            var appSettings = new AppSettings();
            appSettings.TokenUrl = "http://good.uri";
            var config = Options.Create(appSettings);
            var resources = new Resources();
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage() {
                                            StatusCode = HttpStatusCode.OK,
                                            Content = new StringContent(JsonConvert.SerializeObject(new AuthResponse()), 
                                            Encoding.UTF8, "application/json") 
                                        });
            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

            httpClientFactoryMock.CreateClient().Returns(fakeHttpClient);
            var azureAuthentication = new AzureAuthentication(config, httpClientFactoryMock);
            var azureClient = new AzureClient(azureAuthentication, httpClientFactoryMock);
            var storageAccountService = new StorageAccountService(config, azureClient, resources);
            var l = await storageAccountService.GetStorageAccounts();
            //var azureClient = new AzureClient();
            //var storageAccountService = new StorageAccountService(someOptions,);
            //var l = await storageAccountService.GetStorageAccounts();
            //foreach(var i in l.storageAccountList)
            {
                //Console.WriteLine(i.name);
            }
        }
    }
}
