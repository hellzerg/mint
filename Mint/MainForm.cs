using IWshRuntimeLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Mint
{
    public partial class MainForm : Form
    {
        internal AppsStructure AppsStructure;

        readonly string _latestVersionLink = "https://raw.githubusercontent.com/hellzerg/mint/master/version.txt";

        readonly string _noNewVersionMessage = "You already have the latest version!";
        readonly string _betaVersionMessage = "You are using an experimental version!";

        readonly string _deleteAppMessage = "Are you sure you want to delete the following app?\n\n";
        readonly string _deleteAllAppsMessage = "Are you sure you want to delete all apps?";

        bool _allowExit = false;

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

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
            if (System.IO.File.Exists(Options.AppsStructureFile))
            {
                AppsStructure = JsonConvert.DeserializeObject<AppsStructure>(System.IO.File.ReadAllText(Options.AppsStructureFile));
            }
            else
            {
                AppsStructure = new AppsStructure();
                AppsStructure.Apps = new List<App>();

                using (FileStream fs = System.IO.File.Open(Options.AppsStructureFile, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;

                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, AppsStructure);
                }
            }
        }

        private void SaveAppsStructure()
        {
            System.IO.File.WriteAllText(Options.AppsStructureFile, string.Empty);

            using (FileStream fs = System.IO.File.Open(Options.AppsStructureFile, FileMode.OpenOrCreate))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, AppsStructure);
            }
        }

        private void LoadAppsList()
        {
            listApps.Items.Clear();

            if (AppsStructure != null)
            {
                if (AppsStructure.Apps != null)
                {
                    foreach (App x in AppsStructure.Apps)
                    {
                        listApps.Items.Add(x.AppTitle);
                    }
                }
            }

            label3.Text = string.Format("Apps ({0})", AppsStructure.Apps.Count);
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

            if (AppsStructure.Apps != null)
            {
                ToolStripItem i;
                foreach (App x in AppsStructure.Apps)
                {
                    if (System.IO.File.Exists(x.AppLink))
                    {
                        i = new ToolStripMenuItem(x.AppTitle, (Icon.ExtractAssociatedIcon(x.AppLink)).ToBitmap());
                    }
                    else
                    {
                        i = new ToolStripMenuItem(x.AppTitle, null);
                    }

                    launcherMenu.Items.Add(i);
                }
            }

            //ToolStripMenuItem pi = new ToolStripMenuItem("Servers");
            //ToolStripMenuItem si = new ToolStripMenuItem("Windows VPS");
            //ToolStripMenuItem si2 = new ToolStripMenuItem("Linux SSH");
            //pi.DropDownItems.Add(si);
            //pi.DropDownItems.Add(si2);
            //launcherMenu.Items.Add(pi);

            launcherMenu.Items.Add("Exit");

            foreach (ToolStripMenuItem y in launcherMenu.Items)
            {
                y.ForeColor = Color.GhostWhite;
            }
        }

        private void AddApp()
        {
            if (!string.IsNullOrEmpty(txtAppLink.Text) && !string.IsNullOrEmpty(txtAppTitle.Text))
            {
                if (System.IO.File.Exists(txtAppLink.Text))
                {
                    if (AppsStructure.Apps.Find(x => x.AppLink == txtAppLink.Text) != null)
                    {
                        MessageBox.Show("Specified app already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (AppsStructure.Apps.Find(x => x.AppTitle == txtAppTitle.Text) != null)
                    {
                        MessageBox.Show("Specified app already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    App app = new App();
                    app.AppLink = txtAppLink.Text;
                    app.AppTitle = txtAppTitle.Text;
                    app.AppParams = txtParams.Text;

                    AppsStructure.Apps.Add(app);
                    SaveAppsStructure();

                    LoadAppsStructure();
                    LoadAppsList();
                    BuildLauncherMenu();

                    txtAppLink.Clear();
                    txtAppTitle.Clear();
                    txtParams.Clear();
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

        private string NewVersionMessage(string latestVersion)
        {
            return string.Format("There is a new version available!\n\nLatest version: {0}\nCurrent version: {1}\n\nDo you want to download it now?", latestVersion, Program.GetCurrentVersionToString());
        }

        private string NewDownloadLink(string latestVersion)
        {
            return string.Format("https://github.com/hellzerg/mint/releases/download/{0}/Mint-{0}.exe", latestVersion);
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
                        // PATCHING PROCESS
                        try
                        {
                            Assembly currentAssembly = Assembly.GetEntryAssembly();

                            if (currentAssembly == null)
                            {
                                currentAssembly = Assembly.GetCallingAssembly();
                            }

                            string appFolder = Path.GetDirectoryName(currentAssembly.Location);
                            string appName = Path.GetFileNameWithoutExtension(currentAssembly.Location);
                            string appExtension = Path.GetExtension(currentAssembly.Location);

                            string archiveFile = Path.Combine(appFolder, appName + "_old" + appExtension);
                            string appFile = Path.Combine(appFolder, appName + appExtension);
                            string tempFile = Path.Combine(appFolder, appName + "_tmp" + appExtension);

                            // DOWNLOAD NEW VERSION
                            client.DownloadFile(NewDownloadLink(latestVersion), tempFile);

                            // ALLOW MINT TO EXIT
                            _allowExit = true;

                            // DELETE PREVIOUS BACK-UP
                            if (System.IO.File.Exists(archiveFile))
                            {
                                System.IO.File.Delete(archiveFile);
                            }

                            // MAKE BACK-UP
                            System.IO.File.Move(appFile, archiveFile);

                            // PATCH
                            System.IO.File.Move(tempFile, appFile);

                            Application.Restart();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
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
                AppsStructure.Apps.RemoveAt(appIndex);

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
                AppsStructure.Apps.Clear();

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
                App appX = AppsStructure.Apps.Find(x => x.AppTitle == app);

                Process p = new Process();
                p.StartInfo.WorkingDirectory = Path.GetDirectoryName(appX.AppLink);
                p.StartInfo.Arguments = appX.AppParams;
                p.StartInfo.FileName = appX.AppLink;
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
            dialog.Filter = "Applications | *.exe; *.lnk";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName.EndsWith(".lnk"))
                {
                    WshShell shell = new WshShell();
                    IWshShortcut link = (IWshShortcut)shell.CreateShortcut(dialog.FileName);

                    txtAppLink.Text = link.TargetPath;
                    txtAppTitle.Text = Path.GetFileNameWithoutExtension(dialog.FileName).Replace(".exe", string.Empty);
                    txtParams.Text = link.Arguments;
                }
                else
                {
                    txtAppLink.Text = dialog.FileName;
                    if (string.IsNullOrEmpty(txtAppTitle.Text)) txtAppTitle.Text = dialog.SafeFileName.Replace(".exe", string.Empty);
                }
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listApps.SelectedIndex > -1)
            {
                ModifyForm f = new ModifyForm(listApps.SelectedIndex, this);
                f.ShowDialog();

                SaveAppsStructure();
                LoadAppsStructure();
                LoadAppsList();
                BuildLauncherMenu();
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            AppsStructure.Apps = AppsStructure.Apps.OrderBy(x => x.AppTitle).ToList();

            SaveAppsStructure();

            LoadAppsStructure();
            LoadAppsList();
            BuildLauncherMenu();
        }

        private void listApps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listApps.SelectedIndex > -1)
            {
                ModifyForm f = new ModifyForm(listApps.SelectedIndex, this);
                f.ShowDialog();

                SaveAppsStructure();
                LoadAppsStructure();
                LoadAppsList();
                BuildLauncherMenu();
            }
        }
    }
}
