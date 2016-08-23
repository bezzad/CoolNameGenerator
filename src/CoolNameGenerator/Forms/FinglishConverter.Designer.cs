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
            this.gbResultWords = new System.Windows.Forms.GroupBox();
            this.dgvWords = new System.Windows.Forms.DataGridView();
            this.gbToolbox = new System.Windows.Forms.GroupBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.btnImportPersianWords = new System.Windows.Forms.Button();
            this.progConvert = new System.Windows.Forms.ProgressBar();
            this.gbResultWords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).BeginInit();
            this.gbToolbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbResultWords
            // 
            this.gbResultWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultWords.Controls.Add(this.dgvWords);
            this.gbResultWords.Location = new System.Drawing.Point(12, 145);
            this.gbResultWords.Name = "gbResultWords";
            this.gbResultWords.Size = new System.Drawing.Size(642, 382);
            this.gbResultWords.TabIndex = 0;
            this.gbResultWords.TabStop = false;
            this.gbResultWords.Text = "Result";
            // 
            // dgvWords
            // 
            this.dgvWords.AllowUserToAddRows = false;
            this.dgvWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWords.Location = new System.Drawing.Point(3, 18);
            this.dgvWords.Name = "dgvWords";
            this.dgvWords.RowTemplate.Height = 24;
            this.dgvWords.Size = new System.Drawing.Size(636, 361);
            this.dgvWords.TabIndex = 0;
            // 
            // gbToolbox
            // 
            this.gbToolbox.Controls.Add(this.progConvert);
            this.gbToolbox.Controls.Add(this.btnConvert);
            this.gbToolbox.Controls.Add(this.btnSaveResult);
            this.gbToolbox.Controls.Add(this.btnImportPersianWords);
            this.gbToolbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbToolbox.Location = new System.Drawing.Point(0, 0);
            this.gbToolbox.Name = "gbToolbox";
            this.gbToolbox.Size = new System.Drawing.Size(666, 139);
            this.gbToolbox.TabIndex = 1;
            this.gbToolbox.TabStop = false;
            this.gbToolbox.Text = "Toolbox";
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvert.Location = new System.Drawing.Point(523, 31);
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
            this.btnSaveResult.Location = new System.Drawing.Point(186, 31);
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
            this.btnImportPersianWords.Name = "btnImportPersianWords";
            this.btnImportPersianWords.Size = new System.Drawing.Size(168, 47);
            this.btnImportPersianWords.TabIndex = 0;
            this.btnImportPersianWords.Text = "ImportPersianWords";
            this.btnImportPersianWords.UseVisualStyleBackColor = true;
            this.btnImportPersianWords.Click += new System.EventHandler(this.btnImportPersianWords_Click);
            // 
            // progConvert
            // 
            this.progConvert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progConvert.Location = new System.Drawing.Point(12, 99);
            this.progConvert.Name = "progConvert";
            this.progConvert.Size = new System.Drawing.Size(639, 23);
            this.progConvert.TabIndex = 3;
            // 
            // FinglishConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 539);
            this.Controls.Add(this.gbToolbox);
            this.Controls.Add(this.gbResultWords);
            this.Name = "FinglishConverter";
            this.Text = "FinglishConverter";
            this.gbResultWords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).EndInit();
            this.gbToolbox.ResumeLayout(false);
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
    }
}