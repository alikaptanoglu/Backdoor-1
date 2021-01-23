using System.IO;
using System.Xml.Serialization;

namespace Client.Data
{
    internal class Serialize
    {
        internal readonly DataXML Data_XML = new DataXML();

        private readonly XmlSerializer _XML_Serializer = new XmlSerializer(typeof(DataXML));

        internal string SerializeObject()
        {
            using (MemoryStream _Memory_Stream = new MemoryStream())
            {
                _XML_Serializer.Serialize(_Memory_Stream, Data_XML);

                _Memory_Stream.Position = 0x0;

                using (StreamReader _Stream_Reader = new StreamReader(_Memory_Stream))
                {
                    return _Stream_Reader.ReadToEnd();
                }
            }
        }
    }
}