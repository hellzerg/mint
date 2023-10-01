using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mint
{
    public class SettingsJson
    {
        public Theme Theme { get; set; }
        public bool AutoStart { get; set; }

        public List<string> AutoWatchPaths
        {
            get; set;
        }
    }

    internal class Options
    {
        internal static Color ForegroundColor = Color.FromArgb(153, 102, 204);
        internal static Color ForegroundAccentColor = Color.FromArgb(134, 89, 179);

        internal static Color BackAccentColor = Color.FromArgb(45, 45, 45);
        internal static Color BackgroundColor = Color.FromArgb(20, 20, 20);

        internal readonly static string ThemeFlag = "themeable";

        internal static string AppsStructureFile = Application.StartupPath + "\\Apps.json";

        readonly static string _settingsFile = Application.StartupPath + "\\Mint.json";

        internal static SettingsJson CurrentOptions = new SettingsJson();

        internal static void ApplyTheme(Form f)
        {
            switch (CurrentOptions.Theme)
            {
                case Theme.Amber:
                    SetTheme(f, Color.FromArgb(195, 146, 0), Color.FromArgb(171, 128, 0));
                    break;
                case Theme.Jade:
                    SetTheme(f, Color.FromArgb(70, 175, 105), Color.FromArgb(61, 153, 92));
                    break;
                case Theme.Ruby:
                    SetTheme(f, Color.FromArgb(205, 22, 39), Color.FromArgb(155, 17, 30));
                    break;
                case Theme.Silver:
                    SetTheme(f, Color.Gray, Color.DimGray);
                    break;
                case Theme.Azurite:
                    SetTheme(f, Color.FromArgb(0, 127, 255), Color.FromArgb(0, 111, 223));
                    break;
                case Theme.Amethyst:
                    SetTheme(f, Color.FromArgb(153, 102, 204), Color.FromArgb(134, 89, 179));
                    break;
            }
        }


        internal static void AddPathToWatcher(string path)
        {
            if (!Directory.Exists(path))
            {   MessageBox.Show("You cant add  non exists directory ");
                return;
            }

            CurrentOptions.AutoWatchPaths.Add(path);
            
        }
        private static void SetTheme(Form f, Color c1, Color c2)
        {
            dynamic c;
            ForegroundColor = c1;
            ForegroundAccentColor = c2;

            Utilities.GetSelfAndChildrenRecursive(f).ToList().ForEach(x => 
            {
                c = x;

                if (x is Button)
                {
                    c.BackColor = c1;
                    c.FlatAppearance.BorderColor = c1;
                    c.FlatAppearance.MouseDownBackColor = c2;
                    c.FlatAppearance.MouseOverBackColor = c2;
                    c.FlatAppearance.BorderSize = 0;
                }
                if (x is Label || x is CheckBox || x is RadioButton)
                {
                    if ((string)c.Tag == ThemeFlag)
                    {
                        c.ForeColor = c1;
                    }
                }
                if (x is LinkLabel)
                {
                    if ((string)c.Tag == ThemeFlag)
                    {
                        c.LinkColor = c1;
                        c.VisitedLinkColor = c1;
                        c.ActiveLinkColor = c2;
                    }
                }
                c.Invalidate();
            });
        }

        internal static void SaveSettings()
        {
            if (File.Exists(_settingsFile))
            {
                File.Delete(_settingsFile);

                using (FileStream fs = File.Open(_settingsFile, FileMode.OpenOrCreate))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;

                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, CurrentOptions);
                }
            }
        }

        internal static void LoadSettings()
        {
            if (!File.Exists(_settingsFile))
            {
                CurrentOptions.Theme = Theme.Amethyst;
                CurrentOptions.AutoStart = false;

                using (FileStream fs = File.Open(_settingsFile, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;

                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, CurrentOptions);
                }
            }
            else
            {
                CurrentOptions = JsonConvert.DeserializeObject<SettingsJson>(File.ReadAllText(_settingsFile));
            }
        }
    }
}
