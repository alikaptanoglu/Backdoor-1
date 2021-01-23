using System;
using System.Xml.Serialization;

namespace Client.Data
{
    [Serializable, XmlRoot("DataXML")]
    public class DataXML
    {
        [XmlElement("Data")]
        public string Data { get; set; }

        [XmlElement("File")]
        public string File { get; set; }

        [XmlElement("Shell")]
        public string Shell { get; set; }

        [XmlElement("Command")]
        public string Command { get; set; }

        public DataXML() { }
    }
}