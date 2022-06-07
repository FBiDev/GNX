using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Diagnostics;
using System.Globalization;

namespace System
{
    public static class Cmd
    {
        public static string Execute(string exeCmd)
        {
            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                    StandardErrorEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    FileName = "cmd.exe",
                    Arguments = "/C " + exeCmd,
                    //WorkingDirectory = "",
                },
            };
            process.Start();

            string output = exeCmd + Environment.NewLine + process.StandardError.ReadToEnd() + Environment.NewLine + process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            process.Dispose();
            return output;
        }
    }
}
