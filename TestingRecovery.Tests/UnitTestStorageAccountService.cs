using System;
using Xunit;
using TestingRecovery.AzureService;
using Microsoft.Extensions.Options;
using TestingRecovery.Common;
using System.Threading.Tasks;
using RecoveryTest.AzureConnection;

namespace TestingRecovery.Tests
{
    public class UnitTestStorageAccountService
    {
        [Fact]
        public void Test1()
        {
            var someOptions = Options.Create(new AppSettings());
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
