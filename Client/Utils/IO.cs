using Client.Data;

namespace Client.Utils
{
    internal class IO
    {
        internal void Input(Serialize _Serialize)
        {
            Network.Client.Send(_Serialize.SerializeObject());
        }

        internal void Output(Deserialize _Deserialize)
        {
            _Deserialize.DeserializeObject(Network.Client.Receive());
        }
    }
}