namespace CoolNameGenerator.Graphics
{
    partial class WordsDictionary
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFileAddress = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numMatchScore = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numNoMatchScore = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numDuplicateMatchScore = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkIncludeMiddleSubWords = new System.Windows.Forms.CheckBox();
            this.gbControl.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbProperties.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMatchScore)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNoMatchScore)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuplicateMatchScore)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFileAddress
            // 
            this.txtFileAddress.Location = new System.Drawing.Point(30, 7);
            this.txtFileAddress.Name = "txtFileAddress";
            this.txtFileAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFileAddress.Size = new System.Drawing.Size(188, 22);
            this.txtFileAddress.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnBrowse.Location = new System.Drawing.Point(234, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(46, 32);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = ". . .";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.flowLayoutPanel1);
            this.gbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbControl.Location = new System.Drawing.Point(0, 0);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(299, 263);
            this.gbControl.TabIndex = 2;
            this.gbControl.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.gbProperties);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(293, 242);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chkEnabled);
            this.panel1.Controls.Add(this.txtFileAddress);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 37);
            this.panel1.TabIndex = 2;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkEnabled.Location = new System.Drawing.Point(7, 11);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(18, 17);
            this.chkEnabled.TabIndex = 2;
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // gbProperties
            // 
            this.gbProperties.Controls.Add(this.flowLayoutPanel2);
            this.gbProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProperties.Enabled = false;
            this.gbProperties.Location = new System.Drawing.Point(3, 46);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(286, 193);
            this.gbProperties.TabIndex = 6;
            this.gbProperties.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Controls.Add(this.panel5);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(280, 172);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numMatchScore);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 37);
            this.panel2.TabIndex = 4;
            // 
            // numMatchScore
            // 
            this.numMatchScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMatchScore.Location = new System.Drawing.Point(194, 7);
            this.numMatchScore.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numMatchScore.Minimum = new decimal(new int[] {
            1215752191,
            23,
            0,
            -2147483648});
            this.numMatchScore.Name = "numMatchScore";
            this.numMatchScore.Size = new System.Drawing.Size(76, 22);
            this.numMatchScore.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "MatchScore";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numNoMatchScore);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 37);
            this.panel3.TabIndex = 5;
            // 
            // numNoMatchScore
            // 
            this.numNoMatchScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numNoMatchScore.Location = new System.Drawing.Point(194, 7);
            this.numNoMatchScore.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numNoMatchScore.Minimum = new decimal(new int[] {
            1215752191,
            23,
            0,
            -2147483648});
            this.numNoMatchScore.Name = "numNoMatchScore";
            this.numNoMatchScore.Size = new System.Drawing.Size(76, 22);
            this.numNoMatchScore.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "NoMatchScore";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.numDuplicateMatchScore);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(3, 89);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(273, 37);
            this.panel4.TabIndex = 6;
            // 
            // numDuplicateMatchScore
            // 
            this.numDuplicateMatchScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numDuplicateMatchScore.Location = new System.Drawing.Point(194, 7);
            this.numDuplicateMatchScore.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numDuplicateMatchScore.Minimum = new decimal(new int[] {
            1215752191,
            23,
            0,
            -2147483648});
            this.numDuplicateMatchScore.Name = "numDuplicateMatchScore";
            this.numDuplicateMatchScore.Size = new System.Drawing.Size(76, 22);
            this.numDuplicateMatchScore.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "DuplicateMatchScore";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkIncludeMiddleSubWords);
            this.panel5.Location = new System.Drawing.Point(3, 132);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(273, 37);
            this.panel5.TabIndex = 7;
            // 
            // chkIncludeMiddleSubWords
            // 
            this.chkIncludeMiddleSubWords.AutoSize = true;
            this.chkIncludeMiddleSubWords.Location = new System.Drawing.Point(9, 8);
            this.chkIncludeMiddleSubWords.Name = "chkIncludeMiddleSubWords";
            this.chkIncludeMiddleSubWords.Size = new System.Drawing.Size(182, 21);
            this.chkIncludeMiddleSubWords.TabIndex = 1;
            this.chkIncludeMiddleSubWords.Text = "IncludeMiddleSubWords";
            this.chkIncludeMiddleSubWords.UseVisualStyleBackColor = true;
            // 
            // WordsDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbControl);
            this.Name = "WordsDictionary";
            this.Size = new System.Drawing.Size(299, 263);
            this.gbControl.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbProperties.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMatchScore)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNoMatchScore)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuplicateMatchScore)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileAddress;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numMatchScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown numNoMatchScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown numDuplicateMatchScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkIncludeMiddleSubWords;
    }
}
