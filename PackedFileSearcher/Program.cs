using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackedFileSearcher
{
    static class Program
    {
        public static ConsoleWriter consoleWriter;
        public static string tempPath = Path.Combine(Environment.CurrentDirectory, "tempInsideZips");

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (consoleWriter = new ConsoleWriter())
            {
                Console.SetOut(consoleWriter);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());

                try
                {
                    // if application has been closed
                    Directory.Delete(tempPath, true);
                }
                catch { }
            }
        }
    }
}
