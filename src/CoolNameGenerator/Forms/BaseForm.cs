using System;
using System.Windows.Forms;
using CoolNameGenerator.Graphics;

namespace CoolNameGenerator.Forms
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();

            Load += (s, e) => this.LocalizingControl();
            Application.Idle += LoadCompleted;
        }

        protected virtual void LoadCompleted(object sender, EventArgs e)
        {
            Application.Idle -= LoadCompleted;

            // on loaded codes at child forms ...
        }
    }
}