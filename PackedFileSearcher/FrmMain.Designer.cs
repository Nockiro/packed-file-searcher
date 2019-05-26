using System.Windows.Forms;

namespace PackedFileSearcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_addFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_addFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_removeFiles = new System.Windows.Forms.ToolStripButton();
            this.lbl_caption = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_extract = new System.Windows.Forms.ToolStripButton();
            this.btn_copyPath = new System.Windows.Forms.ToolStripButton();
            this.btn_deletefile = new System.Windows.Forms.ToolStripButton();
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
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btn_search = new System.Windows.Forms.ToolStripButton();
            this.tsm_searchText = new System.Windows.Forms.ToolStripTextBox();
            this.btn_settings = new System.Windows.Forms.ToolStripButton();
            this.btn_clearResults = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pb_status = new System.Windows.Forms.ToolStripProgressBar();
            this.lbl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_abort = new System.Windows.Forms.ToolStripMenuItem();
            this.bw_loadFiles = new PackedFileSearcher.AbortableBackgroundWorker();
            this.bw_search = new PackedFileSearcher.AbortableBackgroundWorker();
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
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_addFiles,
            this.btn_addFolder,
            this.toolStripSeparator1,
            this.btn_removeFiles,
            this.lbl_caption,
            this.toolStripSeparator2,
            this.btn_extract,
            this.btn_copyPath,
            this.btn_deletefile});
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // btn_addFiles
            // 
            this.btn_addFiles.Image = global::PackedFileSearcher.Properties.Resources.addfile;
            this.btn_addFiles.Name = "btn_addFiles";
            resources.ApplyResources(this.btn_addFiles, "btn_addFiles");
            this.btn_addFiles.Click += new System.EventHandler(this.btn_addfile_Click);
            // 
            // btn_addFolder
            // 
            this.btn_addFolder.Image = global::PackedFileSearcher.Properties.Resources.addfolder;
            this.btn_addFolder.Name = "btn_addFolder";
            resources.ApplyResources(this.btn_addFolder, "btn_addFolder");
            this.btn_addFolder.Click += new System.EventHandler(this.btn_addFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btn_removeFiles
            // 
            this.btn_removeFiles.Image = global::PackedFileSearcher.Properties.Resources.minus_2;
            this.btn_removeFiles.Name = "btn_removeFiles";
            resources.ApplyResources(this.btn_removeFiles, "btn_removeFiles");
            this.btn_removeFiles.Click += new System.EventHandler(this.btn_removeFiles_Click);
            // 
            // lbl_caption
            // 
            this.lbl_caption.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbl_caption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lbl_caption.IsLink = true;
            this.lbl_caption.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lbl_caption.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_caption.Name = "lbl_caption";
            resources.ApplyResources(this.lbl_caption, "lbl_caption");
            this.lbl_caption.Click += new System.EventHandler(this.lbl_caption_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // btn_extract
            // 
            resources.ApplyResources(this.btn_extract, "btn_extract");
            this.btn_extract.Image = global::PackedFileSearcher.Properties.Resources.extract_col;
            this.btn_extract.Name = "btn_extract";
            this.btn_extract.Click += new System.EventHandler(this.btn_extract_Click);
            // 
            // btn_copyPath
            // 
            resources.ApplyResources(this.btn_copyPath, "btn_copyPath");
            this.btn_copyPath.Name = "btn_copyPath";
            this.btn_copyPath.Click += new System.EventHandler(this.btn_copyPath_Click);
            // 
            // btn_deletefile
            // 
            resources.ApplyResources(this.btn_deletefile, "btn_deletefile");
            this.btn_deletefile.Image = global::PackedFileSearcher.Properties.Resources.del;
            this.btn_deletefile.Name = "btn_deletefile";
            this.btn_deletefile.Click += new System.EventHandler(this.btn_deletefile_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tb_intro);
            this.tabControl.Controls.Add(this.tb_files);
            this.tabControl.Controls.Add(this.tb_results);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tb_intro
            // 
            this.tb_intro.Controls.Add(this.label1);
            this.tb_intro.Controls.Add(this.tb_log);
            this.tb_intro.Controls.Add(this.lbl_welcome);
            resources.ApplyResources(this.tb_intro, "tb_intro");
            this.tb_intro.Name = "tb_intro";
            this.tb_intro.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Name = "label1";
            // 
            // tb_log
            // 
            resources.ApplyResources(this.tb_log, "tb_log");
            this.tb_log.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tb_log.Name = "tb_log";
            this.tb_log.ReadOnly = true;
            // 
            // lbl_welcome
            // 
            resources.ApplyResources(this.lbl_welcome, "lbl_welcome");
            this.lbl_welcome.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_welcome.Name = "lbl_welcome";
            // 
            // tb_files
            // 
            this.tb_files.Controls.Add(this.lv_files);
            resources.ApplyResources(this.tb_files, "tb_files");
            this.tb_files.Name = "tb_files";
            this.tb_files.UseVisualStyleBackColor = true;
            // 
            // lv_files
            // 
            this.lv_files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFile,
            this.chPath,
            this.chType});
            resources.ApplyResources(this.lv_files, "lv_files");
            this.lv_files.FullRowSelect = true;
            this.lv_files.Name = "lv_files";
            this.lv_files.ShowGroups = false;
            this.lv_files.UseCompatibleStateImageBehavior = false;
            this.lv_files.View = System.Windows.Forms.View.Details;
            this.lv_files.DoubleClick += new System.EventHandler(this.lv_files_DoubleClick);
            // 
            // chFile
            // 
            resources.ApplyResources(this.chFile, "chFile");
            // 
            // chPath
            // 
            resources.ApplyResources(this.chPath, "chPath");
            // 
            // chType
            // 
            resources.ApplyResources(this.chType, "chType");
            // 
            // tb_results
            // 
            this.tb_results.Controls.Add(this.lv_results);
            resources.ApplyResources(this.tb_results, "tb_results");
            this.tb_results.Name = "tb_results";
            this.tb_results.UseVisualStyleBackColor = true;
            // 
            // lv_results
            // 
            this.lv_results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chResultPath,
            this.chResultFileName,
            this.chResultRelativePath,
            this.chSize,
            this.chTime});
            resources.ApplyResources(this.lv_results, "lv_results");
            this.lv_results.FullRowSelect = true;
            this.lv_results.Name = "lv_results";
            this.lv_results.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv_results.UseCompatibleStateImageBehavior = false;
            this.lv_results.View = System.Windows.Forms.View.Details;
            this.lv_results.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lv_results_ItemSelectionChanged);
            this.lv_results.DoubleClick += new System.EventHandler(this.lv_results_DoubleClick);
            this.lv_results.Leave += new System.EventHandler(this.lv_results_Leave);
            // 
            // chResultPath
            // 
            resources.ApplyResources(this.chResultPath, "chResultPath");
            // 
            // chResultFileName
            // 
            resources.ApplyResources(this.chResultFileName, "chResultFileName");
            // 
            // chResultRelativePath
            // 
            resources.ApplyResources(this.chResultRelativePath, "chResultRelativePath");
            // 
            // chSize
            // 
            resources.ApplyResources(this.chSize, "chSize");
            // 
            // chTime
            // 
            resources.ApplyResources(this.chTime, "chTime");
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_search,
            this.tsm_searchText,
            this.btn_settings,
            this.btn_clearResults});
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // btn_search
            // 
            this.btn_search.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_search.Image = global::PackedFileSearcher.Properties.Resources.search_verysmall;
            resources.ApplyResources(this.btn_search, "btn_search");
            this.btn_search.Name = "btn_search";
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // tsm_searchText
            // 
            this.tsm_searchText.AcceptsReturn = true;
            this.tsm_searchText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsm_searchText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tsm_searchText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.tsm_searchText, "tsm_searchText");
            this.tsm_searchText.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tsm_searchText.Name = "tsm_searchText";
            this.tsm_searchText.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsm_searchText.Enter += new System.EventHandler(this.tsm_searchText_Enter);
            this.tsm_searchText.Leave += new System.EventHandler(this.tsm_searchText_Leave);
            this.tsm_searchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsm_searchText_KeyDown);
            this.tsm_searchText.Click += new System.EventHandler(this.tsm_searchText_Click);
            // 
            // btn_settings
            // 
            this.btn_settings.Image = global::PackedFileSearcher.Properties.Resources.settings_verysmall;
            resources.ApplyResources(this.btn_settings, "btn_settings");
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // btn_clearResults
            // 
            this.btn_clearResults.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_clearResults.Image = global::PackedFileSearcher.Properties.Resources.clear;
            resources.ApplyResources(this.btn_clearResults, "btn_clearResults");
            this.btn_clearResults.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.btn_clearResults.Name = "btn_clearResults";
            this.btn_clearResults.Click += new System.EventHandler(this.btn_clearResults_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pb_status,
            this.lbl_status,
            this.btn_abort});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // pb_status
            // 
            this.pb_status.Margin = new System.Windows.Forms.Padding(1, 3, 6, 3);
            this.pb_status.Name = "pb_status";
            resources.ApplyResources(this.pb_status, "pb_status");
            this.pb_status.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb_status.Value = 50;
            // 
            // lbl_status
            // 
            this.lbl_status.Name = "lbl_status";
            resources.ApplyResources(this.lbl_status, "lbl_status");
            // 
            // btn_abort
            // 
            this.btn_abort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_abort.Image = global::PackedFileSearcher.Properties.Resources.del;
            this.btn_abort.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btn_abort.Name = "btn_abort";
            resources.ApplyResources(this.btn_abort, "btn_abort");
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
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmMain";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
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
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btn_extract;
        private ToolStripButton btn_copyPath;
        private ColumnHeader chSize;
        private ColumnHeader chTime;
        private ToolStripButton btn_deletefile;
        private ToolStripButton btn_removeFiles;
        private ToolStripButton btn_settings;
        private ToolStripButton btn_clearResults;
    }
}

