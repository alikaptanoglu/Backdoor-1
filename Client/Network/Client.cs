using Client.Config;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client.Network
{
    internal static class Client
    {
        private static TcpClient _Client = null;

        internal static bool Connected { private set; get; } = false;

        internal static void Connect(string _IP, int _PORT)
        {
            while (true)
            {
                try
                {
                    _Client = new TcpClient();
                    _Client.Connect(_IP, _PORT);

                    if (Connected = _Client.Connected)
                        break;
                }
                catch
                {
                    _Client.Close();

                    Thread.Sleep(Settings.RECONNECT_DELAY);
                }
            }
        }

        internal static void Send(string _Data)
        {
            NetworkStream _Stream = _Client.GetStream();

            byte[] _Data_Bytes = Encoding.UTF8.GetBytes(_Data);

            _Stream.Write(_Data_Bytes, 0x0, _Data_Bytes.Length);
        }

        internal static string Receive()
        {
            NetworkStream _Stream = _Client.GetStream();

            byte[] _Data = new byte[0x800 * 0x800];

            int _Bytes = _Stream.Read(_Data, 0x0, _Data.Length);

            return Encoding.UTF8.GetString(_Data, 0x0, _Bytes);
        }
    }
}