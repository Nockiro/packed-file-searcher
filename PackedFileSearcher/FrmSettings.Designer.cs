namespace PackedFileSearcher
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.gb_behaviour = new System.Windows.Forms.GroupBox();
            this.cb_useWholeFilePathForName = new System.Windows.Forms.CheckBox();
            this.gb_searchBehaviour = new System.Windows.Forms.GroupBox();
            this.cb_includeDirs = new System.Windows.Forms.CheckBox();
            this.gb_behaviour.SuspendLayout();
            this.gb_searchBehaviour.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_behaviour
            // 
            this.gb_behaviour.Controls.Add(this.cb_useWholeFilePathForName);
            this.gb_behaviour.Location = new System.Drawing.Point(13, 13);
            this.gb_behaviour.Name = "gb_behaviour";
            this.gb_behaviour.Size = new System.Drawing.Size(674, 64);
            this.gb_behaviour.TabIndex = 0;
            this.gb_behaviour.TabStop = false;
            this.gb_behaviour.Text = "Application behaviour";
            // 
            // cb_useWholeFilePathForName
            // 
            this.cb_useWholeFilePathForName.AutoSize = true;
            this.cb_useWholeFilePathForName.Location = new System.Drawing.Point(7, 20);
            this.cb_useWholeFilePathForName.Name = "cb_useWholeFilePathForName";
            this.cb_useWholeFilePathForName.Size = new System.Drawing.Size(294, 30);
            this.cb_useWholeFilePathForName.TabIndex = 0;
            this.cb_useWholeFilePathForName.Text = "On file extraction, use the whole package path as prefix?\r\nExample: images.zip_ga" +
    "rden_flowers_flower1.jpg\r\n";
            this.cb_useWholeFilePathForName.UseVisualStyleBackColor = true;
            this.cb_useWholeFilePathForName.CheckedChanged += new System.EventHandler(this.cb_useWholeFilePathForName_CheckedChanged);
            // 
            // gb_searchBehaviour
            // 
            this.gb_searchBehaviour.Controls.Add(this.cb_includeDirs);
            this.gb_searchBehaviour.Location = new System.Drawing.Point(13, 92);
            this.gb_searchBehaviour.Name = "gb_searchBehaviour";
            this.gb_searchBehaviour.Size = new System.Drawing.Size(674, 54);
            this.gb_searchBehaviour.TabIndex = 1;
            this.gb_searchBehaviour.TabStop = false;
            this.gb_searchBehaviour.Text = "Search behaviour";
            // 
            // cb_includeDirs
            // 
            this.cb_includeDirs.AutoSize = true;
            this.cb_includeDirs.Location = new System.Drawing.Point(7, 20);
            this.cb_includeDirs.Name = "cb_includeDirs";
            this.cb_includeDirs.Size = new System.Drawing.Size(343, 17);
            this.cb_includeDirs.TabIndex = 0;
            this.cb_includeDirs.Text = "Include directoriy names in search? (Only supported by .zip for now)";
            this.cb_includeDirs.UseVisualStyleBackColor = true;
            this.cb_includeDirs.Click += new System.EventHandler(this.cb_includeDirs_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 159);
            this.Controls.Add(this.gb_searchBehaviour);
            this.Controls.Add(this.gb_behaviour);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSettings";
            this.Text = "FrmSettings";
            this.gb_behaviour.ResumeLayout(false);
            this.gb_behaviour.PerformLayout();
            this.gb_searchBehaviour.ResumeLayout(false);
            this.gb_searchBehaviour.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_behaviour;
        private System.Windows.Forms.CheckBox cb_useWholeFilePathForName;
        private System.Windows.Forms.GroupBox gb_searchBehaviour;
        private System.Windows.Forms.CheckBox cb_includeDirs;
    }
}