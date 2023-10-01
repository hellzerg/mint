using System;
using System.Collections.Generic;

namespace Mint
{
    [Serializable]
    public class AppsStructure
    {
        public List<App> Apps
        {
            get; set;
        }

        public List<string> Groups
        {
            get; set;
        }

        public AppsStructure()
        {
        }

        public AppsStructure(List<App> apps)
        {
            Apps = apps;
        }
    }

    [Serializable]
    public class App
    {
        public string AppTitle
        {
            get; set;
        }

        public string AppLink
        {
            get; set;
        }

        public string AppGroup
        {
            get; set;
        }

        public string AppParams
        {
            get; set;
        }
    }
}