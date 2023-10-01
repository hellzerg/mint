using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using Newtonsoft.Json;

namespace Mint
{
    internal static class Automint
    {
        public static List<App> LoadFolder(string path)
        {
            List<App> ff = FindExeFiles(path);
            
            ff.AddRange(FindLinks(path));
            
           /* var xtop = ff.GroupBy(x => x.AppGroup)
            .OrderByDescending(group => group.Count())
            .Take(20).Select(group => group.Key);
           */
            foreach (var item in ff)
            {
               if(!Program._AppsStructure.Groups.Contains(item.AppGroup))
                {
                    Program._AppsStructure.Groups.Add(item.AppGroup);
                }
            }
            
          


            Program._AppsStructure.Apps.AddRange(ff);




            return ff;
        }

        private static List<App> FindLinks(string directoryPath)
        {
            List<App> appList = new List<App>();

           
        foreach (string filePath in Directory.GetFiles(directoryPath, "*.lnk", SearchOption.AllDirectories))
        {
            string targetPath = GetShortcutTarget(filePath);
            if (!string.IsNullOrEmpty(targetPath) && System.IO.File.Exists(targetPath) && targetPath.ToLower().EndsWith(".exe"))
            {
                App app = new App
                {
                    AppTitle = Path.GetFileNameWithoutExtension(targetPath),
                    AppLink = targetPath,
                    AppGroup = Path.GetDirectoryName(targetPath),
                    AppParams = ""
                };

                appList.Add(app);
            }
        }
            return appList;
        }

        private static List<App> FindExeFiles(string directoryPath)
        {
            List<App> appList = new List<App>();

            foreach (string filePath in Directory.GetFiles(directoryPath, "*.exe", SearchOption.AllDirectories))
            {
                App app = new App
                {
                    AppTitle = Path.GetFileNameWithoutExtension(filePath),
                    AppLink = filePath,
                    //AppGroup = "Auto", // Değiştirebilirsiniz.
                    AppGroup =  Path.GetFileName(Path.GetDirectoryName(filePath)) ,
                    AppParams = ""
                };

                appList.Add(app);
            }
            return appList;
        }

        private static string GetShortcutTarget(string shortcutPath)
        {
            string targetPath = "";
            try
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                targetPath = shortcut.TargetPath;
            }
            catch (Exception ee)
            {
                if (Debugger.IsAttached)
                    Console.WriteLine(ee.Message); // Kısayolun hedefi alınamazsa işleme devam edin.
            }
            return targetPath;
        }

        private static bool SaveJson(List<App> appList, string outputPath = "Apps.json")
        {
            try
            {
                string jsonOutput = JsonConvert.SerializeObject(appList, Formatting.Indented);

                    System.IO.File.WriteAllText(outputPath, jsonOutput);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }

    internal class FolderFindings
    {
        public string Path;
        public string Errors;

        public List<App> ExeFiles
        {
            get; set;
        }

        public List<App> Links
        {
            get; set;
        }
    }
}