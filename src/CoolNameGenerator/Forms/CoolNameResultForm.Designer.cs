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
            this.gbResult = new System.Windows.Forms.GroupBox();
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
            this.wpResults = new CoolNameGenerator.Graphics.WordsPanel();
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
            this.gbResult.Size = new System.Drawing.Size(841, 363);
            this.gbResult.TabIndex = 0;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Result";
            // 
            // gbGAToolbox
            // 
            this.gbGAToolbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGAToolbox.Controls.Add(this.flowLayoutPanel1);
            this.gbGAToolbox.Controls.Add(this.btnStart);
            this.gbGAToolbox.Location = new System.Drawing.Point(12, 12);
            this.gbGAToolbox.Name = "gbGAToolbox";
            this.gbGAToolbox.Size = new System.Drawing.Size(841, 258);
            this.gbGAToolbox.TabIndex = 1;
            this.gbGAToolbox.TabStop = false;
            this.gbGAToolbox.Text = "PGAToolbox";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panelWordToolbox);
            this.flowLayoutPanel1.Controls.Add(this.panelGAToolbox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(835, 178);
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
            this.panelWordToolbox.Size = new System.Drawing.Size(257, 151);
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
            this.panelGAToolbox.Size = new System.Drawing.Size(387, 151);
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
            this.btnStart.Location = new System.Drawing.Point(658, 202);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(177, 50);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // wpResults
            // 
            this.wpResults.AutoScroll = true;
            this.wpResults.AutoSize = true;
            this.wpResults.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.wpResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wpResults.Location = new System.Drawing.Point(3, 18);
            this.wpResults.Name = "wpResults";
            this.wpResults.Size = new System.Drawing.Size(835, 342);
            this.wpResults.TabIndex = 0;
            // 
            // CoolNameResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 651);
            this.Controls.Add(this.gbGAToolbox);
            this.Controls.Add(this.gbResult);
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
            this.ResumeLayout(false);

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
    }
}

