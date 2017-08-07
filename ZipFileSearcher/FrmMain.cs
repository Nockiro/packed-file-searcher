using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZipFileSearcher.Enums;
using ZipFileSearcher.Searchers;

namespace ZipFileSearcher
{
    public partial class FrmMain : Form
    {
        enum WorkingState
        {
            None,
            DirectorySearch,
            FileScan,
            StringSearch
        }

        public const string SearchHint = "Search for.. (Use * and ?)";
        public const string DefaultStatusText = "Ready.";

        private WorkingState CurrentWorkingState = WorkingState.None;

        public FrmMain()
        {
            InitializeComponent();
            lv_files.Items.Clear();

            // Redirect console Output
            Program.consoleWriter.WriteEvent += consoleWriter_WriteEvent;
            Program.consoleWriter.WriteLineEvent += consoleWriter_WriteLineEvent;

            // Hide results tab page
            tabControl.TabPages.Remove(tb_results);
        }

        private void consoleWriter_WriteLineEvent(object sender, ConsoleWriterEventArgs e)
        {
            this.InvokeIfRequired(() => tb_log.Text += Environment.NewLine + e.Value);
        }

        private void consoleWriter_WriteEvent(object sender, ConsoleWriterEventArgs e)
        {
            this.InvokeIfRequired(() => tb_log.Text += e.Value);
        }


        #region helpers
        /// <summary>
        /// Set Status in the status bar
        /// </summary>
        /// <param name="text">Status text to be shown</param>
        /// <param name="ConsoleLog">True if output to console</param>
        protected void setStatus(string text, bool ConsoleLog)
        {
            setStatus(text, false, false, 0, ConsoleLog);
        }

        /// <summary>
        /// Set Status in the status bar
        /// </summary>
        /// <param name="text">Status text to be shown</param>
        /// <param name="progress">True if progress bar should be visible</param>
        /// <param name="marquee">True if marquee style, false if Continuous</param>
        /// <param name="percent">Progress in percent</param>
        /// <param name="ConsoleLog">True if output to console</param>
        protected void setStatus(string text, Boolean progress = false, Boolean marquee = false, int percent = 0, bool ConsoleLog = false)
        {
            lbl_status.Text = text;
            pb_status.Visible = progress;
            pb_status.Style = marquee ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
            pb_status.Value = percent;

            if (ConsoleLog)
                Console.WriteLine("(" + DateTime.Now.TimeOfDay + ") " + text);
        }

        private ListViewItem processFilePath(string filePath)
        {
            // Set the path's file name as first text to be seen on the item
            ListViewItem item = new ListViewItem(Path.GetFileName(filePath));

            // Set only the path to the file, e.g C:\testFolder in the second column
            item.SubItems.Add(Path.GetDirectoryName(filePath));

            // Set only the extension, e.g. ".zip" in the third column
            item.SubItems.Add(Path.GetExtension(filePath));

            // Set the object to the list item as we could need it later to extract files or show further information
            item.Tag = Searcher.GetSearcher(SearcherTypeHelper.ExtensionToSearcherType(Path.GetExtension(filePath))).WithPath(filePath);

            return item;
        }
        #endregion

        #region button actions
        private void btn_search_Click(object sender, EventArgs e)
        {
            tsm_searchText.Enabled = false;
            btn_abort.Visible = true;
            CurrentWorkingState = WorkingState.StringSearch;

            bw_search.RunWorkerAsync(lv_files.Items.Cast<ListViewItem>()
                                 .Select(item => item.Tag)
                                 .ToList());
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = ofd.CheckPathExists = true;

                // Set the extension filter to all extensions we currently have as ISearcher implementations
                ofd.Filter = Searcher.ExtensionText;

                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    setStatus("Read files.. ", true, true, 0, true);
                    foreach (var f in ofd.FileNames)
                    {
                        setStatus("Read files.. " + f, true, true, 0, true);
                        // Process file path into a new listviewitem and add it
                        lv_files.Items.Add(processFilePath(f));
                    }
                    setStatus(DefaultStatusText, true);
                }
            }
        }

        private void btn_addFolder_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog fdb = new VistaFolderBrowserDialog();
            fdb.Multiselect = true;

            if (fdb.ShowDialog(this))
            {
                btn_abort.Visible = true;
                bw_loadFiles.RunWorkerAsync(fdb);
            }
        }

        private void btn_removeFiles_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lv_files.SelectedItems)
                lv_files.Items.Remove(lvi);
        }


        int requestedTimesOfCancellation = 0;
        private void btn_abort_Click(object sender, EventArgs e)
        {
            if (CurrentWorkingState == WorkingState.DirectorySearch)
                Utils.CancellationOfSearchPending = true;
            else if (CurrentWorkingState == WorkingState.FileScan)
                bw_loadFiles.CancelAsync();
            else if (CurrentWorkingState == WorkingState.StringSearch)
                bw_search.CancelAsync();

            requestedTimesOfCancellation++;
            this.InvokeIfRequired(() => setStatus("Requested cancellation, please wait..", true, true, 0, true));

            if (requestedTimesOfCancellation == 10 && bw_loadFiles.IsBusy)
                if (MessageBox.Show("U really wanna do dis the hard way?", "Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (CurrentWorkingState == WorkingState.StringSearch)
                    {
                        bw_search.Abort();
                        bw_search.Dispose();
                    }
                    else
                    {
                        bw_loadFiles.Abort();
                        bw_loadFiles.Dispose();
                    }
                }
        }
        #endregion


        #region search text field gui events

        private void tsm_searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search.PerformClick();
        }

        private void tsm_searchText_Click(object sender, EventArgs e)
        {
            if (tsm_searchText.Text == SearchHint)
                tsm_searchText.Text = "";
        }

        private void tsm_searchText_Enter(object sender, EventArgs e)
        {
            tsm_searchText.ForeColor = SystemColors.WindowText;
        }

        private void tsm_searchText_Leave(object sender, EventArgs e)
        {
            if (tsm_searchText.Text == "")
            {
                tsm_searchText.ForeColor = SystemColors.GrayText;
                tsm_searchText.Text = SearchHint;
            }
        }
        #endregion

        private void bw_loadFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            // initialize error flag
            Boolean errorOccured = false;

            foreach (var path in ((VistaFolderBrowserDialog)e.Argument).SelectedPaths)
            {
                if (!Directory.Exists(path))
                    continue;

                CurrentWorkingState = WorkingState.DirectorySearch;
                this.InvokeIfRequired(() => setStatus($"Listing files in directories.. { path }", true, true, 0, true));

                (Boolean errorOccured, List<string> results) search = Utils.SearchDirectory(path);
                string[] files = search.results.ToArray();

                CurrentWorkingState = WorkingState.FileScan;
                this.InvokeIfRequired(() => setStatus("Read files in directories.. ", true, true, 0, true));
                // Loop through each file ..
                foreach (string file in files)
                {
                    // if we have a cancellation request, we grant it
                    if (bw_loadFiles.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    // .. if we have a searcher for the file, we process it - otherwise, we don't
                    if (SearcherTypeHelper.ExtensionToSearcherType(Path.GetExtension(file)) != SearcherType.None)
                    {
                        this.InvokeIfRequired(() => setStatus($"Read files in directories.. Valid: { file }", true, true));
                        this.InvokeIfRequired(() => lv_files.Items.Add(processFilePath(file)));
                    }
                }
                errorOccured = search.errorOccured || errorOccured;
                if (search.errorOccured)
                    this.InvokeIfRequired(() => setStatus("Warning! There seems to be a problem with " + path, true, true, 0, true));
            }

            if (errorOccured)
                this.InvokeIfRequired(() => MessageBox.Show("Warning! One or multiple folders couldn't be checked since they weren't accessible.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning));
        }

        private void bw_loadFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setStatus(DefaultStatusText, true);

            btn_abort.Visible = false;
            CurrentWorkingState = WorkingState.None;
            requestedTimesOfCancellation = 0;
        }


        private void bw_search_DoWork(object sender, DoWorkEventArgs e)
        {
            List<SearchResultInstance> sri = new List<SearchResultInstance>();

            foreach (ISearcher searcher in (List<object>)e.Argument)
            {
                this.InvokeIfRequired(() => setStatus($"Search for {tsm_searchText.Text} in {searcher.Path}.. ", true, true, 0));
                sri.AddRange(searcher.Search(tsm_searchText.Text));

                if (bw_search.CancellationPending)
                {
                    break;
                }

                if (searcher.Error)
                    this.InvokeIfRequired(() => setStatus("Warning! There seems to be a problem with " + searcher.Path, true, true, 0, true));

            }
            e.Result = sri;
        }

        private void bw_search_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Show results tab page if not existing yet
            if (!tabControl.TabPages.Contains(tb_results))
                tabControl.TabPages.Add(tb_results);

            foreach (SearchResultInstance inst in e.Result as List<SearchResultInstance>)
            {
                if (bw_search.CancellationPending && e.Cancelled)
                    if (MessageBox.Show("Do you also want to cancel the listing of the so far found results?", "Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        break;

                ListViewItem item = new ListViewItem(inst.PackagePath);
                item.SubItems.Add(inst.FileName);
                item.SubItems.Add(inst.FolderPath);
                item.Tag = inst;

                lv_results.Items.Add(item);
            }

            setStatus(DefaultStatusText, true);
            btn_abort.Visible = false;
            requestedTimesOfCancellation = 0;
            tsm_searchText.Enabled = true;
        }
    }
}
