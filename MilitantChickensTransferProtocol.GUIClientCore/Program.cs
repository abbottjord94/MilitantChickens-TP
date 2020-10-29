using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilitantChickensTranferProtocol.Library;
using MilitantChickensTransferProtocol.Terminal;

namespace MilitantChickensTransferProtocol.GUIClientCore
{
    static class Program
    {
        public static Client client;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                client = new Client();
                client.Connect("127.0.0.1", 9001);
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
