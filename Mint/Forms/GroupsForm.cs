using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mint
{
    public partial class GroupsForm : Form
    {
        AppsStructure _structure;

        public GroupsForm(AppsStructure appsstruct)
        {
            InitializeComponent();
            Options.ApplyTheme(this);

            _structure = appsstruct;

            groupBox.Items.Clear();
            if (_structure.Groups != null)
            {
                groupBox.Items.AddRange(_structure.Groups.ToArray());
                if (_structure.Groups.Count > 0)
                {
                    this.Text += $" ({_structure.Groups.Count} groups)";
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
                serializer.Serialize(jw, _structure);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGroup.Text.Trim())) return;

            if (_structure.Groups == null) _structure.Groups = new List<string>();

            _structure.Groups.Add(txtGroup.Text.Trim());
            groupBox.Items.Add(txtGroup.Text.Trim());

            SaveAppsStructure();

            txtGroup.Clear();
        }

        private void GroupsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (_structure.Groups != null)
            {
                _structure.Groups = _structure.Groups.OrderBy(x => x).ToList();
                SaveAppsStructure();

                groupBox.Items.Clear();
                if (_structure.Groups != null) groupBox.Items.AddRange(_structure.Groups.ToArray());
            }
        }
    }
}
