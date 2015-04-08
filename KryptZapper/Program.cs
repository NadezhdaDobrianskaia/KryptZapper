using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KryptZapper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string[] args = Environment.GetCommandLineArgs();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormParent(args));
            }
            catch ( Exception e )
            {
                Console.WriteLine("Exception Occured", e);
            }
           
        }
    }
}
