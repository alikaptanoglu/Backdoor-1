using System.IO;
using System.Net;
using System.Xml;

namespace Client.Utils
{
    internal static class GeoLocation
    {
        internal static readonly string IP = Geo("Response//IP");
        internal static readonly string CountryCode = Geo("Response//CountryCode");
        internal static readonly string CountryName = Geo("Response//CountryName");
        internal static readonly string RegionCode = Geo("Response//RegionCode");
        internal static readonly string RegionName = Geo("Response//RegionName");
        internal static readonly string City = Geo("Response//City");
        internal static readonly string TimeZone = Geo("Response//TimeZone");

        private static string Geo(string _Query_String)
        {
            HttpWebRequest _Request = (HttpWebRequest)WebRequest.Create("http://freegeoip.live/xml/");

            _Request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; rv:48.0) Gecko/20100101 Firefox/48.0";
            _Request.Proxy = null;
            _Request.Timeout = 0x2710;

            using (HttpWebResponse _Response = (HttpWebResponse)_Request.GetResponse())
            {
                using (Stream _Data_Stream = _Response.GetResponseStream())
                {
                    using (StreamReader _Reader = new StreamReader(_Data_Stream))
                    {
                        XmlDocument _DOC = new XmlDocument();

                        _DOC.LoadXml(_Reader.ReadToEnd());

                        return (!string.IsNullOrEmpty(_DOC.SelectSingleNode(_Query_String).InnerXml))
                            ? _DOC.SelectSingleNode(_Query_String).InnerXml
                            : "N/A";
                    }
                }
            }
        }
    }
}