using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolNameGenerator.GeneticWordProcessing;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.Graphics
{
    public partial class WordsDictionary : BaseUserControl
    {
        #region Constructors

        public WordsDictionary()
        {
            InitializeComponent();

            btnBrowse.Click += BtnBrowse_Click;
            numDuplicateMatchScore.ValueChanged +=
                (s, e) => Words.DuplicateMatchingFitness = (double) numDuplicateMatchScore.Value;
            numMatchScore.ValueChanged += (s, e) => Words.MatchingFitness = (double) numMatchScore.Value;
            numNoMatchScore.ValueChanged += (s, e) => Words.NoMatchingFitness = (double) numNoMatchScore.Value;
            chkIncludeMiddleSubWords.CheckedChanged +=
                (s, e) => Words.IncludeMiddleSubWords = chkIncludeMiddleSubWords.Checked;
            chkEnabled.CheckedChanged += (s, e) =>
            {
                gbProperties.Enabled = chkEnabled.Checked;
                txtFileAddress.Enabled = chkEnabled.Checked;
                btnBrowse.Enabled = chkEnabled.Checked;
            };
        }

        #endregion

        #region Properties

        public UniqueWords Words { get; set; }

        public string DictionaryName { get; set; }

        public double DuplicateMatchingFitness
        {
            get { return Words.DuplicateMatchingFitness; }
            set
            {
                Words.DuplicateMatchingFitness = value;
                numDuplicateMatchScore.Value = (decimal) value;
            }
        }

        public double MatchingFitness
        {
            get { return Words.MatchingFitness; }
            set
            {
                Words.MatchingFitness = value;
                numMatchScore.Value = (decimal) value;
            }
        }

        public double NoMatchingFitness
        {
            get { return Words.NoMatchingFitness; }
            set
            {
                Words.NoMatchingFitness = value;
                numNoMatchScore.Value = (decimal) value;
            }
        }

        public bool IncludeMiddleSubWords
        {
            get { return Words.IncludeMiddleSubWords; }
            set
            {
                Words.IncludeMiddleSubWords = value;
                chkIncludeMiddleSubWords.Checked = value;
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

        public Color BorderColor { get; set; } = Color.OrangeRed;

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

        protected override void OnPaint(PaintEventArgs e)
        {
            //get the text size in group-box
            var tSize = TextRenderer.MeasureText(Text, Font);

            var borderRect = e.ClipRectangle;
            borderRect.Y = borderRect.Y + tSize.Height/2;
            borderRect.Height = borderRect.Height - tSize.Height/2;
            borderRect.X++;
            borderRect.Width -= 2;
            ControlPaint.DrawBorder(e.Graphics, borderRect, BorderColor, ButtonBorderStyle.Solid);

            var textRect = e.ClipRectangle;
            textRect.X = textRect.X + 6;
            textRect.Width = tSize.Width;
            textRect.Height = tSize.Height;
            e.Graphics.FillRectangle(new SolidBrush(BackColor), textRect);
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRect);
        }

        #endregion
    }
}