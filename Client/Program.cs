using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwimmingClient;
using SwimmingNetworking.objectprotocol;
using SwimmingServices;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IService server = new ServerObjectProxy("127.0.0.1", 55556);
            ClientController controller = new ClientController(server);
            
            Application.Run(new LoginForm(controller));
        }
    }
}