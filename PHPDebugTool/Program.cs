using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PHPDebugTool
{
    public class Run
    {
        private Process proc = null;

        public Run()
        {
            proc = new Process();
        }

        public string RunProgram(string FileName, string arg)
        {
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = FileName;
            proc.StartInfo.Arguments = arg;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();   
            string outStr = proc.StandardOutput.ReadToEnd();
            proc.Close();
            return outStr;
        }
    }

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
