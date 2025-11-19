using System.Xml;

namespace SYNAPSE.API.Utilidade
{
    public class Constant
    {
        public static string? Connection { get; set; }

        public string ConfigFilePath { set
            {
                    XmlDocument xml = new();
                    xml.Load(value);
                    XmlNode? node = xml.DocumentElement?.SelectSingleNode("connectionStrings/add[@name='SYNAPSE']");
                    Connection = node?.Attributes?["connectionString"]?.Value;
            } 
        } 
    }
}
