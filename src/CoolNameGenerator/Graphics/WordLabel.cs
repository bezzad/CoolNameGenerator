using CoolNameGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CoolNameGenerator.Graphics
{
    public sealed class WordLabel : System.Windows.Forms.Label
    {
        public WordLabel(string text) : this()
        {
            Text = text;
        }

        public WordLabel()
        {
            // 
            // Initialize Control
            // 
            AutoEllipsis = true;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Font = new System.Drawing.Font("Segoe UI Symbol", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Size = new System.Drawing.Size(287, 58);
            Text = "Word";
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
                });
            }
        }


    }
}
