namespace CoolNameGenerator.Forms
{
    partial class FinglishConverter
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbResultWords = new System.Windows.Forms.GroupBox();
            this.dgvWords = new System.Windows.Forms.DataGridView();
            this.colRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersianName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinglishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbToolbox = new System.Windows.Forms.GroupBox();
            this.chkParallelProcess = new System.Windows.Forms.CheckBox();
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.progConvert = new System.Windows.Forms.ProgressBar();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.btnImportPersianWords = new System.Windows.Forms.Button();
            this.numMaxParallelismDegree = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbResultWords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).BeginInit();
            this.gbToolbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxParallelismDegree)).BeginInit();
            this.SuspendLayout();
            // 
            // gbResultWords
            // 
            this.gbResultWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultWords.Controls.Add(this.dgvWords);
            this.gbResultWords.Location = new System.Drawing.Point(12, 145);
            this.gbResultWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbResultWords.Name = "gbResultWords";
            this.gbResultWords.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbResultWords.Size = new System.Drawing.Size(748, 255);
            this.gbResultWords.TabIndex = 0;
            this.gbResultWords.TabStop = false;
            this.gbResultWords.Text = "Result";
            // 
            // dgvWords
            // 
            this.dgvWords.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvWords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvWords.ColumnHeadersHeight = 40;
            this.dgvWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRow,
            this.colPersianName,
            this.colFinglishName});
            this.dgvWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWords.Location = new System.Drawing.Point(3, 17);
            this.dgvWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvWords.Name = "dgvWords";
            this.dgvWords.RowHeadersWidth = 35;
            this.dgvWords.RowTemplate.Height = 24;
            this.dgvWords.Size = new System.Drawing.Size(742, 236);
            this.dgvWords.TabIndex = 0;
            // 
            // colRow
            // 
            this.colRow.Frozen = true;
            this.colRow.HeaderText = "Row";
            this.colRow.Name = "colRow";
            this.colRow.ReadOnly = true;
            // 
            // colPersianName
            // 
            this.colPersianName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPersianName.HeaderText = "PersianName";
            this.colPersianName.Name = "colPersianName";
            // 
            // colFinglishName
            // 
            this.colFinglishName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFinglishName.HeaderText = "FinglishName";
            this.colFinglishName.Name = "colFinglishName";
            // 
            // gbToolbox
            // 
            this.gbToolbox.Controls.Add(this.numMaxParallelismDegree);
            this.gbToolbox.Controls.Add(this.chkParallelProcess);
            this.gbToolbox.Controls.Add(this.lblCounter);
            this.gbToolbox.Controls.Add(this.btnCancel);
            this.gbToolbox.Controls.Add(this.progConvert);
            this.gbToolbox.Controls.Add(this.btnConvert);
            this.gbToolbox.Controls.Add(this.btnSaveResult);
            this.gbToolbox.Controls.Add(this.btnImportPersianWords);
            this.gbToolbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbToolbox.Location = new System.Drawing.Point(0, 0);
            this.gbToolbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbToolbox.Name = "gbToolbox";
            this.gbToolbox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbToolbox.Size = new System.Drawing.Size(772, 139);
            this.gbToolbox.TabIndex = 1;
            this.gbToolbox.TabStop = false;
            this.gbToolbox.Text = "Toolbox";
            // 
            // chkParallelProcess
            // 
            this.chkParallelProcess.AutoSize = true;
            this.chkParallelProcess.Location = new System.Drawing.Point(413, 31);
            this.chkParallelProcess.Name = "chkParallelProcess";
            this.chkParallelProcess.Size = new System.Drawing.Size(128, 21);
            this.chkParallelProcess.TabIndex = 6;
            this.chkParallelProcess.Text = "ParallelProcess";
            this.toolTip.SetToolTip(this.chkParallelProcess, "Processing word by parallelism algorithm?");
            this.chkParallelProcess.UseVisualStyleBackColor = true;
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(413, 61);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(149, 17);
            this.lblCounter.TabIndex = 5;
            this.lblCounter.Text = "WordProgressCounter";
            this.toolTip.SetToolTip(this.lblCounter, "Word Progress Counter");
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(321, 31);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 47);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // progConvert
            // 
            this.progConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progConvert.Location = new System.Drawing.Point(12, 98);
            this.progConvert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progConvert.Name = "progConvert";
            this.progConvert.Size = new System.Drawing.Size(744, 23);
            this.progConvert.TabIndex = 3;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(628, 31);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(128, 47);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveResult.Location = new System.Drawing.Point(187, 31);
            this.btnSaveResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(128, 47);
            this.btnSaveResult.TabIndex = 1;
            this.btnSaveResult.Text = "SaveResult";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // btnImportPersianWords
            // 
            this.btnImportPersianWords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportPersianWords.Location = new System.Drawing.Point(12, 31);
            this.btnImportPersianWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImportPersianWords.Name = "btnImportPersianWords";
            this.btnImportPersianWords.Size = new System.Drawing.Size(168, 47);
            this.btnImportPersianWords.TabIndex = 0;
            this.btnImportPersianWords.Text = "ImportPersianWords";
            this.btnImportPersianWords.UseVisualStyleBackColor = true;
            this.btnImportPersianWords.Click += new System.EventHandler(this.btnImportPersianWords_Click);
            // 
            // numMaxParallelismDegree
            // 
            this.numMaxParallelismDegree.Location = new System.Drawing.Point(556, 30);
            this.numMaxParallelismDegree.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMaxParallelismDegree.Name = "numMaxParallelismDegree";
            this.numMaxParallelismDegree.Size = new System.Drawing.Size(61, 22);
            this.numMaxParallelismDegree.TabIndex = 7;
            this.toolTip.SetToolTip(this.numMaxParallelismDegree, "Max of Parallelism Degree");
            this.numMaxParallelismDegree.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 50;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // FinglishConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 412);
            this.Controls.Add(this.gbToolbox);
            this.Controls.Add(this.gbResultWords);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(790, 310);
            this.Name = "FinglishConverter";
            this.Text = "FinglishConverter";
            this.gbResultWords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).EndInit();
            this.gbToolbox.ResumeLayout(false);
            this.gbToolbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxParallelismDegree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbResultWords;
        private System.Windows.Forms.GroupBox gbToolbox;
        private System.Windows.Forms.Button btnImportPersianWords;
        private System.Windows.Forms.DataGridView dgvWords;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar progConvert;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersianName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinglishName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.CheckBox chkParallelProcess;
        private System.Windows.Forms.NumericUpDown numMaxParallelismDegree;
        private System.Windows.Forms.ToolTip toolTip;
    }
}