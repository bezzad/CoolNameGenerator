using System;
using System.Threading.Tasks;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.Forms
{
    public partial class CoolNameResultForm : BaseForm
    {
        public CoolNameResultForm()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            wpResults.SetWordsCount((int)numPopulationSize.Value);

            await Task.Delay(1000);
            for (int j = 0; j < 100; j++)
            {
                await Task.Delay(100);

                for (var i = 0; i < numPopulationSize.Value; i++)
                {
                    wpResults.WordsLabels[i].Text = WordHelper.GenerateWord(RandomNumber.Next((int)numWordMinLen.Value,
                        (int)numWordMaxLen.Value), chkHasNumeric.Checked, chkHasHyphen.Checked);
                }
            }

        }

        private void finglishConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FinglishConverter().ShowDialog();
        }
    }
}
