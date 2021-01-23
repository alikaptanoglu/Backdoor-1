using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Client.Utils
{
    internal class Processes
    {
        internal string Get()
        {
            Dictionary<int, string> Process_List = new Dictionary<int, string>();

            foreach (Process _Process in Process.GetProcesses())
                Process_List.Add(_Process.Id, _Process.ProcessName);

            return string.Join("\n\t ", Process_List.ToArray().Distinct());
        }

        internal string Kill(int _PID)
        {
            string _ID = $"ID: {Process.GetProcessById(_PID).Id}";
            string _Name = $"Name: {Process.GetProcessById(_PID).ProcessName}";

            Process.GetProcessById(_PID).Kill();

            return $"Killed {_ID}, {_Name}";
        }
    }
}