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
            this.btn_addFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_addFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_removeFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_deletefile = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_caption = new System.Windows.Forms.ToolStripLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tb_intro = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.tb_files = new System.Windows.Forms.TabPage();
            this.lv_files = new System.Windows.Forms.ListView();
            this.chFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tb_results = new System.Windows.Forms.TabPage();
            this.lv_results = new System.Windows.Forms.ListView();
            this.chResultPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chResultFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chResultRelativePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btn_search = new System.Windows.Forms.ToolStripButton();
            this.tsm_searchText = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pb_status = new System.Windows.Forms.ToolStripProgressBar();
            this.lbl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_abort = new System.Windows.Forms.ToolStripMenuItem();
            this.bw_loadFiles = new ZipFileSearcher.AbortableBackgroundWorker();
            this.bw_search = new ZipFileSearcher.AbortableBackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tb_intro.SuspendLayout();
            this.tb_files.SuspendLayout();
            this.tb_results.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_addFiles,
            this.btn_addFolder,
            this.toolStripSeparator1,
            this.btn_removeFiles,
            this.btn_deletefile,
            this.lbl_caption});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(4, 0, 1, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1376, 35);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_addFiles
            // 
            this.btn_addFiles.Image = global::ZipFileSearcher.Properties.Resources.addfile;
            this.btn_addFiles.Name = "btn_addFiles";
            this.btn_addFiles.Size = new System.Drawing.Size(87, 35);
            this.btn_addFiles.Text = "Add files..";
            this.btn_addFiles.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // btn_addFolder
            // 
            this.btn_addFolder.Image = global::ZipFileSearcher.Properties.Resources.addfolder;
            this.btn_addFolder.Name = "btn_addFolder";
            this.btn_addFolder.Size = new System.Drawing.Size(97, 35);
            this.btn_addFolder.Text = "Add folder..";
            this.btn_addFolder.Click += new System.EventHandler(this.btn_addFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // btn_removeFiles
            // 
            this.btn_removeFiles.Image = global::ZipFileSearcher.Properties.Resources.minus_2;
            this.btn_removeFiles.Name = "btn_removeFiles";
            this.btn_removeFiles.Size = new System.Drawing.Size(108, 35);
            this.btn_removeFiles.Text = "Remove files..";
            this.btn_removeFiles.Click += new System.EventHandler(this.btn_removeFiles_Click);
            // 
            // btn_deletefile
            // 
            this.btn_deletefile.Image = global::ZipFileSearcher.Properties.Resources.del;
            this.btn_deletefile.Name = "btn_deletefile";
            this.btn_deletefile.Size = new System.Drawing.Size(100, 35);
            this.btn_deletefile.Text = "Delete fil(es)";
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
            this.tabControl.Controls.Add(this.tb_intro);
            this.tabControl.Controls.Add(this.tb_files);
            this.tabControl.Controls.Add(this.tb_results);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1376, 479);
            this.tabControl.TabIndex = 1;
            // 
            // tb_intro
            // 
            this.tb_intro.Controls.Add(this.label1);
            this.tb_intro.Controls.Add(this.tb_log);
            this.tb_intro.Controls.Add(this.lbl_welcome);
            this.tb_intro.Location = new System.Drawing.Point(4, 22);
            this.tb_intro.Name = "tb_intro";
            this.tb_intro.Padding = new System.Windows.Forms.Padding(3);
            this.tb_intro.Size = new System.Drawing.Size(1368, 453);
            this.tb_intro.TabIndex = 0;
            this.tb_intro.Text = "Welcome!";
            this.tb_intro.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(3, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Exceptional behaviour:";
            // 
            // tb_log
            // 
            this.tb_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_log.Location = new System.Drawing.Point(7, 115);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(1355, 332);
            this.tb_log.TabIndex = 1;
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_welcome.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_welcome.Location = new System.Drawing.Point(498, 33);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(357, 21);
            this.lbl_welcome.TabIndex = 0;
            this.lbl_welcome.Text = "Hi! Feel free to add files to be searched trough!";
            // 
            // tb_files
            // 
            this.tb_files.Controls.Add(this.lv_files);
            this.tb_files.Location = new System.Drawing.Point(4, 22);
            this.tb_files.Name = "tb_files";
            this.tb_files.Padding = new System.Windows.Forms.Padding(3);
            this.tb_files.Size = new System.Drawing.Size(1368, 453);
            this.tb_files.TabIndex = 1;
            this.tb_files.Text = "Files";
            this.tb_files.UseVisualStyleBackColor = true;
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
            this.lv_files.Name = "lv_files";
            this.lv_files.ShowGroups = false;
            this.lv_files.Size = new System.Drawing.Size(1362, 447);
            this.lv_files.TabIndex = 3;
            this.lv_files.UseCompatibleStateImageBehavior = false;
            this.lv_files.View = System.Windows.Forms.View.Details;
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
            // tb_results
            // 
            this.tb_results.Controls.Add(this.lv_results);
            this.tb_results.Location = new System.Drawing.Point(4, 22);
            this.tb_results.Name = "tb_results";
            this.tb_results.Padding = new System.Windows.Forms.Padding(3);
            this.tb_results.Size = new System.Drawing.Size(1368, 453);
            this.tb_results.TabIndex = 2;
            this.tb_results.Text = "Results";
            this.tb_results.UseVisualStyleBackColor = true;
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
            this.lv_results.Size = new System.Drawing.Size(1362, 447);
            this.lv_results.Sorting = System.Windows.Forms.SortOrder.Ascending;
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pb_status,
            this.lbl_status,
            this.btn_abort});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1376, 22);
            this.statusStrip1.TabIndex = 5;
            // 
            // pb_status
            // 
            this.pb_status.Margin = new System.Windows.Forms.Padding(1, 3, 6, 3);
            this.pb_status.Name = "pb_status";
            this.pb_status.Size = new System.Drawing.Size(450, 16);
            this.pb_status.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb_status.Value = 50;
            this.pb_status.Visible = false;
            // 
            // lbl_status
            // 
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(42, 17);
            this.lbl_status.Text = "Ready.";
            // 
            // btn_abort
            // 
            this.btn_abort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_abort.Image = global::ZipFileSearcher.Properties.Resources.del;
            this.btn_abort.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btn_abort.Name = "btn_abort";
            this.btn_abort.Size = new System.Drawing.Size(65, 22);
            this.btn_abort.Text = "Abort";
            this.btn_abort.Visible = false;
            this.btn_abort.Click += new System.EventHandler(this.btn_abort_Click);
            // 
            // bw_loadFiles
            // 
            this.bw_loadFiles.WorkerSupportsCancellation = true;
            this.bw_loadFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_loadFiles_DoWork);
            this.bw_loadFiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_loadFiles_RunWorkerCompleted);
            // 
            // bw_search
            // 
            this.bw_search.WorkerSupportsCancellation = true;
            this.bw_search.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_search_DoWork);
            this.bw_search.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_search_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "ZipSearcher";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tb_intro.ResumeLayout(false);
            this.tb_intro.PerformLayout();
            this.tb_files.ResumeLayout(false);
            this.tb_results.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem btn_addFiles;
        private System.Windows.Forms.ToolStripMenuItem btn_addFolder;
        private System.Windows.Forms.ToolStripMenuItem btn_removeFiles;
        private System.Windows.Forms.ToolStripMenuItem btn_deletefile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tb_intro;
        private System.Windows.Forms.TabPage tb_files;
        private System.Windows.Forms.ListView lv_files;
        private System.Windows.Forms.TabPage tb_results;
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
        private StatusStrip statusStrip1;
        private ToolStripProgressBar pb_status;
        private ToolStripStatusLabel lbl_status;
        private AbortableBackgroundWorker bw_loadFiles;
        private TextBox tb_log;
        private Label label1;
        private ToolStripMenuItem btn_abort;
        private AbortableBackgroundWorker bw_search;
    }
}

