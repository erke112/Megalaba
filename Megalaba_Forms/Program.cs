using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Megalaba_Forms
{

    static class Program
    {
        static Type com1 = Type.GetTypeFromProgID("Megalaba_COM.ComClass1");
        static dynamic com1Instance = Activator.CreateInstance(com1);
        /// <summary>
        /// The main entry point for the application.
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
