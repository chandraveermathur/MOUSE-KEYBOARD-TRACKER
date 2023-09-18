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
        // Define the path to the Python script
        private static string pythonScriptPath = "C:\\Users\\chand\\Desktop\\Music-player\\simple-music-player-app-in-c-sharp\\MusicPlayerApp\\activity-tracker.py";
        
        [STAThread]
        static void Main()
        {
            // Generate a unique log file name based on timestamp
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string logFolder = "mouse-logs";
            string logFileName = $"mouse_activity_log_{timestamp}.txt";

            // Create a folder named 'mouse-logs' if it doesn't exist
            System.IO.Directory.CreateDirectory(logFolder);

            // Start the Python script with the generated log file name
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"{pythonScriptPath} \"{logFolder}/{logFileName}\"",
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