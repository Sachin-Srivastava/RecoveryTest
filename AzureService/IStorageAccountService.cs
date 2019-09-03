using System.Collections.Generic;
using System.Threading.Tasks;
using RecoveryTest.DTO;

namespace TestingRecovery.AzureService
{
    public interface IStorageAccountService
    {
        Task<StorageAccountList> GetStorageAccounts();
    }
}