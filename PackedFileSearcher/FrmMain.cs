using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PackedFileSearcher.Enums;
using PackedFileSearcher.Searchers;

namespace PackedFileSearcher
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

        enum ReadingStatus
        {
            OK,
            CancelRequest,
            Error
        }
        public const string SearchHint = "Search for.. (Use * [≙ any text] and ? [≙ a single character] as wildcards)";
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

        /// <summary>
        /// Event handler for Console.WriteLine, logs text into textbox
        /// </summary>
        private void consoleWriter_WriteLineEvent(object sender, ConsoleWriterEventArgs e) => this.InvokeIfRequired(() => tb_log.Text += Environment.NewLine + e.Value);

        /// <summary>
        /// Event handler for Console.Write, logs text into textbox
        /// </summary>
        private void consoleWriter_WriteEvent(object sender, ConsoleWriterEventArgs e) => this.InvokeIfRequired(() => tb_log.Text += e.Value);


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

        /// <summary>
        /// Turns file paths into listview items
        /// </summary>
        /// <param name="filePath">whole path to the file (eg. C:\reward\sink.jpg)</param>
        /// <returns></returns>
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

        /// <summary>
        /// Searches for compatible archives in the given directory
        /// </summary>
        /// <param name="path">path to the directory</param>
        /// <returns>Reading Status: Status code whether the search threw an error or if a cancellation request was made</returns>
        private ReadingStatus addDirectoryToSearchList(string path)
        {
            // if the directory doesn't exist, it's not a big problem so we can continue with whatever we want to.
            if (!Directory.Exists(path))
                return ReadingStatus.OK;

            CurrentWorkingState = WorkingState.DirectorySearch;
            this.InvokeIfRequired(() => setStatus($"Listing files in directories.. { path }", true, true, 0, true));

            // Get all matching compressed files we can get in the given directory
            (Boolean errorOccured, List<string> results) search = Utils.SearchDirectory(path);
            string[] files = search.results.ToArray();

            CurrentWorkingState = WorkingState.FileScan;
            this.InvokeIfRequired(() => setStatus("Read files in directories.. ", true, true, 0, true));

            // Loop through each file ..
            ReadingStatus fileReadingStatus = addFilesToSearchList(files);

            // if the search threw an error, return that.
            if (search.errorOccured)
                return ReadingStatus.Error;
            else
                return fileReadingStatus;
        }

        /// <summary>
        /// Checks the given files if they are compatible archive types and adds them
        /// </summary>
        /// <param name="files">files to add</param>
        /// <returns>Reading Status: Status code whether the search threw an error or if a cancellation request was made</returns>
        private ReadingStatus addFilesToSearchList(params string[] files)
        {
            List<ListViewItem> filesToAdd = new List<ListViewItem>();

            foreach (string f in files)
            {
                // if we have a cancellation request and the worker is still working, we grant it
                if (bw_loadFiles.IsBusy && bw_loadFiles.CancellationPending)
                {
                    // Get all by now processed items and add them all at once - addrange is a lot faster than adding them seperately
                    this.InvokeIfRequired(() => lv_files.Items.AddRange(filesToAdd.ToArray()));

                    // report a cancellation request
                    return ReadingStatus.CancelRequest;
                }

                // .. if we have a searcher for the file, we process it - otherwise, we don't
                if (SearcherTypeHelper.ExtensionToSearcherType(Path.GetExtension(f)) != SearcherType.None)
                {
                    this.InvokeIfRequired(() => setStatus($"Read files.. Valid: { f }", true, true));

                    // Process file path into a new listviewitem and add it to list of "items to be added"
                    filesToAdd.Add(processFilePath(f));
                }
            }

            // Get all by now processed items and add them all at once - addrange is a lot faster than adding them seperately
            this.InvokeIfRequired(() => lv_files.Items.AddRange(filesToAdd.ToArray()));
            return ReadingStatus.OK;
        }
        #endregion

        #region button actions (+ Drop event)
        #region toolbar
        private void btn_extract_Click(object sender, EventArgs e)
        {
            // if there is more than one file, don't just save them and make the user choosing a folder to extract the multiple files to
            if (lv_results.SelectedItems.Count > 1 || lv_results.SelectedItems.Cast<ListViewItem>().Where(it => (it.Tag as SearchResultInstance).IsDir).Any())
            {
                VistaFolderBrowserDialog fbd = new VistaFolderBrowserDialog();
                fbd.Multiselect = false;
                fbd.ShowDialog(this);

                if (fbd.SelectedPath != "")
                    foreach (ListViewItem item in lv_results.SelectedItems)
                    {
                        SearchResultInstance sri = (item.Tag as SearchResultInstance);

                        sri.SearcherInstance.extract(sri,
                            Utils.NextAvailableFilename(
                                Properties.Settings.Default.UseWholePathForFileNames ?
                                       (fbd.SelectedPath + Path.DirectorySeparatorChar + (Path.GetFileName(sri.PackagePath) + "_" + sri.FolderPath.Replace("/", "_").Replace(@"\", "_") + "_" + sri.FileName)) :
                                       (fbd.SelectedPath + Path.DirectorySeparatorChar + sri.FileName)
                            )
                        );
                    }

            }
            else if (lv_results.SelectedItems.Count == 1)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.FileName = (lv_results.SelectedItems[0].Tag as SearchResultInstance).FileName;
                    sfd.ShowDialog();

                    if (sfd.FileName != "")
                        (lv_results.SelectedItems[0].Tag as SearchResultInstance).SearcherInstance.extract(lv_results.SelectedItems[0].Tag as SearchResultInstance, sfd.FileName);
                }
            }
        }

        private void btn_copyPath_Click(object sender, EventArgs e)
        {
            string textToBeCopied = "";

            // copy each file in a seperate line in the clipboard
            foreach (ListViewItem item in lv_results.SelectedItems)
                textToBeCopied += (item.Tag as SearchResultInstance).PackagePath + Path.DirectorySeparatorChar + (item.Tag as SearchResultInstance).FolderPath + Environment.NewLine;

            // remove last new line so that in case of only one line it's still pastable to an adress bar or smth like that
            textToBeCopied.TrimEnd(Environment.NewLine.ToCharArray());

            Clipboard.SetText(textToBeCopied, TextDataFormat.Text);
        }

        private void btn_deletefile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to *delete* all the selected packages?", "Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (ListViewItem item in lv_results.SelectedItems)
                {
                    File.Delete((item.Tag as SearchResultInstance).PackagePath);

                    foreach (ListViewItem itm in lv_results.Items)
                        if ((itm.Tag as SearchResultInstance).PackagePath == (item.Tag as SearchResultInstance).PackagePath)
                            itm.Remove();
                }

            }
        }

        private void btn_addfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = ofd.CheckPathExists = true;

                // Set the extension filter to all extensions we currently have as ISearcher implementations
                ofd.Filter = Searcher.ExtensionText;

                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.InvokeIfRequired(() => setStatus("Read files.. ", true, true, 0, true));
                    addFilesToSearchList(ofd.FileNames);
                }
            }
            this.InvokeIfRequired(() => setStatus(DefaultStatusText, true));
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
            lv_files.BeginUpdate();

            foreach (ListViewItem lvi in lv_files.SelectedItems)
                lvi.Remove();

            lv_files.EndUpdate();
        }
        private void lbl_caption_Click(object sender, EventArgs e) => Process.Start("https://github.com/Nockiro/packed-file-searcher");

        private void btn_settings_Click(object sender, EventArgs e) => new FrmSettings().Show();
        #endregion

        #region search and status elements

        /// <summary>
        /// Start search for a string in the given files
        /// </summary>
        private void btn_search_Click(object sender, EventArgs e)
        {
            // Variables and current status declaration
            tsm_searchText.Enabled = false;
            btn_abort.Visible = true;
            CurrentWorkingState = WorkingState.StringSearch;

            // Start search on all files currently listed in the lv_files (pass only the tags to the background worker)
            bw_search.RunWorkerAsync(lv_files.Items.Cast<ListViewItem>()
                                 .Select(item => item.Tag)
                                 .ToList());
        }


        int requestedTimesOfCancellation = 0;

        /// <summary>
        /// Try to cancel the current action - and if necessary, abort it hard
        /// </summary>
        private void btn_abort_Click(object sender, EventArgs e)
        {
            // Check which worker or thread has to be stopped
            if (CurrentWorkingState == WorkingState.DirectorySearch)
                Utils.CancellationOfSearchPending = true;
            else if (CurrentWorkingState == WorkingState.FileScan)
                bw_loadFiles.CancelAsync();
            else if (CurrentWorkingState == WorkingState.StringSearch)
                bw_search.CancelAsync();

            // inform user so that he doesn't get nervous
            this.InvokeIfRequired(() => setStatus("Requested cancellation, please wait..", true, true, 0, true));

            // count the times of cancellation so..
            requestedTimesOfCancellation++;

            // .. we can hard-interrupt the process if the user really wants that
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

        private void btn_clearResults_Click(object sender, EventArgs e) => lv_results.Items.Clear();
        #endregion

        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            // start this in a background thread as especially the directory deep search could take a while
            new System.Threading.Thread(() =>
            {
                this.InvokeIfRequired(() => setStatus("Read files.. ", true, true, 0, true));

                foreach (string s in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    if (Utils.isDirectory(s))
                        addDirectoryToSearchList(s);
                    else
                        addFilesToSearchList(s);
                }

                this.InvokeIfRequired(() => setStatus(DefaultStatusText, true));
            }).Start();
        }
        #endregion

        #region visual effects
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

        private void lv_results_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) => btn_copyPath.Enabled = btn_extract.Enabled = btn_deletefile.Enabled = e.IsSelected;

        private void lv_results_Leave(object sender, EventArgs e) => btn_copyPath.Enabled = btn_extract.Enabled = btn_deletefile.Enabled = false;

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e) => btn_clearResults.Enabled = tabControl.SelectedIndex == 2;

        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;

                if (tabControl.SelectedIndex != 1)
                    tabControl.SelectTab(1);
            }
        }
        #endregion

        #region other listview events (double click, ..)

        /// <summary>
        /// Handle double click on an item in the result list
        /// </summary>
        private void lv_results_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem SelectedItem = lv_results.SelectedItems?[0];
            try
            {
                Process.Start((SelectedItem?.Tag as SearchResultInstance).PackagePath);
            }
            catch { }
        }

        /// <summary>
        /// Handle double click on an item in the file list
        /// </summary>
        private void lv_files_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem SelectedItem = lv_files.SelectedItems?[0];
            try
            {
                Process.Start((SelectedItem?.Tag as ISearcher).Path);
            }
            catch { }
        }
        #endregion

        #region search and listing workers

        /// <summary>
        /// Load selected files into the list
        /// </summary>
        private void bw_loadFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            // initialize error flag
            Boolean errorOccured = false;

            // Loop through all selected directories
            foreach (string path in ((VistaFolderBrowserDialog)e.Argument).SelectedPaths)
            {
                switch (addDirectoryToSearchList(path))
                {
                    case ReadingStatus.OK:
                        continue;
                    case ReadingStatus.CancelRequest:
                        e.Cancel = true;
                        return;
                    case ReadingStatus.Error:
                        this.InvokeIfRequired(() => setStatus("Warning! There seems to be a problem with " + path, true, true, 0, true));
                        break;
                }
            }

            if (errorOccured)
                this.InvokeIfRequired(() => MessageBox.Show("Warning! One or multiple folders couldn't be checked since they weren't accessible.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning));
        }

        /// <summary>
        /// Handle end of compressed file search
        /// </summary>
        private void bw_loadFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setStatus(DefaultStatusText, true);

            btn_abort.Visible = false;
            CurrentWorkingState = WorkingState.None;
            requestedTimesOfCancellation = 0;
        }

        /// <summary>
        /// Search through all files in the given file (here represented by ISearcher) list for the given string
        /// </summary>
        private void bw_search_DoWork(object sender, DoWorkEventArgs e)
        {
            List<SearchResultInstance> sri = new List<SearchResultInstance>();

            foreach (ISearcher searcher in (List<object>)e.Argument)
            {
                this.InvokeIfRequired(() => setStatus($"Search for {tsm_searchText.Text} in {searcher.Path}.. ", true, true, 0));

                sri.AddRange(searcher.Search(tsm_searchText.Text));

                if (bw_search.CancellationPending)
                    break;

                if (searcher.Error)
                    this.InvokeIfRequired(() => setStatus("Warning! There seems to be a problem with " + searcher.Path, true, true, 0, true));

            }
            e.Result = sri;
        }

        /// <summary>
        /// Handle the list of search results and add them to the result listview
        /// </summary>
        private void bw_search_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Show results tab page if not existing yet
            if (!tabControl.TabPages.Contains(tb_results))
                tabControl.TabPages.Add(tb_results);

            lv_results.BeginUpdate();
            foreach (SearchResultInstance inst in e.Result as List<SearchResultInstance>)
            {
                if (bw_search.CancellationPending && e.Cancelled)
                    if (MessageBox.Show("Do you also want to cancel the listing of the so far found results?", "Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        break;

                ListViewItem item = new ListViewItem(inst.PackagePath);
                item.SubItems.Add(inst.FileName);
                item.SubItems.Add(inst.FolderPath);
                item.SubItems.Add(inst.EntryLength + " bytes");
                item.SubItems.Add(inst.LastWrite.ToString());
                item.Tag = inst;

                lv_results.Items.Add(item);
            }
            lv_results.EndUpdate();

            // do ui stuff
            setStatus(DefaultStatusText, true);
            btn_abort.Visible = false;
            requestedTimesOfCancellation = 0;
            tsm_searchText.Enabled = true;

            if (tabControl.SelectedIndex != 2)
                tabControl.SelectTab(2);
        }
        #endregion

    }
}
