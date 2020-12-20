using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mint
{
    [Serializable]
    public class AppsStructure
    {
        public List<App> Apps { get; set; }

        public AppsStructure() { }

        public AppsStructure(List<App> apps)
        {
            Apps = apps;
        }
    }

    [Serializable]
    public class App
    {
        public string AppTitle { get; set; }
        public string AppLink { get; set; }
        public string AppParams { get; set; }
    }
}
