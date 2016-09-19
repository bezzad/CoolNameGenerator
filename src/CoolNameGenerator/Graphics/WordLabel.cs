using CoolNameGenerator.Helper;
using System.Drawing;
using System.Windows.Forms;

namespace CoolNameGenerator.Graphics
{
    public sealed class WordLabel : System.Windows.Forms.Label
    {
        private readonly ToolTip _toolTip;

        public double? Fitness { get; set; }

        public WordLabel(string text, double fitness) : this(text)
        {
            Fitness = fitness;
        }

        public WordLabel(string text) : this()
        {
            Text = text;
        }

        public WordLabel()
        {
            _toolTip = new ToolTip
            {
                // Set up the delays for the ToolTip.
                AutoPopDelay = 50000, 
                // Force the ToolTip text to be displayed whether or not the form is active.
                InitialDelay = 100,
                ReshowDelay = 50,
                ShowAlways = true
            };
            // 
            // Initialize Control
            // 
            AutoEllipsis = true;
            this.AutoSize = false;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Font = new System.Drawing.Font("Segoe UI Symbol", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Size = new System.Drawing.Size(287, 50);
            Text = "Word";
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Padding = new Padding(10);
        }

        public void IsElit()
        {
            ForeColor = Color.Brown;
            Font = new System.Drawing.Font("Segoe UI Symbol", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                this.InvokeIfRequired(() =>
                {
                    base.Text = value;
                    var tooltipContent = Fitness != null 
                        ? $" Word: {Text} \n\r Fitness: {Fitness} \r\n Length: {Text.Length}" 
                        : $"  Word: {Text} \n\r Length: {Text.Length}";
                    _toolTip.SetToolTip(this, tooltipContent);
                });
            }
        }
    }
}