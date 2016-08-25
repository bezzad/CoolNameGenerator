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
using CoolNameGenerator.Helper;
using CoolNameGenerator.Properties;
using CoolNameGenerator.WordProcessor;

namespace CoolNameGenerator.Forms
{
    public partial class FinglishConverter : BaseForm
    {
        private List<Tuple<string, string>> _words;

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
            var api = new FinglishConverterApi();
            var result = api.GetFinglish(_words.Select(x => x.Item1).ToArray());
            
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
            _words = new List<Tuple<string, string>>();

            var row = 1;
            foreach (var name in persianNames.SelectMany(x => x.Split(WordHelper.NotIgnoreChars)).Distinct().SkipWhile(string.IsNullOrEmpty))
            {
                var word = name.Trim(WordHelper.NotIgnoreChars).Trim();
                _words.Add(Tuple.Create(word, ""));
                dgvWords.Rows.Add(row++, word, "");
            }

            btnConvert.Enabled = true;
        }
    }
}