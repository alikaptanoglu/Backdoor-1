using Server.Data;
using System;

namespace Server.Utils
{
    internal class IO
    {
        internal void Input(Serialize _Serialize, int _ID) => Network.Server.Send(_Serialize.SerializeObject(), _ID);

        internal void Input(Serialize _Serialize) => Network.Server.Send(_Serialize.SerializeObject());

        internal void Output(Deserialize _Deserialize) => Network.Server.Receive(_Deserialize);

        internal void Output(Deserialize _Deserialize, int _ID)
        {
            _Deserialize.DeserializeObject(Network.Server.Receive(_ID));

            if (!string.IsNullOrEmpty(_Deserialize.Data_XML.Data))
                Console.WriteLine(_Deserialize.Data_XML.Data);

            if (!string.IsNullOrEmpty(_Deserialize.Data_XML.File))
                new ScreenShot().Save(_Deserialize.Data_XML.File);
        }
    }
}