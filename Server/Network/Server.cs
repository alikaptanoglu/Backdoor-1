using Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server.Network
{
    internal static class Server
    {
        private static readonly Dictionary<int, TcpClient> _List_Clients = new Dictionary<int, TcpClient>();

        private static TcpListener _Listener = null;

        internal static int ID { private set; get; } = 0x0;

        internal static void Start(int _PORT)
        {
            _Listener = new TcpListener(IPAddress.Any, _PORT);
            _Listener.Start();

            while (true)
            {
                TcpClient _Client = _Listener.AcceptTcpClient();

                _List_Clients.Add(ID, _Client);

                ID++;
            }
        }

        internal static void Send(string _Data, int _ID)
        {
            TcpClient _Client = _List_Clients[_ID];

            NetworkStream _Stream = _Client.GetStream();

            byte[] _Data_Bytes = Encoding.UTF8.GetBytes(_Data);

            _Stream.Write(_Data_Bytes, 0x0, _Data_Bytes.Length);
        }

        internal static void Send(string _Data)
        {
            foreach (TcpClient _Client in _List_Clients.Values)
            {
                NetworkStream _Stream = _Client.GetStream();

                byte[] _Data_Bytes = Encoding.UTF8.GetBytes(_Data);

                _Stream.Write(_Data_Bytes, 0x0, _Data_Bytes.Length);
            }
        }

        internal static string Receive(int _ID)
        {
            TcpClient _Client = _List_Clients[_ID];

            NetworkStream _Stream = _Client.GetStream();

            byte[] _Data = new byte[0x800 * 0x800];

            int _Bytes = _Stream.Read(_Data, 0x0, _Data.Length);

            return Encoding.UTF8.GetString(_Data, 0x0, _Bytes);
        }

        internal static void Receive(Deserialize _Deserialize)
        {
            Console.Write("[List Clients]");

            for (int _ID = 0x0; _ID < _List_Clients.Count; _ID++)
            {
                NetworkStream _Stream = _List_Clients.Values.ElementAt(_ID).GetStream();

                byte[] _Data = new byte[0x800 * 0x800];

                int _Bytes = _Stream.Read(_Data, 0x0, _Data.Length);

                _Deserialize.DeserializeObject(Encoding.UTF8.GetString(_Data, 0x0, _Bytes));

                Console.Write($"\n => [ID: {_ID}] {_Deserialize.Data_XML.Data}");
            }
            Console.Write("\n");
        }

        internal static void Restart()
        {
            ID = 0x0;

            _List_Clients.Clear();
        }
    }
}