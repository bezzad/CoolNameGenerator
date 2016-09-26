using System;
using System.Windows.Forms;

namespace CoolNameGenerator.Graphics
{
    public partial class BaseUserControl : UserControl
    {
        public BaseUserControl()
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