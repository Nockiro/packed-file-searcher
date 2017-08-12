using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackedFileSearcher
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();

            cb_useWholeFilePathForName.Checked = Properties.Settings.Default.UseWholePathForFileNames;
            cb_includeDirs.Checked = Properties.Settings.Default.SearchInDirs;
            num_archiveDepth.Value = Properties.Settings.Default.RecursiveArchiveDepth;
        }

        private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e) => Properties.Settings.Default.Save();

        #region value change

        private void cb_useWholeFilePathForName_CheckedChanged(object sender, EventArgs e) => Properties.Settings.Default.UseWholePathForFileNames = cb_useWholeFilePathForName.Checked;

        private void cb_includeDirs_Click(object sender, EventArgs e) => Properties.Settings.Default.SearchInDirs = cb_includeDirs.Checked;

        private void num_archiveDepth_ValueChanged(object sender, EventArgs e) => Properties.Settings.Default.RecursiveArchiveDepth = num_archiveDepth.Value;

        #endregion
    }
}
