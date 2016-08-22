using System;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.Forms
{
    public partial class CoolNameResultForm : BaseForm
    {
        public CoolNameResultForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 300; i++)
            {
                txtResult.Text += WordHelper.GenerateWord(RandomNumber.Next((int)numWordMinLen.Value, 
                    (int)numWordMaxLen.Value), chkHasNumeric.Checked, chkHasHyphen.Checked) + Environment.NewLine;
            }
        }
    }
}
