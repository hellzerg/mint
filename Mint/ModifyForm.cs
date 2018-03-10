using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mint
{
    public partial class ModifyForm : Form
    {
        int _appIndex;
        MainForm _main;

        public ModifyForm(int appIndex, MainForm main)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            Options.ApplyTheme(this);

            _appIndex = appIndex;
            _main = main;

            if (_appIndex > -1)
            {
                txtAppTitle.Text = _main.AppsStructure.Apps[_appIndex].AppTitle;
                txtAppLink.Text = _main.AppsStructure.Apps[_appIndex].AppLink;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModifyForm_Load(object sender, EventArgs e)
        {

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

        private void ModifyAppEntry()
        {
            if (!string.IsNullOrEmpty(txtAppLink.Text) && !string.IsNullOrEmpty(txtAppTitle.Text))
            {
                if (File.Exists(txtAppLink.Text))
                {
                    for (int i = 0; i < _main.AppsStructure.Apps.Count; i++)
                    {
                        if (i == _appIndex) continue;

                        if (_main.AppsStructure.Apps[i].AppLink == txtAppLink.Text || _main.AppsStructure.Apps[i].AppTitle == txtAppTitle.Text)
                        {
                            MessageBox.Show("Specified app already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    _main.AppsStructure.Apps[_appIndex].AppTitle = txtAppTitle.Text;
                    _main.AppsStructure.Apps[_appIndex].AppLink = txtAppLink.Text;

                    this.Close();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            ModifyAppEntry();
        }
    }
}
