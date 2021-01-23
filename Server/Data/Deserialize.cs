using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Server.Data
{
    internal class Deserialize
    {
        internal DataXML Data_XML { private set; get; } = null;

        private readonly XmlSerializer _XML_Serializer = new XmlSerializer(typeof(DataXML));

        internal void DeserializeObject(string _Data)
        {
            using (MemoryStream _Memory_Stream = new MemoryStream(Encoding.UTF8.GetBytes(_Data)))
            {
                Data_XML = (DataXML)_XML_Serializer.Deserialize(_Memory_Stream);
            }
        }
    }
}