using System;
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
                txtParams.Text = _main.AppsStructure.Apps[_appIndex].AppParams;
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
                for (int i = 0; i < _main.AppsStructure.Apps.Count; i++)
                {
                    if (i == _appIndex) continue;
                }

                _main.AppsStructure.Apps[_appIndex].AppTitle = txtAppTitle.Text;
                _main.AppsStructure.Apps[_appIndex].AppParams = txtParams.Text;

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
    }
}
