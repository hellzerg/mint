using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mint
{
    internal static class Utilities
    {
        internal static IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetSelfAndChildrenRecursive(child));
            }

            controls.Add(parent);
            return controls;
        }

        internal static void RegisterAutoStart(bool remove)
        {
            try
            {
                using (RegistryKey k = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (!remove)
                    {
                        k.SetValue("Mint", System.Reflection.Assembly.GetEntryAssembly().Location);
                    }
                    else
                    {
                        k.DeleteValue("Mint", false);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Permissions are needed. Please try running Mint as administrator!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
