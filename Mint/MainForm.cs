using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Mint
{
    public partial class MainForm : Form
    {
        readonly string _latestVersionLink = "https://raw.githubusercontent.com/hellzerg/mint/master/version.txt";
        readonly string _releasesLink = "https://github.com/hellzerg/mint/releases";

        readonly string _noNewVersionMessage = "You already have the latest version!";
        readonly string _betaVersionMessage = "You are using an experimental version!";

        readonly string _deleteAppMessage = "Are you sure you want to delete the following app?\n\n";
        readonly string _deleteAllAppsMessage = "Are you sure you want to delete all apps?";

        AppsStructure _appsStructure;

        bool _allowExit = false;

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            Options.ApplyTheme(this);
            launcherMenu.Renderer = new ToolStripRendererMaterial();

            LoadAppsStructure();
            LoadAppsList();
            BuildLauncherMenu();

            LoadOptions();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblversion.Text += Program.GetCurrentVersionToString();
        }

        private void LoadAppsStructure()
        {
            if (File.Exists(Options.AppsStructureFile))
            {
                _appsStructure = JsonConvert.DeserializeObject<AppsStructure>(File.ReadAllText(Options.AppsStructureFile));
            }
            else
            {
                _appsStructure = new AppsStructure();
                _appsStructure.Apps = new List<App>();

                using (FileStream fs = File.Open(Options.AppsStructureFile, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;

                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, _appsStructure);
                }
            }
        }

        private void SaveAppsStructure()
        {
            File.WriteAllText(Options.AppsStructureFile, string.Empty);

            using (FileStream fs = File.Open(Options.AppsStructureFile, FileMode.OpenOrCreate))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, _appsStructure);
            }
        }

        private void LoadAppsList()
        {
            listApps.Items.Clear();

            if (_appsStructure != null)
            {
                if (_appsStructure.Apps != null)
                {
                    foreach (App x in _appsStructure.Apps)
                    {
                        listApps.Items.Add(x.AppTitle);
                    }
                }
            }
        }

        private void LoadOptions()
        {
            switch (Options.CurrentOptions.Theme)
            {
                case Theme.Caramel:
                    radioCaramel.Checked = true;
                    break;
                case Theme.Lime:
                    radioLime.Checked = true;
                    break;
                case Theme.Magma:
                    radioMagma.Checked = true;
                    break;
                case Theme.Minimal:
                    radioMinimal.Checked = true;
                    break;
                case Theme.Ocean:
                    radioOcean.Checked = true;
                    break;
                case Theme.Zerg:
                    radioZerg.Checked = true;
                    break;
            }

            checkAutoStart.Checked = Options.CurrentOptions.AutoStart;
        }

        private void BuildLauncherMenu()
        {
            launcherMenu.Items.Clear();

            if (_appsStructure.Apps != null)
            {
                foreach (App x in _appsStructure.Apps)
                {
                    launcherMenu.Items.Add(x.AppTitle);
                }
            }

            launcherMenu.Items.Add("Exit");

            foreach (ToolStripItem y in launcherMenu.Items)
            {
                y.ForeColor = Color.White;
            }
        }

        private void AddApp()
        {
            if (!string.IsNullOrEmpty(txtAppLink.Text) && !string.IsNullOrEmpty(txtAppTitle.Text))
            {
                if (File.Exists(txtAppLink.Text))
                {
                    if (_appsStructure.Apps.Find(x => x.AppLink == txtAppLink.Text) != null)
                    {
                        MessageBox.Show("Specified app already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (_appsStructure.Apps.Find(x => x.AppTitle == txtAppTitle.Text) != null)
                    {
                        MessageBox.Show("Specified app already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    App app = new App();
                    app.AppLink = txtAppLink.Text;
                    app.AppTitle = txtAppTitle.Text;

                    _appsStructure.Apps.Add(app);
                    SaveAppsStructure();

                    LoadAppsStructure();
                    LoadAppsList();
                    BuildLauncherMenu();

                    txtAppLink.Clear();
                    txtAppTitle.Clear();
                }
                else
                {
                    MessageBox.Show("Specified app does not exist!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please fill both app title & location!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string NewVersionMessage(string latest)
        {
            return string.Format("There is a new version available!\n\nLatest version: {0}\nCurrent version: {1}\n\nDo you want to download it now?", latest, Program.GetCurrentVersionToString());
        }

        private void CheckForUpdate()
        {
            WebClient client = new WebClient
            {
                Encoding = Encoding.UTF8
            };

            string latestVersion = string.Empty;
            try
            {
                latestVersion = client.DownloadString(_latestVersionLink);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (!string.IsNullOrEmpty(latestVersion))
            {
                if (float.Parse(latestVersion) > Program.GetCurrentVersion())
                {
                    if (MessageBox.Show(NewVersionMessage(latestVersion), "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Process.Start(_releasesLink);
                        }
                        catch { }
                    }
                }
                else if (float.Parse(latestVersion) == Program.GetCurrentVersion())
                {
                    MessageBox.Show(_noNewVersionMessage, "No update available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(_betaVersionMessage, "No update available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteAppItem(string app, int appIndex)
        {
            if (MessageBox.Show(_deleteAppMessage + app, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listApps.Items.RemoveAt(appIndex);
                _appsStructure.Apps.RemoveAt(appIndex);

                SaveAppsStructure();
                LoadAppsStructure();

                LoadAppsList();
                BuildLauncherMenu();
            }
        }

        private void DeleteAllAppItems()
        {
            if (MessageBox.Show(_deleteAllAppsMessage, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listApps.Items.Clear();
                _appsStructure.Apps.Clear();

                SaveAppsStructure();
                LoadAppsStructure();

                LoadAppsList();
                BuildLauncherMenu();
            }
        }

        private void LaunchApp(string app)
        {
            try
            {
                string fileName = _appsStructure.Apps.Find(x => x.AppTitle == app).AppLink;
                string filePath = Path.GetDirectoryName(fileName);
                
                Process p = new Process();
                p.StartInfo.WorkingDirectory = filePath;
                p.StartInfo.FileName = fileName;
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Options.CurrentOptions.AutoStart = checkAutoStart.Checked;
            Utilities.RegisterAutoStart(!Options.CurrentOptions.AutoStart);
        }

        private void radioOcean_CheckedChanged(object sender, EventArgs e)
        {
            Options.CurrentOptions.Theme = Theme.Ocean;
            Options.ApplyTheme(this);
        }

        private void radioMagma_CheckedChanged(object sender, EventArgs e)
        {
            Options.CurrentOptions.Theme = Theme.Magma;
            Options.ApplyTheme(this);
        }

        private void radioZerg_CheckedChanged(object sender, EventArgs e)
        {
            Options.CurrentOptions.Theme = Theme.Zerg;
            Options.ApplyTheme(this);
        }

        private void radioCaramel_CheckedChanged(object sender, EventArgs e)
        {
            Options.CurrentOptions.Theme = Theme.Caramel;
            Options.ApplyTheme(this);
        }

        private void radioLime_CheckedChanged(object sender, EventArgs e)
        {
            Options.CurrentOptions.Theme = Theme.Lime;
            Options.ApplyTheme(this);
        }

        private void radioMinimal_CheckedChanged(object sender, EventArgs e)
        {
            Options.CurrentOptions.Theme = Theme.Minimal;
            Options.ApplyTheme(this);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_allowExit)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                SaveAppsStructure();
                Options.SaveSettings();
            }
        }

        private void launcherMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Exit")
            {
                _allowExit = true;

                SaveAppsStructure();
                Options.SaveSettings();

                Application.Exit();
            }
            else
            {
                _allowExit = false;
                LaunchApp(e.ClickedItem.Text);
            }
        }

        private void launcherIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
                this.Activate();
                this.Focus();
            }
        }

        private void btnLocate_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Mint | Select an application...";
            dialog.Filter = "Applications | *.exe";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtAppLink.Text = dialog.FileName;
                if (string.IsNullOrEmpty(txtAppTitle.Text)) txtAppTitle.Text = dialog.SafeFileName.Replace(".exe", string.Empty);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddApp();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CheckForUpdate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listApps.Items.Count > 0)
            {
                if (listApps.SelectedIndex >= 0)
                {
                    DeleteAppItem(listApps.SelectedItem.ToString(), listApps.SelectedIndex);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (listApps.Items.Count > 0)
            {
                DeleteAllAppItems();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog(this);
        }
    }
}
