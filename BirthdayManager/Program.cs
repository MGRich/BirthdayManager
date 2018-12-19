using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace BirthdayManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length == 1 && args[0] == "1")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BirthdayManager());
            }
            else
            {
                Process p = new Process();
                p.StartInfo.FileName = @"RMGUpdater";
                p.StartInfo.Arguments = "BirthdayManager";
                p.StartInfo.WorkingDirectory = Path.Combine(Directory.GetCurrentDirectory(), "update");
                p.Start();
                Environment.Exit(0);
            }
        }
    }
}