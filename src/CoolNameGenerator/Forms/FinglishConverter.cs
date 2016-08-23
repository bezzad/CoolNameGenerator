using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolNameGenerator.Properties;

namespace CoolNameGenerator.Forms
{
    public partial class FinglishConverter : BaseForm
    {
        public FinglishConverter()
        {
            InitializeComponent();
        }

        private void btnImportPersianWords_Click(object sender, EventArgs e)
        {
            var path = GetPersianWordsFilePath();
            if (path != null)
            {
                var data = File.ReadAllLines(path, Encoding.UTF8);
                FillGrid(data);
            }
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {

        }

        private string GetPersianWordsFilePath()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = Localization.OpenPersianFileDialogTitle;
                ofd.Filter = Localization.FilterWordFiles;
                ofd.CheckFileExists = true;
                return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : null;
            }
        }

        private void FillGrid(string[] persianNames)
        {
            var row = 1;
            foreach (var name in persianNames.Distinct().SkipWhile(string.IsNullOrEmpty))
            {
                dgvWords.Rows.Add(row++, name, "");
            }
        }
    }
}