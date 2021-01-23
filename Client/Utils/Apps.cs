using System.Collections.Generic;
using System.Management;

namespace Client.Utils
{
    internal class Apps
    {
        internal string Get(string _Query_String)
        {
            List<string> Application_List = new List<string>();

            using (ManagementObjectSearcher _MOB = new ManagementObjectSearcher(_Query_String))
            {
                foreach (ManagementObject _APP in _MOB.Get())
                    Application_List.Add(_APP["Name"].ToString());
            }
            return string.Join("\n\t ", Application_List.ToArray());
        }
    }
}