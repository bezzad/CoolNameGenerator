namespace CoolNameGenerator.Forms
{
    partial class CoolNameResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoolNameResultForm));
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.wpResults = new CoolNameGenerator.Graphics.WordsPanel();
            this.gbGAToolbox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelWordToolbox = new System.Windows.Forms.FlowLayoutPanel();
            this.chkHasHyphen = new System.Windows.Forms.CheckBox();
            this.chkHasNumeric = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWordMaxLen = new System.Windows.Forms.Label();
            this.numWordMaxLen = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWordMinLen = new System.Windows.Forms.Label();
            this.numWordMinLen = new System.Windows.Forms.NumericUpDown();
            this.chkDisplayRealtime = new System.Windows.Forms.CheckBox();
            this.panelGAToolbox = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finglishConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbResult.SuspendLayout();
            this.gbGAToolbox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelWordToolbox.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWordMaxLen)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWordMinLen)).BeginInit();
            this.panelGAToolbox.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPopulationSize)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbResult
            // 
            this.gbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResult.Controls.Add(this.wpResults);
            this.gbResult.Location = new System.Drawing.Point(12, 276);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(837, 363);
            this.gbResult.TabIndex = 0;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Result";
            // 
            // wpResults
            // 
            this.wpResults.AutoScroll = true;
            this.wpResults.AutoSize = true;
            this.wpResults.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.wpResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wpResults.Location = new System.Drawing.Point(3, 18);
            this.wpResults.Name = "wpResults";
            this.wpResults.Size = new System.Drawing.Size(831, 342);
            this.wpResults.TabIndex = 0;
            // 
            // gbGAToolbox
            // 
            this.gbGAToolbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGAToolbox.Controls.Add(this.flowLayoutPanel1);
            this.gbGAToolbox.Location = new System.Drawing.Point(12, 31);
            this.gbGAToolbox.Name = "gbGAToolbox";
            this.gbGAToolbox.Size = new System.Drawing.Size(837, 239);
            this.gbGAToolbox.TabIndex = 1;
            this.gbGAToolbox.TabStop = false;
            this.gbGAToolbox.Text = "PGAToolbox";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panelWordToolbox);
            this.flowLayoutPanel1.Controls.Add(this.panelGAToolbox);
            this.flowLayoutPanel1.Controls.Add(this.btnStart);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(831, 218);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // panelWordToolbox
            // 
            this.panelWordToolbox.Controls.Add(this.chkHasHyphen);
            this.panelWordToolbox.Controls.Add(this.chkHasNumeric);
            this.panelWordToolbox.Controls.Add(this.panel2);
            this.panelWordToolbox.Controls.Add(this.panel1);
            this.panelWordToolbox.Controls.Add(this.chkDisplayRealtime);
            this.panelWordToolbox.Location = new System.Drawing.Point(8, 8);
            this.panelWordToolbox.Name = "panelWordToolbox";
            this.panelWordToolbox.Size = new System.Drawing.Size(257, 207);
            this.panelWordToolbox.TabIndex = 7;
            // 
            // chkHasHyphen
            // 
            this.chkHasHyphen.AutoSize = true;
            this.chkHasHyphen.Location = new System.Drawing.Point(3, 3);
            this.chkHasHyphen.Name = "chkHasHyphen";
            this.chkHasHyphen.Size = new System.Drawing.Size(104, 21);
            this.chkHasHyphen.TabIndex = 1;
            this.chkHasHyphen.Text = "HasHyphen";
            this.chkHasHyphen.UseVisualStyleBackColor = true;
            // 
            // chkHasNumeric
            // 
            this.chkHasNumeric.AutoSize = true;
            this.chkHasNumeric.Location = new System.Drawing.Point(113, 3);
            this.chkHasNumeric.Name = "chkHasNumeric";
            this.chkHasNumeric.Size = new System.Drawing.Size(107, 21);
            this.chkHasNumeric.TabIndex = 2;
            this.chkHasNumeric.Text = "HasNumeric";
            this.chkHasNumeric.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblWordMaxLen);
            this.panel2.Controls.Add(this.numWordMaxLen);
            this.panel2.Location = new System.Drawing.Point(3, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 29);
            this.panel2.TabIndex = 5;
            // 
            // lblWordMaxLen
            // 
            this.lblWordMaxLen.AutoSize = true;
            this.lblWordMaxLen.Location = new System.Drawing.Point(3, 6);
            this.lblWordMaxLen.Name = "lblWordMaxLen";
            this.lblWordMaxLen.Size = new System.Drawing.Size(91, 17);
            this.lblWordMaxLen.TabIndex = 4;
            this.lblWordMaxLen.Text = "WordMaxLen";
            // 
            // numWordMaxLen
            // 
            this.numWordMaxLen.Location = new System.Drawing.Point(155, 4);
            this.numWordMaxLen.Maximum = new decimal(new int[] {
            67,
            0,
            0,
            0});
            this.numWordMaxLen.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numWordMaxLen.Name = "numWordMaxLen";
            this.numWordMaxLen.Size = new System.Drawing.Size(74, 22);
            this.numWordMaxLen.TabIndex = 3;
            this.numWordMaxLen.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblWordMinLen);
            this.panel1.Controls.Add(this.numWordMinLen);
            this.panel1.Location = new System.Drawing.Point(3, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 29);
            this.panel1.TabIndex = 4;
            // 
            // lblWordMinLen
            // 
            this.lblWordMinLen.AutoSize = true;
            this.lblWordMinLen.Location = new System.Drawing.Point(3, 6);
            this.lblWordMinLen.Name = "lblWordMinLen";
            this.lblWordMinLen.Size = new System.Drawing.Size(88, 17);
            this.lblWordMinLen.TabIndex = 4;
            this.lblWordMinLen.Text = "WordMinLen";
            // 
            // numWordMinLen
            // 
            this.numWordMinLen.Location = new System.Drawing.Point(155, 4);
            this.numWordMinLen.Maximum = new decimal(new int[] {
            67,
            0,
            0,
            0});
            this.numWordMinLen.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numWordMinLen.Name = "numWordMinLen";
            this.numWordMinLen.Size = new System.Drawing.Size(74, 22);
            this.numWordMinLen.TabIndex = 3;
            this.numWordMinLen.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // chkDisplayRealtime
            // 
            this.chkDisplayRealtime.AutoSize = true;
            this.chkDisplayRealtime.Location = new System.Drawing.Point(3, 100);
            this.chkDisplayRealtime.Name = "chkDisplayRealtime";
            this.chkDisplayRealtime.Size = new System.Drawing.Size(131, 21);
            this.chkDisplayRealtime.TabIndex = 6;
            this.chkDisplayRealtime.Text = "DisplayRealtime";
            this.chkDisplayRealtime.UseVisualStyleBackColor = true;
            // 
            // panelGAToolbox
            // 
            this.panelGAToolbox.Controls.Add(this.panel3);
            this.panelGAToolbox.Location = new System.Drawing.Point(271, 8);
            this.panelGAToolbox.Name = "panelGAToolbox";
            this.panelGAToolbox.Size = new System.Drawing.Size(372, 207);
            this.panelGAToolbox.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.numPopulationSize);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 29);
            this.panel3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "PopulationSize";
            // 
            // numPopulationSize
            // 
            this.numPopulationSize.Location = new System.Drawing.Point(157, 4);
            this.numPopulationSize.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numPopulationSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPopulationSize.Name = "numPopulationSize";
            this.numPopulationSize.Size = new System.Drawing.Size(99, 22);
            this.numPopulationSize.TabIndex = 3;
            this.numPopulationSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(649, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(177, 50);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(861, 28);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(178, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finglishConverterToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // finglishConverterToolStripMenuItem
            // 
            this.finglishConverterToolStripMenuItem.Name = "finglishConverterToolStripMenuItem";
            this.finglishConverterToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.finglishConverterToolStripMenuItem.Text = "FinglishConverter";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(178, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // CoolNameResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 651);
            this.Controls.Add(this.gbGAToolbox);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "CoolNameResultForm";
            this.Text = "CoolNameGenerator_PGA";
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
            this.gbGAToolbox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelWordToolbox.ResumeLayout(false);
            this.panelWordToolbox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWordMaxLen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWordMinLen)).EndInit();
            this.panelGAToolbox.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPopulationSize)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.GroupBox gbGAToolbox;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkHasHyphen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkHasNumeric;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWordMinLen;
        private System.Windows.Forms.NumericUpDown numWordMinLen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWordMaxLen;
        private System.Windows.Forms.NumericUpDown numWordMaxLen;
        private System.Windows.Forms.CheckBox chkDisplayRealtime;
        private System.Windows.Forms.FlowLayoutPanel panelWordToolbox;
        private System.Windows.Forms.FlowLayoutPanel panelGAToolbox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPopulationSize;
        private Graphics.WordsPanel wpResults;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finglishConverterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

