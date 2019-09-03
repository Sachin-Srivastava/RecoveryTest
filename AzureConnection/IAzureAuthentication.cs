using System.Threading.Tasks;

namespace TestingRecovery.AzureConnection
{
    public interface IAzureAuthentication
    {
        Task<string> GetTokenAsync(string resourceUrl);        
    }
}