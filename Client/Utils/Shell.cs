using System.Diagnostics;

namespace Client.Utils
{
    internal class Shell
    {
        internal string Write(string _Type, string _Data)
        {
            using (Process _Process = new Process())
            {
                _Process.StartInfo.FileName = _Type;
                _Process.StartInfo.RedirectStandardInput = true;
                _Process.StartInfo.RedirectStandardOutput = true;
                _Process.StartInfo.CreateNoWindow = true;
                _Process.StartInfo.UseShellExecute = false;
                _Process.Start();
                _Process.StandardInput.WriteLine(_Data);
                _Process.StandardInput.Flush();
                _Process.StandardInput.Close();
                _Process.WaitForExit();

                return "\n" + _Process.StandardOutput.ReadToEnd();
            }
        }
    }
}