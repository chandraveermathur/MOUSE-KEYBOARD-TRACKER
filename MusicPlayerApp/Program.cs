using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayerApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static string pythonScriptPath = "C:\\Users\\chand\\Desktop\\Music-player\\simple-music-player-app-in-c-sharp\\MusicPlayerApp";
        [STAThread]
        static void Main()
        {
            // Start the Python script as a separate process
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = pythonScriptPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            Process pythonProcess = new Process
            {
                StartInfo = startInfo
            };
            pythonProcess.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MusicPlayerApp());
            // Add code here to run when the application is closed

            // Stop the Python process when the C# application is closed
            pythonProcess.Kill();
        }
    }
}
