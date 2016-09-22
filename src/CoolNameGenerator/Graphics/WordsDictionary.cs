using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CoolNameGenerator.GeneticWordProcessing;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.Graphics
{
    public partial class WordsDictionary : UserControl
    {
        public UniqueWords Words { get; set; }
        public double DuplicateMatchingFitness
        {
            get
            {
                return (double)numDuplicateMatchScore.Value;
            }
            set { numDuplicateMatchScore.Value = (decimal)value; }
        }
        public double MatchingFitness
        {
            get
            {
                return (double)numMatchScore.Value;
            }
            set { numMatchScore.Value = (decimal)value; }
        }
        public double NoMatchingFitness
        {
            get
            {
                return (double)numNoMatchScore.Value;
            }
            set { numNoMatchScore.Value = (decimal)value; }
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

        public WordsDictionary()
        {
            InitializeComponent();

            btnBrowse.Click += BtnBrowse_Click;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            var path = FileExtensions.GetFilePath();
            if (path != null)
            {
                var data = File.ReadAllLines(path, Encoding.UTF8);
                
            }
        }
    }
}