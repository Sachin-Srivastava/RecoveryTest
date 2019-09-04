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
            /*var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();
            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage() {
                                            StatusCode = HttpStatusCode.OK,
                                            Content = new StringContent(JsonConvert.SerializeObject(new AuthResponse()), 
                                            Encoding.UTF8, "application/json") 
                                        });
            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);
            
            httpClientFactoryMock.CreateClient().Returns(fakeHttpClient);
            var azureAuthentication = new AzureAuthentication(config, httpClientFactoryMock);*/
            var mockAzureClient = Substitute.For<IAzureClient>();
            mockAzureClient.AzureGet(Arg.Any<string>(), Arg.Any<string>()).Returns(Task.FromResult(JsonConvert.SerializeObject(new StorageAccountList())));
            var storageAccountService = new StorageAccountService(config, mockAzureClient, resources);
            var l = await storageAccountService.GetStorageAccounts();  
            Console.Write(l.ToString());        
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
