using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CoolNameGenerator.Properties;
using CoolNameGenerator.WordProcessor;

namespace CoolNameGenerator.Forms
{
    public partial class FinglishConverter : BaseForm
    {
        private Dictionary<string, string> _words;

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
            var path = GetWordsStorageFilePath();
            if (path != null)
            {
                File.WriteAllLines(path, GetWordsByFormat());
                Process.Start(path);
            }
        }
        private async void btnConvert_Click(object sender, EventArgs e)
        {
            btnImportPersianWords.Enabled = false;
            var api = new FinglishConverterApi();
            api.ProgressChanged += Api_ProgressChanged;
            api.ProgressCompleted += (s, ea) => btnImportPersianWords.Enabled = true;
            var persians = _words.Select(x => x.Key).ToArray();
            progConvert.Maximum = persians.Length;
            progConvert.Value = 0;
            var result = await api.GetFinglishAsync(persians);
        }


        private void Api_ProgressChanged(string persian, string finglish, int row, int count)
        {
            _words[persian] = finglish;
            progConvert.Value++;
            foreach (DataGridViewRow dgvRow in dgvWords.Rows)
            {
                if (((string)dgvRow.Cells["colPersianName"].Value).Equals(persian, StringComparison.OrdinalIgnoreCase))
                {
                    dgvRow.Cells["colFinglishName"].Value = finglish;
                    dgvRow.DefaultCellStyle.BackColor = finglish == null ? Color.Brown : Color.Aquamarine;
                }
            }
        }

        private static string GetPersianWordsFilePath()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = Localization.OpenPersianFileDialogTitle;
                ofd.Filter = Localization.FilterWordFiles;
                ofd.CheckFileExists = true;
                return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : null;
            }
        }

        private static string GetWordsStorageFilePath()
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = Localization.SaveFinglishWordsFileDialogTitle;
                sfd.Filter = Localization.FilterWordFiles;
                return sfd.ShowDialog() == DialogResult.OK ? sfd.FileName : null;
            }
        }

        private void FillGrid(IEnumerable<string> persianNames)
        {
            _words = new Dictionary<string, string>();

            var row = 1;
            foreach (var name in persianNames.SkipWhile(seq => seq.Contains(":")).SelectMany(x => x.Split(WordHelper.NotIgnoreChars)).Distinct().SkipWhile(string.IsNullOrEmpty))
            {
                var word = name.Trim(WordHelper.NotIgnoreChars);
                _words[word] = "";
                dgvWords.Rows.Add(row++, word, "");
            }

            btnConvert.Enabled = true;
        }

        public string[] GetWordsByFormat()
        {
            var result = _words.Select(kv => string.IsNullOrEmpty(kv.Value) ? kv.Key
                : kv.Value.Length < 4 ? $"{kv.Value.Trim()}\t\t\t\t:\t{kv.Key}"
                : kv.Value.Length < 8 ? $"{kv.Value.Trim()}\t\t\t:\t{kv.Key}"
                : kv.Value.Length < 12 ? $"{kv.Value.Trim()}\t\t:\t{kv.Key}"
                : kv.Value.Length < 16 ? $"{kv.Value.Trim()}\t:\t{kv.Key}"
                : $"{kv.Value.Trim()}:\t{kv.Key}").ToArray();

            return result;
        }
    }
}