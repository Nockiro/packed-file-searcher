using System.Windows.Forms;

namespace ZipFileSearcher
{
    partial class FrmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "MyGoodZip.zip",
            "%:\\WholyFolder\\",
            "Zip"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "TestZip2",
            "%:\\SomeOtherFolder\\"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "rrrrr",
            "rrree"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "rrrrr",
            "abcde"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ordnerHinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmi_removeFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_deletefile = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_caption = new System.Windows.Forms.ToolStripLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabIntro = new System.Windows.Forms.TabPage();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lv_files = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btn_search = new System.Windows.Forms.ToolStripButton();
            this.tsm_searchText = new System.Windows.Forms.ToolStripTextBox();
            this.chFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_results = new System.Windows.Forms.ListView();
            this.chResultPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chResultFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chResultRelativePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ordnerHinzufügenToolStripMenuItem,
            this.toolStripSeparator1,
            this.tmi_removeFiles,
            this.tsm_deletefile,
            this.lbl_caption});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(4, 0, 1, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1376, 35);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::ZipFileSearcher.Properties.Resources.addfile;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(87, 35);
            this.toolStripMenuItem1.Text = "Add files..";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ordnerHinzufügenToolStripMenuItem
            // 
            this.ordnerHinzufügenToolStripMenuItem.Image = global::ZipFileSearcher.Properties.Resources.addfolder;
            this.ordnerHinzufügenToolStripMenuItem.Name = "ordnerHinzufügenToolStripMenuItem";
            this.ordnerHinzufügenToolStripMenuItem.Size = new System.Drawing.Size(97, 35);
            this.ordnerHinzufügenToolStripMenuItem.Text = "Add folder..";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // tmi_removeFiles
            // 
            this.tmi_removeFiles.Image = global::ZipFileSearcher.Properties.Resources.minus_2;
            this.tmi_removeFiles.Name = "tmi_removeFiles";
            this.tmi_removeFiles.Size = new System.Drawing.Size(108, 35);
            this.tmi_removeFiles.Text = "Remove files..";
            // 
            // tsm_deletefile
            // 
            this.tsm_deletefile.Image = global::ZipFileSearcher.Properties.Resources.del;
            this.tsm_deletefile.Name = "tsm_deletefile";
            this.tsm_deletefile.Size = new System.Drawing.Size(100, 35);
            this.tsm_deletefile.Text = "Delete fil(es)";
            // 
            // lbl_caption
            // 
            this.lbl_caption.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbl_caption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lbl_caption.Enabled = false;
            this.lbl_caption.Name = "lbl_caption";
            this.lbl_caption.Size = new System.Drawing.Size(151, 32);
            this.lbl_caption.Text = "Robin Freund - ZipSearcher";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabIntro);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1376, 501);
            this.tabControl.TabIndex = 1;
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.lbl_welcome);
            this.tabIntro.Location = new System.Drawing.Point(4, 22);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Padding = new System.Windows.Forms.Padding(3);
            this.tabIntro.Size = new System.Drawing.Size(1368, 475);
            this.tabIntro.TabIndex = 0;
            this.tabIntro.Text = "Welcome!";
            this.tabIntro.UseVisualStyleBackColor = true;
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_welcome.Location = new System.Drawing.Point(492, 221);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(357, 21);
            this.lbl_welcome.TabIndex = 0;
            this.lbl_welcome.Text = "Hi! Feel free to add files to be searched trough!";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lv_files);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1368, 475);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Files";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lv_files
            // 
            this.lv_files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFile,
            this.chPath,
            this.chType});
            this.lv_files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_files.FullRowSelect = true;
            this.lv_files.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.lv_files.Location = new System.Drawing.Point(3, 3);
            this.lv_files.MultiSelect = false;
            this.lv_files.Name = "lv_files";
            this.lv_files.ShowGroups = false;
            this.lv_files.Size = new System.Drawing.Size(1362, 469);
            this.lv_files.TabIndex = 3;
            this.lv_files.UseCompatibleStateImageBehavior = false;
            this.lv_files.View = System.Windows.Forms.View.Details;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lv_results);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1368, 475);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Results";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_search,
            this.tsm_searchText});
            this.toolStrip2.Location = new System.Drawing.Point(0, 35);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(1376, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btn_search
            // 
            this.btn_search.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_search.Image = global::ZipFileSearcher.Properties.Resources.search_verysmall;
            this.btn_search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(23, 22);
            this.btn_search.Text = "Start searching for string";
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // tsm_searchText
            // 
            this.tsm_searchText.AcceptsReturn = true;
            this.tsm_searchText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsm_searchText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tsm_searchText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tsm_searchText.AutoSize = false;
            this.tsm_searchText.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tsm_searchText.Name = "tsm_searchText";
            this.tsm_searchText.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsm_searchText.Size = new System.Drawing.Size(500, 25);
            this.tsm_searchText.Text = "Search for.. (Use * and ?)";
            this.tsm_searchText.Enter += new System.EventHandler(this.tsm_searchText_Enter);
            this.tsm_searchText.Leave += new System.EventHandler(this.tsm_searchText_Leave);
            this.tsm_searchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsm_searchText_KeyDown);
            this.tsm_searchText.Click += new System.EventHandler(this.tsm_searchText_Click);
            // 
            // chFile
            // 
            this.chFile.Text = "Filename";
            this.chFile.Width = 259;
            // 
            // chPath
            // 
            this.chPath.Text = "Path";
            this.chPath.Width = 999;
            // 
            // chType
            // 
            this.chType.Text = "Dateityp";
            this.chType.Width = 93;
            // 
            // lv_results
            // 
            this.lv_results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chResultPath,
            this.chResultFileName,
            this.chResultRelativePath});
            this.lv_results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_results.Location = new System.Drawing.Point(3, 3);
            this.lv_results.Name = "lv_results";
            this.lv_results.Size = new System.Drawing.Size(1362, 469);
            this.lv_results.TabIndex = 0;
            this.lv_results.UseCompatibleStateImageBehavior = false;
            this.lv_results.View = System.Windows.Forms.View.Details;
            // 
            // chResultPath
            // 
            this.chResultPath.Text = "Path";
            this.chResultPath.Width = 544;
            // 
            // chResultFileName
            // 
            this.chResultFileName.Text = "File name";
            this.chResultFileName.Width = 369;
            // 
            // chResultRelativePath
            // 
            this.chResultRelativePath.Text = "Relative path in file";
            this.chResultRelativePath.Width = 440;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "ZipSearcher";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabIntro.ResumeLayout(false);
            this.tabIntro.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ordnerHinzufügenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmi_removeFiles;
        private System.Windows.Forms.ToolStripMenuItem tsm_deletefile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabIntro;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lv_files;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private ToolStripButton btn_search;
        private System.Windows.Forms.ToolStripTextBox tsm_searchText;
        private System.Windows.Forms.ToolStripLabel lbl_caption;
        private ColumnHeader chFile;
        private ColumnHeader chPath;
        private ColumnHeader chType;
        private ListView lv_results;
        private ColumnHeader chResultPath;
        private ColumnHeader chResultFileName;
        private ColumnHeader chResultRelativePath;
    }
}

