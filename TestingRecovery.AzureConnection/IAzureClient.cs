using System.Threading.Tasks;

namespace RecoveryTest.AzureConnection
{
    public interface IAzureClient
    {
         Task<string> AzureGet(string url, string resourceUrl);
         Task<string> AzureGetResource(string url, string resourceUrl);
    }
}