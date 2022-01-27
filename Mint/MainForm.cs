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
using File = System.IO.File;

namespace Mint
{
    public partial class MainForm : Form
    {
        internal AppsStructure _AppsStructure;

        readonly string _latestVersionLink = "https://raw.githubusercontent.com/hellzerg/mint/master/version.txt";

        readonly string _noNewVersionMessage = "You already have the latest version!";
        readonly string _betaVersionMessage = "You are using an experimental version!";

        readonly string _deleteAppMessage = "Are you sure you want to delete the following app?\n\n";
        readonly string _deleteAllAppsMessage = "Are you sure you want to delete all apps?";

        bool _allowExit = false;
        bool _allowManualSort = false;

        ToolStripMenuItem _ExitItem;

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            Options.ApplyTheme(this);
            launcherMenu.Renderer = new ToolStripRendererMaterial();
            sortMenu.Renderer = new ToolStripRendererMaterial();

            LoadAppsStructure();
            LoadAppsList();
            BuildExitItem();
            BuildLauncherMenu();

            LoadOptions();
            lblversion.Text += Program.GetCurrentVersionToString();

            this.AllowDrop = true;
            listApps.AllowDrop = _allowManualSort;
        }

        private void BuildExitItem()
        {
            _ExitItem = new ToolStripMenuItem();
            _ExitItem.ForeColor = Color.GhostWhite;
            _ExitItem.Font = new Font("Segoe UI Semibold", 10f);
            _ExitItem.Text = "Exit";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadAppsStructure()
        {
            if (System.IO.File.Exists(Options.AppsStructureFile))
            {
                _AppsStructure = JsonConvert.DeserializeObject<AppsStructure>(System.IO.File.ReadAllText(Options.AppsStructureFile));
            }
            else
            {
                _AppsStructure = new AppsStructure();
                _AppsStructure.Apps = new List<App>();
                _AppsStructure.Groups = new List<string>();

                using (FileStream fs = System.IO.File.Open(Options.AppsStructureFile, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(fs))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;

                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, _AppsStructure);
                }
            }
        }

        private void SaveAppsStructure()
        {
            File.WriteAllText(Options.AppsStructureFile, string.Empty);

            using (FileStream fs = System.IO.File.Open(Options.AppsStructureFile, FileMode.OpenOrCreate))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, _AppsStructure);
            }
        }

        private void LoadAppsList()
        {
            listApps.Items.Clear();
            groupBox.Items.Clear();

            if (_AppsStructure != null)
            {
                if (_AppsStructure.Groups != null) groupBox.Items.AddRange(_AppsStructure.Groups.ToArray());

                if (_AppsStructure.Apps != null)
                {
                    foreach (App x in _AppsStructure.Apps)
                    {
                        listApps.Items.Add(x.AppTitle);
                    }
                }
            }

            label3.Text = string.Format("Apps ({0})", _AppsStructure.Apps.Count);
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

            if (_AppsStructure.Apps != null)
            {
                ToolStripMenuItem i;
                ToolStripMenuItem subItem;

                if (_AppsStructure.Groups != null)
                {
                    foreach (string group in _AppsStructure.Groups)
                    {
                        if (_AppsStructure.Apps.Find(a => a.AppGroup == group) == null) continue;

                        i = new ToolStripMenuItem(group, null);
                        i.Name = $"gi_{group}";
                        i.ForeColor = Color.GhostWhite;
                        i.Tag = "GroupItem";
                        launcherMenu.Items.Add(i);
                    }

                    if (_AppsStructure.Groups.Count > 0) launcherMenu.Items.Add("-");
                }

                bool isDeadItem = false;

                foreach (App x in _AppsStructure.Apps.OrderBy(o => o.AppGroup))
                {
                    isDeadItem = !File.Exists(x.AppLink);

                    if (!string.IsNullOrEmpty(x.AppGroup))
                    {
                        subItem = new ToolStripMenuItem(x.AppTitle, !isDeadItem ? Icon.ExtractAssociatedIcon(x.AppLink).ToBitmap() : null);
                        subItem.Click += subItem_Click;
                        if (!isDeadItem)
                        {
                            subItem.ForeColor = Color.GhostWhite;
                        }
                        else
                        {
                            subItem.ForeColor = Color.DimGray;
                            subItem.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Strikeout);
                        }

                        ((ToolStripMenuItem)(launcherMenu.Items[$"gi_{x.AppGroup}"])).DropDownItems.Add(subItem);
                    }
                    else
                    {
                        i = new ToolStripMenuItem(x.AppTitle, !isDeadItem ? (Icon.ExtractAssociatedIcon(x.AppLink)).ToBitmap() : null);
                        if (!isDeadItem)
                        {
                            i.ForeColor = Color.GhostWhite;
                        }
                        else
                        {
                            i.ForeColor = Color.DimGray;
                            i.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Strikeout);
                        }

                        launcherMenu.Items.Add(i);
                    }
                }
            }

            launcherMenu.Items.Add("-");
            launcherMenu.Items.Add(_ExitItem);
        }

        private void subItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem o = (ToolStripMenuItem)sender;
            LaunchApp(o.Text);
        }

        private void AddApp()
        {
            if (!string.IsNullOrEmpty(txtAppLink.Text) && !string.IsNullOrEmpty(txtAppTitle.Text))
            {
                if (System.IO.File.Exists(txtAppLink.Text))
                {
                    if (_AppsStructure.Apps.Find(x => x.AppLink == txtAppLink.Text) != null)
                    {
                        MessageBox.Show("This app already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (_AppsStructure.Apps.Find(x => x.AppTitle == txtAppTitle.Text) != null)
                    {
                        MessageBox.Show("This app already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    App app = new App();
                    app.AppLink = txtAppLink.Text;
                    app.AppTitle = txtAppTitle.Text;
                    app.AppParams = txtParams.Text;
                    app.AppGroup = groupBox.Text;

                    _AppsStructure.Apps.Add(app);
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

                            // DELETE PREVIOUS BACK-UP
                            if (System.IO.File.Exists(archiveFile))
                            {
                                System.IO.File.Delete(archiveFile);
                            }

                            // MAKE BACK-UP
                            System.IO.File.Move(appFile, archiveFile);

                            // PATCH
                            System.IO.File.Move(tempFile, appFile);

                            // BYPASS SINGLE-INSTANCE MECHANISM
                            _allowExit = true;
                            if (Program.MUTEX != null)
                            {
                                Program.MUTEX.ReleaseMutex();
                                Program.MUTEX.Dispose();
                                Program.MUTEX = null;
                            }

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
                _AppsStructure.Apps.RemoveAt(appIndex);

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
                _AppsStructure.Apps.Clear();

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
                App appX = _AppsStructure.Apps.Find(x => x.AppTitle == app);

                if (appX == null) return;
                if (!File.Exists(appX.AppLink)) return;

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

        private void LoadFile(string file)
        {
            if (file.EndsWith(".lnk"))
            {
                WshShell shell = new WshShell();
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(file);

                txtAppLink.Text = link.TargetPath;
                txtAppTitle.Text = Path.GetFileNameWithoutExtension(link.TargetPath);
                txtParams.Text = link.Arguments;
            }
            else if (file.EndsWith(".exe"))
            {
                txtAppLink.Text = file;
                txtAppTitle.Text = Path.GetFileNameWithoutExtension(file);
            }
        }

        private void btnLocate_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Mint | Select an application...";
            dialog.Filter = "Applications | *.exe; *.lnk";

            if (dialog.ShowDialog() == DialogResult.OK) LoadFile(dialog.FileName);
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
                f.ShowDialog(this);

                SaveAppsStructure();
                LoadAppsStructure();
                LoadAppsList();
                BuildLauncherMenu();
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            sortMenu.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void SortByAZ(bool inversed)
        {
            _AppsStructure.Apps = _AppsStructure.Apps.OrderBy(x => x.AppTitle).ToList();
            if (inversed) _AppsStructure.Apps.Reverse();

            SaveAppsStructure();
            LoadAppsStructure();
            LoadAppsList();
            BuildLauncherMenu();
        }

        private void SaveManualSort()
        {
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

        private void btnGroups_Click(object sender, EventArgs e)
        {
            GroupsForm gf = new GroupsForm(_AppsStructure);
            gf.ShowDialog(this);

            groupBox.Items.Clear();
            if (_AppsStructure.Groups != null) groupBox.Items.AddRange(_AppsStructure.Groups.ToArray());
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            try
            {
                LoadFile(files[0]);
            }
            catch { }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void groupBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listApps_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listApps.PointToClient(new Point(e.X, e.Y));
            int index = listApps.IndexFromPoint(point);
            if (index < 0) index = listApps.Items.Count - 1;
            object data = listApps.SelectedItem;

            App a = _AppsStructure.Apps.Find(x => x.AppTitle == data.ToString());
            if (a != null)
            {
                _AppsStructure.Apps.Remove(a);
                _AppsStructure.Apps.Insert(index, a);
            }

            //listApps.Items.Remove(data);
            //listApps.Items.Insert(index, data);

            SaveManualSort();
        }

        private void listApps_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listApps_MouseDown(object sender, MouseEventArgs e)
        {
            if (listApps.SelectedItem == null) return;
            listApps.DoDragDrop(listApps.SelectedItem, DragDropEffects.Move);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SortByAZ(false);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SortByAZ(true);
        }

        private void enableManualSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _allowManualSort = !_allowManualSort;
            listApps.AllowDrop = _allowManualSort;
            
            if (_allowManualSort)
            {
                enableManualSortToolStripMenuItem.Text = "Disable manual sort";
            }
            else
            {
                enableManualSortToolStripMenuItem.Text = "Enable manual sort";
            }
        }
    }
}
