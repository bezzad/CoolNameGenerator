using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CoolNameGenerator.GeneticWordProcessing;
using CoolNameGenerator.Helper;
using System.Threading.Tasks;

namespace CoolNameGenerator.Graphics
{
    public partial class WordsDictionary : UserControl
    {
        #region Properties

        public UniqueWords Words { get; set; }

        public string DictionaryName { get; set; }

        public double DuplicateMatchingFitness
        {
            get { return Words.DuplicateMatchingFitness; }
            set
            {
                Words.DuplicateMatchingFitness = value;
                numDuplicateMatchScore.Value = (decimal)value;
            }
        }

        public double MatchingFitness
        {
            get
            {
                return Words.MatchingFitness;
            }
            set
            {
                Words.MatchingFitness = value;
                numMatchScore.Value = (decimal)value;
            }
        }

        public double NoMatchingFitness
        {
            get
            {
                return Words.NoMatchingFitness;
            }
            set
            {
                Words.NoMatchingFitness = value;
                numNoMatchScore.Value = (decimal)value;
            }
        }

        public new bool Enabled
        {
            get { return chkEnabled.Checked; }
            set
            {
                base.Enabled = value;
                chkEnabled.Checked = value;
            }
        }

        #endregion

        #region Constructors

        public WordsDictionary()
        {
            InitializeComponent();

            btnBrowse.Click += BtnBrowse_Click;
            numDuplicateMatchScore.ValueChanged += (s, e) => Words.DuplicateMatchingFitness = (double)numDuplicateMatchScore.Value;
            numMatchScore.ValueChanged += (s, e) => Words.MatchingFitness = (double)numMatchScore.Value;
            numNoMatchScore.ValueChanged += (s, e) => Words.NoMatchingFitness = (double)numNoMatchScore.Value;
            chkEnabled.CheckedChanged += (s, e) =>
            {
                gbProperties.Enabled = chkEnabled.Checked;
                txtFileAddress.Enabled = chkEnabled.Checked;
                btnBrowse.Enabled = chkEnabled.Checked;
            };
        }

        #endregion

        #region Methods

        private async void BtnBrowse_Click(object sender, EventArgs e)
        {
            var path = FileExtensions.GetFilePath();
            await LoadData(path);
        }

        public async Task LoadData(string path)
        {
            if (path != null)
            {
                DictionaryName = Path.GetFileNameWithoutExtension(path);
                gbControl.Text = DictionaryName;
                var data = await path.ReadAllLinesAsync(Encoding.UTF8);
                var uWords = data.GetUniqueWords();
                Words = new UniqueWords(DictionaryName, uWords);
                txtFileAddress.Text = path;
                gbProperties.Enabled = true;
            }
            else
            {
                txtFileAddress.Text = string.Empty;
                gbProperties.Enabled = false;
            }
        }

        #endregion
    }
}