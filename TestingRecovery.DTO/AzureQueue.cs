using System.Xml.Serialization;

namespace RecoveryTest.TestingRecovery.DTO
{
    public class AzureQueue
    {
        [XmlElement("Name")]
        public string Name { get; set; }
    }
}