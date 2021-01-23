using System;
using System.Diagnostics;

namespace Client.Utils
{
    internal class Privilege
    {
        internal void Elevate()
        {
            if (SysInfo.Privilege.Equals("User"))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd",
                    Verb = "runas",
                    Arguments = "/k START \"\" \"" + SysInfo.Application + "\"",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = true
                });
                Environment.Exit(0x0);
            }
        }
    }
}