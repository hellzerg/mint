﻿using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Windows.Forms;

namespace Mint
{
    public partial class ModifyForm : Form
    {
        int _appIndex;
       // MainForm _main;

        public ModifyForm(int appIndex)//, //MainForm main)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            Options.ApplyTheme(this);

            _appIndex = appIndex;
            //_main = main;

            if (_appIndex > -1)
            {
                txtAppTitle.Text = Program._AppsStructure.Apps[_appIndex].AppTitle;
                txtParams.Text = Program._AppsStructure.Apps[_appIndex].AppParams;
                txtLink.Text = Program._AppsStructure.Apps[_appIndex].AppLink;

                if (Program._AppsStructure.Groups != null)
                {
                    groupBox.Items.AddRange(Program._AppsStructure.Groups.ToArray());
                    groupBox.Text = Program._AppsStructure.Apps[_appIndex].AppGroup;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModifyForm_Load(object sender, EventArgs e)
        {

        }

        private void ModifyAppEntry()
        {
            if (!string.IsNullOrEmpty(txtAppTitle.Text))
            {
                // what the fuck is that ?...
                //for (int i = 0; i < _main._AppsStructure.Apps.Count; i++)
                //{
                //    if (i == _appIndex) continue;
                //}

                Program._AppsStructure.Apps[_appIndex].AppTitle = txtAppTitle.Text;
                Program._AppsStructure.Apps[_appIndex].AppParams = txtParams.Text;
                Program._AppsStructure.Apps[_appIndex].AppLink = txtLink.Text;
                Program._AppsStructure.Apps[_appIndex].AppGroup = groupBox.Text;

                this.Close();
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

                    txtLink.Text = link.TargetPath;
                    txtAppTitle.Text = Path.GetFileNameWithoutExtension(dialog.FileName).Replace(".exe", string.Empty);
                    txtParams.Text = link.Arguments;
                }
                else
                {
                    txtLink.Text = dialog.FileName;
                    if (string.IsNullOrEmpty(txtAppTitle.Text)) txtAppTitle.Text = dialog.SafeFileName.Replace(".exe", string.Empty);
                }
            }
        }
    }
}
