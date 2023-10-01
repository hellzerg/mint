﻿namespace Mint
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblversion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.botPanel = new System.Windows.Forms.Panel();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.radioMinimal = new System.Windows.Forms.RadioButton();
            this.radioCaramel = new System.Windows.Forms.RadioButton();
            this.radioLime = new System.Windows.Forms.RadioButton();
            this.radioMagma = new System.Windows.Forms.RadioButton();
            this.radioOcean = new System.Windows.Forms.RadioButton();
            this.radioZerg = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panelApps = new System.Windows.Forms.Panel();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.helperMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locateFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sortByAZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panelAddApp = new System.Windows.Forms.Panel();
            this.btnGroups = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtParams = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLocate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAppTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAppLink = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.launcherIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.launcherMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.checkAutoStart = new Mint.MoonCheck();
            this.listApps = new Mint.MoonList();
            this.groupBox = new Mint.MoonBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.botPanel.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.panelApps.SuspendLayout();
            this.panel2.SuspendLayout();
            this.helperMenu.SuspendLayout();
            this.panelAddApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.AllowDrop = true;
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.Controls.Add(this.btnUpdate);
            this.topPanel.Controls.Add(this.pictureBox1);
            this.topPanel.Controls.Add(this.lblversion);
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(618, 62);
            this.topPanel.TabIndex = 8;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(531, 15);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 31);
            this.btnUpdate.TabIndex = 81;
            this.btnUpdate.Tag = "themeable";
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblversion
            // 
            this.lblversion.AutoSize = true;
            this.lblversion.ForeColor = System.Drawing.Color.Silver;
            this.lblversion.Location = new System.Drawing.Point(72, 37);
            this.lblversion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblversion.Name = "lblversion";
            this.lblversion.Size = new System.Drawing.Size(52, 15);
            this.lblversion.TabIndex = 4;
            this.lblversion.Text = "Version: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(70, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mint";
            // 
            // botPanel
            // 
            this.botPanel.AllowDrop = true;
            this.botPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.botPanel.Controls.Add(this.panelOptions);
            this.botPanel.Controls.Add(this.panelApps);
            this.botPanel.Controls.Add(this.panelAddApp);
            this.botPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.botPanel.Location = new System.Drawing.Point(0, 62);
            this.botPanel.Margin = new System.Windows.Forms.Padding(2);
            this.botPanel.Name = "botPanel";
            this.botPanel.Size = new System.Drawing.Size(618, 557);
            this.botPanel.TabIndex = 9;
            // 
            // panelOptions
            // 
            this.panelOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panelOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptions.Controls.Add(this.checkAutoStart);
            this.panelOptions.Controls.Add(this.radioMinimal);
            this.panelOptions.Controls.Add(this.radioCaramel);
            this.panelOptions.Controls.Add(this.radioLime);
            this.panelOptions.Controls.Add(this.radioMagma);
            this.panelOptions.Controls.Add(this.radioOcean);
            this.panelOptions.Controls.Add(this.radioZerg);
            this.panelOptions.Controls.Add(this.label6);
            this.panelOptions.Location = new System.Drawing.Point(10, 346);
            this.panelOptions.Margin = new System.Windows.Forms.Padding(2);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(296, 200);
            this.panelOptions.TabIndex = 91;
            // 
            // radioMinimal
            // 
            this.radioMinimal.AutoSize = true;
            this.radioMinimal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMinimal.ForeColor = System.Drawing.Color.Gray;
            this.radioMinimal.Location = new System.Drawing.Point(136, 110);
            this.radioMinimal.Margin = new System.Windows.Forms.Padding(2);
            this.radioMinimal.Name = "radioMinimal";
            this.radioMinimal.Size = new System.Drawing.Size(68, 25);
            this.radioMinimal.TabIndex = 84;
            this.radioMinimal.Text = "Silver";
            this.radioMinimal.UseVisualStyleBackColor = true;
            this.radioMinimal.CheckedChanged += new System.EventHandler(this.radioMinimal_CheckedChanged);
            // 
            // radioCaramel
            // 
            this.radioCaramel.AutoSize = true;
            this.radioCaramel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCaramel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(146)))), ((int)(((byte)(0)))));
            this.radioCaramel.Location = new System.Drawing.Point(136, 49);
            this.radioCaramel.Margin = new System.Windows.Forms.Padding(2);
            this.radioCaramel.Name = "radioCaramel";
            this.radioCaramel.Size = new System.Drawing.Size(78, 25);
            this.radioCaramel.TabIndex = 83;
            this.radioCaramel.Text = "Amber";
            this.radioCaramel.UseVisualStyleBackColor = true;
            this.radioCaramel.CheckedChanged += new System.EventHandler(this.radioCaramel_CheckedChanged);
            // 
            // radioLime
            // 
            this.radioLime.AutoSize = true;
            this.radioLime.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioLime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(175)))), ((int)(((byte)(105)))));
            this.radioLime.Location = new System.Drawing.Point(136, 79);
            this.radioLime.Margin = new System.Windows.Forms.Padding(2);
            this.radioLime.Name = "radioLime";
            this.radioLime.Size = new System.Drawing.Size(61, 25);
            this.radioLime.TabIndex = 82;
            this.radioLime.Text = "Jade";
            this.radioLime.UseVisualStyleBackColor = true;
            this.radioLime.CheckedChanged += new System.EventHandler(this.radioLime_CheckedChanged);
            // 
            // radioMagma
            // 
            this.radioMagma.AutoSize = true;
            this.radioMagma.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioMagma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(22)))), ((int)(((byte)(39)))));
            this.radioMagma.Location = new System.Drawing.Point(14, 79);
            this.radioMagma.Margin = new System.Windows.Forms.Padding(2);
            this.radioMagma.Name = "radioMagma";
            this.radioMagma.Size = new System.Drawing.Size(65, 25);
            this.radioMagma.TabIndex = 81;
            this.radioMagma.Text = "Ruby";
            this.radioMagma.UseVisualStyleBackColor = true;
            this.radioMagma.CheckedChanged += new System.EventHandler(this.radioMagma_CheckedChanged);
            // 
            // radioOcean
            // 
            this.radioOcean.AutoSize = true;
            this.radioOcean.Checked = true;
            this.radioOcean.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioOcean.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.radioOcean.Location = new System.Drawing.Point(14, 108);
            this.radioOcean.Margin = new System.Windows.Forms.Padding(2);
            this.radioOcean.Name = "radioOcean";
            this.radioOcean.Size = new System.Drawing.Size(80, 25);
            this.radioOcean.TabIndex = 80;
            this.radioOcean.TabStop = true;
            this.radioOcean.Text = "Azurite";
            this.radioOcean.UseVisualStyleBackColor = true;
            this.radioOcean.CheckedChanged += new System.EventHandler(this.radioOcean_CheckedChanged);
            // 
            // radioZerg
            // 
            this.radioZerg.AutoSize = true;
            this.radioZerg.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioZerg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.radioZerg.Location = new System.Drawing.Point(14, 49);
            this.radioZerg.Margin = new System.Windows.Forms.Padding(2);
            this.radioZerg.Name = "radioZerg";
            this.radioZerg.Size = new System.Drawing.Size(98, 25);
            this.radioZerg.TabIndex = 79;
            this.radioZerg.Text = "Amethyst";
            this.radioZerg.UseVisualStyleBackColor = true;
            this.radioZerg.CheckedChanged += new System.EventHandler(this.radioZerg_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(9, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 21);
            this.label6.TabIndex = 78;
            this.label6.Tag = "themeable";
            this.label6.Text = "Options:";
            // 
            // panelApps
            // 
            this.panelApps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panelApps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelApps.Controls.Add(this.btnSort);
            this.panelApps.Controls.Add(this.btnEdit);
            this.panelApps.Controls.Add(this.panel2);
            this.panelApps.Controls.Add(this.label3);
            this.panelApps.Controls.Add(this.btnDelete);
            this.panelApps.Location = new System.Drawing.Point(310, 14);
            this.panelApps.Margin = new System.Windows.Forms.Padding(2);
            this.panelApps.Name = "panelApps";
            this.panelApps.Size = new System.Drawing.Size(296, 532);
            this.panelApps.TabIndex = 90;
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSort.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSort.FlatAppearance.BorderSize = 0;
            this.btnSort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnSort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSort.ForeColor = System.Drawing.Color.White;
            this.btnSort.Location = new System.Drawing.Point(176, 8);
            this.btnSort.Margin = new System.Windows.Forms.Padding(2);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(100, 23);
            this.btnSort.TabIndex = 92;
            this.btnSort.Tag = "themeable";
            this.btnSort.Text = "Sort by A-Z";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(149, 496);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 26);
            this.btnEdit.TabIndex = 84;
            this.btnEdit.Tag = "themeable";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listApps);
            this.panel2.Location = new System.Drawing.Point(16, 35);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 452);
            this.panel2.TabIndex = 83;
            // 
            // helperMenu
            // 
            this.helperMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.helperMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helperMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.helperMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.locateFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.sortByAZToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem,
            this.deleteAllToolStripMenuItem});
            this.helperMenu.Name = "launcherMenu";
            this.helperMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.helperMenu.Size = new System.Drawing.Size(153, 136);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // locateFileToolStripMenuItem
            // 
            this.locateFileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locateFileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.locateFileToolStripMenuItem.Name = "locateFileToolStripMenuItem";
            this.locateFileToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.locateFileToolStripMenuItem.Text = "Locate file...";
            this.locateFileToolStripMenuItem.Click += new System.EventHandler(this.locateFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // sortByAZToolStripMenuItem
            // 
            this.sortByAZToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortByAZToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sortByAZToolStripMenuItem.Name = "sortByAZToolStripMenuItem";
            this.sortByAZToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.sortByAZToolStripMenuItem.Text = "Sort by A-Z";
            this.sortByAZToolStripMenuItem.Click += new System.EventHandler(this.sortByAZToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAllToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.deleteAllToolStripMenuItem.Text = "Delete all";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.deleteAllToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(11, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 77;
            this.label3.Tag = "themeable";
            this.label3.Text = "Apps:";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(61, 496);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 26);
            this.btnDelete.TabIndex = 81;
            this.btnDelete.Tag = "themeable";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelAddApp
            // 
            this.panelAddApp.AllowDrop = true;
            this.panelAddApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panelAddApp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAddApp.Controls.Add(this.btnAddFolder);
            this.panelAddApp.Controls.Add(this.btnGroups);
            this.panelAddApp.Controls.Add(this.label8);
            this.panelAddApp.Controls.Add(this.groupBox);
            this.panelAddApp.Controls.Add(this.txtParams);
            this.panelAddApp.Controls.Add(this.label7);
            this.panelAddApp.Controls.Add(this.btnLocate);
            this.panelAddApp.Controls.Add(this.btnAdd);
            this.panelAddApp.Controls.Add(this.txtAppTitle);
            this.panelAddApp.Controls.Add(this.label1);
            this.panelAddApp.Controls.Add(this.label5);
            this.panelAddApp.Controls.Add(this.txtAppLink);
            this.panelAddApp.Controls.Add(this.label4);
            this.panelAddApp.Location = new System.Drawing.Point(10, 14);
            this.panelAddApp.Margin = new System.Windows.Forms.Padding(2);
            this.panelAddApp.Name = "panelAddApp";
            this.panelAddApp.Size = new System.Drawing.Size(296, 328);
            this.panelAddApp.TabIndex = 89;
            // 
            // btnGroups
            // 
            this.btnGroups.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGroups.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnGroups.FlatAppearance.BorderSize = 0;
            this.btnGroups.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnGroups.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroups.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroups.ForeColor = System.Drawing.Color.White;
            this.btnGroups.Location = new System.Drawing.Point(225, 165);
            this.btnGroups.Margin = new System.Windows.Forms.Padding(2);
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.Size = new System.Drawing.Size(53, 25);
            this.btnGroups.TabIndex = 94;
            this.btnGroups.Tag = "themeable";
            this.btnGroups.Text = "New";
            this.btnGroups.UseVisualStyleBackColor = false;
            this.btnGroups.Click += new System.EventHandler(this.btnGroups_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(10, 142);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 19);
            this.label8.TabIndex = 93;
            this.label8.Tag = "";
            this.label8.Text = "Group (optional)";
            // 
            // txtParams
            // 
            this.txtParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtParams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParams.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParams.ForeColor = System.Drawing.Color.White;
            this.txtParams.Location = new System.Drawing.Point(14, 213);
            this.txtParams.Margin = new System.Windows.Forms.Padding(2);
            this.txtParams.Name = "txtParams";
            this.txtParams.Size = new System.Drawing.Size(264, 25);
            this.txtParams.TabIndex = 91;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(10, 192);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 19);
            this.label7.TabIndex = 90;
            this.label7.Tag = "";
            this.label7.Text = "Parameters (optional)";
            // 
            // btnLocate
            // 
            this.btnLocate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLocate.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnLocate.FlatAppearance.BorderSize = 0;
            this.btnLocate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnLocate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnLocate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocate.ForeColor = System.Drawing.Color.White;
            this.btnLocate.Location = new System.Drawing.Point(247, 67);
            this.btnLocate.Margin = new System.Windows.Forms.Padding(2);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(31, 25);
            this.btnLocate.TabIndex = 89;
            this.btnLocate.Tag = "themeable";
            this.btnLocate.Text = "...";
            this.btnLocate.UseVisualStyleBackColor = false;
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(174, 268);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 31);
            this.btnAdd.TabIndex = 80;
            this.btnAdd.Tag = "themeable";
            this.btnAdd.Text = "Add App";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAppTitle
            // 
            this.txtAppTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtAppTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAppTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppTitle.ForeColor = System.Drawing.Color.White;
            this.txtAppTitle.Location = new System.Drawing.Point(14, 115);
            this.txtAppTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtAppTitle.Name = "txtAppTitle";
            this.txtAppTitle.Size = new System.Drawing.Size(264, 25);
            this.txtAppTitle.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 84;
            this.label1.Tag = "themeable";
            this.label1.Text = "Add a new app:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(10, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 19);
            this.label5.TabIndex = 87;
            this.label5.Tag = "";
            this.label5.Text = "Locate app:";
            // 
            // txtAppLink
            // 
            this.txtAppLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtAppLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAppLink.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppLink.ForeColor = System.Drawing.Color.White;
            this.txtAppLink.Location = new System.Drawing.Point(14, 67);
            this.txtAppLink.Margin = new System.Windows.Forms.Padding(2);
            this.txtAppLink.Name = "txtAppLink";
            this.txtAppLink.Size = new System.Drawing.Size(230, 25);
            this.txtAppLink.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(10, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 86;
            this.label4.Tag = "";
            this.label4.Text = "App title:";
            // 
            // launcherIcon
            // 
            this.launcherIcon.ContextMenuStrip = this.launcherMenu;
            this.launcherIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("launcherIcon.Icon")));
            this.launcherIcon.Text = "Mint";
            this.launcherIcon.Visible = true;
            this.launcherIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.launcherIcon_MouseDoubleClick);
            // 
            // launcherMenu
            // 
            this.launcherMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.launcherMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launcherMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.launcherMenu.Name = "launcherMenu";
            this.launcherMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.launcherMenu.Size = new System.Drawing.Size(61, 4);
            this.launcherMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.launcherMenu_ItemClicked);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddFolder.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAddFolder.FlatAppearance.BorderSize = 0;
            this.btnAddFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAddFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFolder.ForeColor = System.Drawing.Color.White;
            this.btnAddFolder.Location = new System.Drawing.Point(14, 268);
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(104, 31);
            this.btnAddFolder.TabIndex = 95;
            this.btnAddFolder.Tag = "themeable";
            this.btnAddFolder.Text = "Add Folder";
            this.btnAddFolder.UseVisualStyleBackColor = false;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // checkAutoStart
            // 
            this.checkAutoStart.AutoSize = true;
            this.checkAutoStart.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAutoStart.ForeColor = System.Drawing.Color.Silver;
            this.checkAutoStart.Location = new System.Drawing.Point(14, 147);
            this.checkAutoStart.Margin = new System.Windows.Forms.Padding(2);
            this.checkAutoStart.Name = "checkAutoStart";
            this.checkAutoStart.Size = new System.Drawing.Size(170, 25);
            this.checkAutoStart.TabIndex = 85;
            this.checkAutoStart.Text = "Start with Windows";
            this.checkAutoStart.UseVisualStyleBackColor = true;
            this.checkAutoStart.CheckedChanged += new System.EventHandler(this.checkAutoStart_CheckedChanged);
            // 
            // listApps
            // 
            this.listApps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.listApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listApps.ContextMenuStrip = this.helperMenu;
            this.listApps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listApps.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listApps.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listApps.ForeColor = System.Drawing.Color.White;
            this.listApps.FormattingEnabled = true;
            this.listApps.ItemHeight = 21;
            this.listApps.Location = new System.Drawing.Point(0, 0);
            this.listApps.Margin = new System.Windows.Forms.Padding(2);
            this.listApps.Name = "listApps";
            this.listApps.Size = new System.Drawing.Size(260, 452);
            this.listApps.TabIndex = 78;
            this.listApps.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listApps_MouseDoubleClick);
            this.listApps.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listApps_MouseDown);
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.groupBox.BorderColor = System.Drawing.Color.Gray;
            this.groupBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.ForeColor = System.Drawing.Color.White;
            this.groupBox.FormattingEnabled = true;
            this.groupBox.Location = new System.Drawing.Point(14, 165);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(206, 25);
            this.groupBox.TabIndex = 92;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(618, 619);
            this.Controls.Add(this.botPanel);
            this.Controls.Add(this.topPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.botPanel.ResumeLayout(false);
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.panelApps.ResumeLayout(false);
            this.panelApps.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.helperMenu.ResumeLayout(false);
            this.panelAddApp.ResumeLayout(false);
            this.panelAddApp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblversion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel botPanel;
        private MoonList listApps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NotifyIcon launcherIcon;
        private System.Windows.Forms.ContextMenuStrip launcherMenu;
        private System.Windows.Forms.TextBox txtAppTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAppLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelApps;
        private System.Windows.Forms.Panel panelAddApp;
        private System.Windows.Forms.Button btnLocate;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioMinimal;
        private System.Windows.Forms.RadioButton radioCaramel;
        private System.Windows.Forms.RadioButton radioLime;
        private System.Windows.Forms.RadioButton radioMagma;
        private System.Windows.Forms.RadioButton radioOcean;
        private System.Windows.Forms.RadioButton radioZerg;
        private MoonCheck checkAutoStart;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtParams;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Label label8;
        private MoonBox groupBox;
        private System.Windows.Forms.Button btnGroups;
        private System.Windows.Forms.ContextMenuStrip helperMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locateFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sortByAZToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.Button btnAddFolder;
    }
}

