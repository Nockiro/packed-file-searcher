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

        #region search text field gui events
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

        private void btn_search_Click(object sender, EventArgs e)
        {
            tsm_searchText.Enabled = false;
            List<SearchResultInstance> sri = new List<SearchResultInstance>();

            foreach (ListViewItem lvi in lv_files.Items)
            {
                sri.AddRange(((ISearcher)lvi.Tag).Search(tsm_searchText.Text));
            }

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

        private void tsm_searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search.PerformClick();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = ofd.CheckPathExists = true;
                ofd.Filter = Searcher.ExtensionText;

                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var f in ofd.FileNames)
                    {
                        ListViewItem item = new ListViewItem(Path.GetFileName(f));
                        item.SubItems.Add(Path.GetDirectoryName(f));
                        item.SubItems.Add(Path.GetExtension(f));

                        item.Tag = Searcher.GetSearcher(SearcherTypeHelper.ExtensionToSearcherType(Path.GetExtension(f))).WithPath(f);
                        //Transform the list to a better presentation if needed
                        //Below code just adds the full path to list
                        lv_files.Items.Add(item);

                        //Or use below code to just add file names
                        //listView1.Items.Add (Path.GetFileName (f));
                    }
                }
            }
        }
    }
}
