using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CoolNameGenerator.Helper;
using CoolNameGenerator.Properties;

namespace CoolNameGenerator.Forms
{
    public partial class FinglishConverter : BaseForm
    {
        private readonly object _syncLocker = new object();
        private CancellationTokenSource _cts;
        private Dictionary<string, string> _words;


        public FinglishConverter()
        {
            InitializeComponent();

            numMaxParallelismDegree.Value = Environment.ProcessorCount;
        }

        private void btnImportPersianWords_Click(object sender, EventArgs e)
        {
            var path = FileExtensions.GetFilePath();
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
            btnConvert.Enabled = false;
            chkParallelProcess.Enabled = false;
            numMaxParallelismDegree.Enabled = false;
            btnCancel.Enabled = true;

            _cts = new CancellationTokenSource();
            var api = new FinglishConverterApi();
            api.ProgressChanged += Api_ProgressChanged;
            api.ProgressCompleted += (s, ea) =>
            {
                btnImportPersianWords.Enabled = true;
                chkParallelProcess.Enabled = true;
                btnConvert.Enabled = true;
                numMaxParallelismDegree.Enabled = true;
                btnCancel.Enabled = false;
                Cursor = Cursors.Default;
            };

            var persians =
                _words.Where(w => string.IsNullOrEmpty(w.Value) || w.Value.StartsWith("<HTML>"))
                    .Select(x => x.Key)
                    .ToArray();
            progConvert.Maximum = persians.Length;
            progConvert.Value = 0;
            api.MaxParallelismDegree = (int) numMaxParallelismDegree.Value;
            var result = chkParallelProcess.Checked
                ? await api.GetParallelFinglishAsync(persians, _cts)
                : await api.GetFinglishAsync(persians, _cts);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnCancel.Enabled = false;
            _cts.Cancel();
        }


        private void Api_ProgressChanged(string persian, string finglish)
        {
            _words[persian] = finglish;
            lock (_syncLocker)
            {
                progConvert.InvokeIfRequired(() => progConvert.Value++);
                lblCounter.InvokeIfRequired(() => lblCounter.Text = $"{progConvert.Value}/{progConvert.Maximum}");
            }

            foreach (DataGridViewRow dgvRow in dgvWords.Rows)
            {
                if (((string) dgvRow.Cells["colPersianName"].Value).Equals(persian, StringComparison.OrdinalIgnoreCase))
                {
                    dgvWords.InvokeIfRequired(() =>
                    {
                        dgvRow.Cells["colFinglishName"].Value = finglish;
                        dgvRow.DefaultCellStyle.BackColor = finglish == null ? Color.Brown : Color.Aquamarine;
                    });
                }
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
            _words = persianNames.GetPairUniqueWords();
            dgvWords.Rows.Clear();

            var row = 1;
            foreach (var w in _words)
            {
                var index = dgvWords.Rows.Add(row++, w.Key, w.Value);
                if (w.Value != null) dgvWords.Rows[index].DefaultCellStyle.BackColor = Color.Aquamarine;
            }

            btnConvert.Enabled = true;
        }

        protected string[] GetWordsByFormat()
        {
            var result = _words.Select(kv => string.IsNullOrEmpty(kv.Value)
                ? kv.Key
                : kv.Value.Trim().Length < 04
                    ? $"{kv.Value.Trim()}\t\t\t\t\t:\t\t{kv.Key}"
                    : kv.Value.Trim().Length < 08
                        ? $"{kv.Value.Trim()}\t\t\t\t:\t\t{kv.Key}"
                        : kv.Value.Trim().Length < 12
                            ? $"{kv.Value.Trim()}\t\t\t:\t\t{kv.Key}"
                            : kv.Value.Trim().Length < 16
                                ? $"{kv.Value.Trim()}\t\t:\t\t{kv.Key}"
                                : kv.Value.Trim().Length < 20
                                    ? $"{kv.Value.Trim()}\t:\t\t{kv.Key}"
                                    : $"{kv.Value.Trim()}:\t\t{kv.Key}").ToArray();

            return result;
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            _cts?.Cancel();
            base.OnClosing(e);
        }
    }
}