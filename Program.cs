﻿using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestingRecovery.Common;
using Microsoft.Extensions.Logging;
using TestingRecovery.AzureService;
using TestingRecovery.AzureConnection;
using RecoveryTest.AzureConnection;

namespace TestingRecovery.Main
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            var serviceProvider = new ServiceCollection()
                .AddHttpClient()                
                .AddSingleton<IAzureAuthentication, AzureAuthentication>()
                .AddSingleton<IStorageAccountService, StorageAccountService>()
                .AddSingleton<IAccountQueuesService, AccountQueuesService>()
                .AddSingleton<IAzureClient, AzureClient>()
                .AddSingleton<Resources> ()           
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                    loggingBuilder.AddConsole();                    
                })
                .Configure<AppSettings>(configuration)                
                .BuildServiceProvider();

            //do the actual work here
            var storageAccountService = serviceProvider.GetService<IStorageAccountService>();
            var storage = await storageAccountService.GetStorageAccounts();
            foreach(var store in storage.accountList)
            {
                Console.WriteLine(store.Name);
            }
            var accountQueuesService = serviceProvider.GetService<IAccountQueuesService>();
            var queue = await accountQueuesService.GetAccountQueues();
            Console.WriteLine(queue);
        }
    }
}
