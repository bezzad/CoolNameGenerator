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
            this.btnStart = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblFitness = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblBestChromosomeT = new System.Windows.Forms.Label();
            this.bestChromosomeWord = new CoolNameGenerator.Graphics.WordLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTimeEvolving = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblGeneration = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelWordToolbox = new System.Windows.Forms.FlowLayoutPanel();
            this.chkHasHyphen = new System.Windows.Forms.CheckBox();
            this.chkHasNumeric = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWordMaxLen = new System.Windows.Forms.Label();
            this.numWordLen = new System.Windows.Forms.NumericUpDown();
            this.chkDisplayRealtime = new System.Windows.Forms.CheckBox();
            this.panelGAToolbox = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.numCrossoverProbability = new System.Windows.Forms.NumericUpDown();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.numMutationProbability = new System.Windows.Forms.NumericUpDown();
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.persianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbResult.SuspendLayout();
            this.gbGAToolbox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelWordToolbox.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWordLen)).BeginInit();
            this.panelGAToolbox.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPopulationSize)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossoverProbability)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationProbability)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbResult
            // 
            this.gbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResult.Controls.Add(this.wpResults);
            this.gbResult.Location = new System.Drawing.Point(12, 317);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(1155, 385);
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
            this.wpResults.Size = new System.Drawing.Size(1149, 364);
            this.wpResults.TabIndex = 0;
            this.wpResults.WordsLabels = null;
            // 
            // gbGAToolbox
            // 
            this.gbGAToolbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGAToolbox.Controls.Add(this.flowLayoutPanel1);
            this.gbGAToolbox.Location = new System.Drawing.Point(12, 31);
            this.gbGAToolbox.Name = "gbGAToolbox";
            this.gbGAToolbox.Size = new System.Drawing.Size(1155, 280);
            this.gbGAToolbox.TabIndex = 1;
            this.gbGAToolbox.TabStop = false;
            this.gbGAToolbox.Text = "PGAToolbox";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.btnStart);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel7);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panelWordToolbox);
            this.flowLayoutPanel1.Controls.Add(this.panelGAToolbox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1149, 259);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(8, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(402, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblFitness);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(8, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(402, 32);
            this.panel4.TabIndex = 10;
            // 
            // lblFitness
            // 
            this.lblFitness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFitness.Location = new System.Drawing.Point(147, 6);
            this.lblFitness.Name = "lblFitness";
            this.lblFitness.Size = new System.Drawing.Size(249, 17);
            this.lblFitness.TabIndex = 10;
            this.lblFitness.Text = "Fitness No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fitness";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lblBestChromosomeT);
            this.panel7.Controls.Add(this.bestChromosomeWord);
            this.panel7.Location = new System.Drawing.Point(8, 92);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(402, 74);
            this.panel7.TabIndex = 11;
            // 
            // lblBestChromosomeT
            // 
            this.lblBestChromosomeT.AutoSize = true;
            this.lblBestChromosomeT.Location = new System.Drawing.Point(3, 6);
            this.lblBestChromosomeT.Name = "lblBestChromosomeT";
            this.lblBestChromosomeT.Size = new System.Drawing.Size(123, 17);
            this.lblBestChromosomeT.TabIndex = 9;
            this.lblBestChromosomeT.Text = "Best Chromosome";
            // 
            // bestChromosomeWord
            // 
            this.bestChromosomeWord.AutoEllipsis = true;
            this.bestChromosomeWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bestChromosomeWord.Fitness = null;
            this.bestChromosomeWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bestChromosomeWord.Font = new System.Drawing.Font("Segoe UI Symbol", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestChromosomeWord.Location = new System.Drawing.Point(153, 6);
            this.bestChromosomeWord.Name = "bestChromosomeWord";
            this.bestChromosomeWord.Padding = new System.Windows.Forms.Padding(10);
            this.bestChromosomeWord.Size = new System.Drawing.Size(243, 59);
            this.bestChromosomeWord.TabIndex = 8;
            this.bestChromosomeWord.Text = "Best Chromosome";
            this.bestChromosomeWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblTimeEvolving);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(8, 172);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(402, 32);
            this.panel6.TabIndex = 12;
            // 
            // lblTimeEvolving
            // 
            this.lblTimeEvolving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeEvolving.Location = new System.Drawing.Point(150, 6);
            this.lblTimeEvolving.Name = "lblTimeEvolving";
            this.lblTimeEvolving.Size = new System.Drawing.Size(246, 17);
            this.lblTimeEvolving.TabIndex = 10;
            this.lblTimeEvolving.Text = "TimeEvolving";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "TimeEvolving";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblGeneration);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(8, 210);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(402, 32);
            this.panel5.TabIndex = 13;
            // 
            // lblGeneration
            // 
            this.lblGeneration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGeneration.Location = new System.Drawing.Point(147, 6);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(249, 17);
            this.lblGeneration.TabIndex = 10;
            this.lblGeneration.Text = "Generation No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Generation";
            // 
            // panelWordToolbox
            // 
            this.panelWordToolbox.Controls.Add(this.chkHasHyphen);
            this.panelWordToolbox.Controls.Add(this.chkHasNumeric);
            this.panelWordToolbox.Controls.Add(this.panel2);
            this.panelWordToolbox.Controls.Add(this.chkDisplayRealtime);
            this.panelWordToolbox.Location = new System.Drawing.Point(416, 8);
            this.panelWordToolbox.Name = "panelWordToolbox";
            this.panelWordToolbox.Size = new System.Drawing.Size(257, 188);
            this.panelWordToolbox.TabIndex = 14;
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
            this.panel2.Controls.Add(this.numWordLen);
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
            this.lblWordMaxLen.Size = new System.Drawing.Size(66, 17);
            this.lblWordMaxLen.TabIndex = 4;
            this.lblWordMaxLen.Text = "WordLen";
            // 
            // numWordLen
            // 
            this.numWordLen.Location = new System.Drawing.Point(155, 4);
            this.numWordLen.Maximum = new decimal(new int[] {
            67,
            0,
            0,
            0});
            this.numWordLen.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numWordLen.Name = "numWordLen";
            this.numWordLen.Size = new System.Drawing.Size(74, 22);
            this.numWordLen.TabIndex = 3;
            this.numWordLen.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // chkDisplayRealtime
            // 
            this.chkDisplayRealtime.AutoSize = true;
            this.chkDisplayRealtime.Checked = true;
            this.chkDisplayRealtime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplayRealtime.Location = new System.Drawing.Point(3, 65);
            this.chkDisplayRealtime.Name = "chkDisplayRealtime";
            this.chkDisplayRealtime.Size = new System.Drawing.Size(131, 21);
            this.chkDisplayRealtime.TabIndex = 6;
            this.chkDisplayRealtime.Text = "DisplayRealtime";
            this.chkDisplayRealtime.UseVisualStyleBackColor = true;
            // 
            // panelGAToolbox
            // 
            this.panelGAToolbox.Controls.Add(this.panel3);
            this.panelGAToolbox.Controls.Add(this.panel1);
            this.panelGAToolbox.Controls.Add(this.panel8);
            this.panelGAToolbox.Location = new System.Drawing.Point(679, 8);
            this.panelGAToolbox.Name = "panelGAToolbox";
            this.panelGAToolbox.Size = new System.Drawing.Size(279, 188);
            this.panelGAToolbox.TabIndex = 15;
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
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Population Size";
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
            100,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numCrossoverProbability);
            this.panel1.Location = new System.Drawing.Point(3, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 29);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Crossover Probability";
            // 
            // numCrossoverProbability
            // 
            this.numCrossoverProbability.Location = new System.Drawing.Point(157, 4);
            this.numCrossoverProbability.Name = "numCrossoverProbability";
            this.numCrossoverProbability.Size = new System.Drawing.Size(99, 22);
            this.numCrossoverProbability.TabIndex = 3;
            this.numCrossoverProbability.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.numMutationProbability);
            this.panel8.Location = new System.Drawing.Point(3, 73);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(261, 29);
            this.panel8.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mutation Probability";
            // 
            // numMutationProbability
            // 
            this.numMutationProbability.Location = new System.Drawing.Point(157, 4);
            this.numMutationProbability.Name = "numMutationProbability";
            this.numMutationProbability.Size = new System.Drawing.Size(99, 22);
            this.numMutationProbability.TabIndex = 3;
            this.numMutationProbability.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
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
            this.menuStrip.Size = new System.Drawing.Size(1179, 28);
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(170, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
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
            this.finglishConverterToolStripMenuItem.Click += new System.EventHandler(this.finglishConverterToolStripMenuItem_Click);
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
            this.toolStripMenuItem1,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.persianToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 26);
            this.toolStripMenuItem1.Text = "Language";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Checked = true;
            this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(131, 26);
            this.toolStripMenuItem2.Text = "English";
            // 
            // persianToolStripMenuItem
            // 
            this.persianToolStripMenuItem.Name = "persianToolStripMenuItem";
            this.persianToolStripMenuItem.Size = new System.Drawing.Size(131, 26);
            this.persianToolStripMenuItem.Text = "Persian";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(146, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // CoolNameResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 714);
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
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelWordToolbox.ResumeLayout(false);
            this.panelWordToolbox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWordLen)).EndInit();
            this.panelGAToolbox.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPopulationSize)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCrossoverProbability)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationProbability)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.GroupBox gbGAToolbox;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem persianToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblFitness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblBestChromosomeT;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblTimeEvolving;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblGeneration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel panelWordToolbox;
        private System.Windows.Forms.CheckBox chkHasHyphen;
        private System.Windows.Forms.CheckBox chkHasNumeric;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWordMaxLen;
        private System.Windows.Forms.NumericUpDown numWordLen;
        private System.Windows.Forms.CheckBox chkDisplayRealtime;
        private System.Windows.Forms.FlowLayoutPanel panelGAToolbox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPopulationSize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCrossoverProbability;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numMutationProbability;
        private Graphics.WordLabel bestChromosomeWord;
    }
}

