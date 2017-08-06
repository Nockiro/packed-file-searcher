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
        public const string SearchHint = "Search for.. (Use * and ?)";
        public FrmMain()
        {
            InitializeComponent();
            lv_files.Items.Clear();
        }

        #region helpers

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
            List<SearchResultInstance> sri = new List<SearchResultInstance>();

            foreach (ListViewItem lvi in lv_files.Items)
                sri.AddRange(((ISearcher)lvi.Tag).Search(tsm_searchText.Text));

            foreach (SearchResultInstance inst in sri)
            {
                ListViewItem item = new ListViewItem(inst.PackagePath);
                item.SubItems.Add(inst.FileName);
                item.SubItems.Add(inst.FolderPath);
                item.Tag = inst;

                lv_results.Items.Add(item);
            }

            tsm_searchText.Enabled = true;
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
                    foreach (var f in ofd.FileNames)
                    {
                        // Process file path into a new listviewitem and add it
                        lv_files.Items.Add(processFilePath(f));
                    }
                }
            }
        }

        private void btn_addFolder_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog fdb = new VistaFolderBrowserDialog();
            fdb.Multiselect = true;

            if (fdb.ShowDialog(this)) 
            {
                foreach (var path in fdb.SelectedPaths)
                {
                    if (!Directory.Exists(path))
                        continue;

                    (Boolean errorOccured, List<string> results) search = Utils.SearchDirectory(path);
                    string[] files = search.results.ToArray();

                    // Loop through each file ..
                    foreach (string file in files)
                    {
                        // .. if we have a searcher for the file, we process it - otherwise, we don't
                        if (SearcherTypeHelper.ExtensionToSearcherType(Path.GetExtension(file)) != SearcherType.None)
                            lv_files.Items.Add(processFilePath(file));
                    }

                    if (search.errorOccured)
                        MessageBox.Show("Warning! One or multiple folders couldn't be checked since they weren't accessible.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
