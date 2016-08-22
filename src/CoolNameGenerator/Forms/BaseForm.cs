using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CoolNameGenerator.Properties;

namespace CoolNameGenerator.Forms
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();

            Load += (s, e) => LocalizingControl(this);
        }



        protected virtual void LocalizingControl(Control ctrl)
        {
            if (string.IsNullOrEmpty(ctrl?.Text)) return;

            ctrl.Text = Localization.ResourceManager.GetString(ctrl.Text);

            var controls = GetAllControls(ctrl);

            foreach (Control c in controls.SkipWhile(x => x.GetType() == typeof(NumericUpDown)))
            {
                var replacmentText = Localization.ResourceManager.GetString(c.Text);
                if (!string.IsNullOrEmpty(replacmentText))
                {
                    c.Text = replacmentText;
                }
            }
        }

        public IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        public IEnumerable<Control> GetAllControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(GetAllControls).Concat(controls);
        }
    }
}
