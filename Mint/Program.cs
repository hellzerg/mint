using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mint
{
    static class Program
    {
        /* VERSION PROPERTIES */
        /* DO NOT LEAVE THEM EMPTY */

        // Enter current version here
        internal readonly static float Major = 1;
        internal readonly static float Minor = 3;

        /* END OF VERSION PROPERTIES */

        internal static string GetCurrentVersionToString()
        {
            return Major.ToString() + "." + Minor.ToString();
        }

        internal static float GetCurrentVersion()
        {
            return float.Parse(GetCurrentVersionToString());
        }

        const string _jsonAssembly = @"Mint.Newtonsoft.Json.dll";

        const string _mutexGuid = "{DEADMOON-0EFC7B9A-D7FC-437F-B4B3-0118C643FE19-MINT}";
        static bool _notRunning;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Mutex m = new Mutex(true, _mutexGuid, out _notRunning))
            {
                if (_notRunning)
                {
                    EmbeddedAssembly.Load(_jsonAssembly, _jsonAssembly.Replace("Mint.", string.Empty));
                    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

                    Options.LoadSettings();
                    Application.Run(new MainForm());
                }
                else
                {
                    MessageBox.Show("Mint is already running in the background!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            } 
        }

        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }
    }
}
