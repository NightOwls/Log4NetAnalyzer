using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Log.Web.Mvc.Models.Fusion
{
    public class BaseFusion
    {
        public string XmlSerialize()
        {
            using (var stringWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = true
                };

                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    var xmlSerializer = new XmlSerializer(GetType());
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");

                    xmlSerializer.Serialize(writer, this, ns);
                }

                return stringWriter.ToString();
            }
        }
    }
}