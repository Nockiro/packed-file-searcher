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
        }

        private void cb_useWholeFilePathForName_CheckedChanged(object sender, EventArgs e)=> Properties.Settings.Default.UseWholePathForFileNames = cb_useWholeFilePathForName.Checked;


        private void cb_includeDirs_Click(object sender, EventArgs e) => Properties.Settings.Default.SearchInDirs = cb_includeDirs.Checked;

        ~FrmSettings() => Properties.Settings.Default.Save();
    }
}
