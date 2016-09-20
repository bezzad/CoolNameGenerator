using System;
using CoolNameGenerator.Helper;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Randomizations;
using CoolNameGenerator.GeneticWordProcessing;

namespace CoolNameGenerator.Graphics
{
    public sealed class WordLabel : System.Windows.Forms.RichTextBox
    {
        private readonly ToolTip _toolTip;

        public WordLabel(WordChromosome word) : this(word.ToString(), word.Fitness ?? 0)
        {
            SetChromosome(word);
        }

        public WordLabel(string text, double fitness) : this(text)
        { }

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
            this.AutoSize = false;
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Size = new System.Drawing.Size(180, 50);
            Text = "Word";
            Padding = new Padding(10);
            ReadOnly = true;
            WordWrap = true;
            BackColor = Color.WhiteSmoke;
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                this.InvokeIfRequired(() => base.Text = value);
            }
        }

        private void SetTooltip(WordChromosome chromosome)
        {
            this.InvokeIfRequired(() =>
            {
                var wordLine = $"Word: {Text}";
                var fitnessLine = chromosome.Fitness != null ? $"Fitness: {chromosome.Fitness}" : "";
                var lenLine = $"Length: {Text.Length}";
                var matchedWordsLine = $"Matched Words:{Environment.NewLine}{string.Join(Environment.NewLine, chromosome.EvaluateInfo.MatchedUniqueWords.Select(m => $"[{m.Item2}:\t{m.Item1}]"))}";
                var matchedSubWordsLine = $"Matched SubWords:{Environment.NewLine}{string.Join(Environment.NewLine, chromosome.EvaluateInfo.MatchedUniqueSubWords)}";


                var tooltipContent = $"{wordLine}" +
                                     $"{Environment.NewLine}========================" +
                                     $"{Environment.NewLine}{fitnessLine}" +
                                     $"{Environment.NewLine}{lenLine}" +
                                     $"{Environment.NewLine}------------------------" +
                                     $"{Environment.NewLine}{matchedWordsLine}" +
                                     $"{Environment.NewLine}------------------------" +
                                     $"{Environment.NewLine}{matchedSubWordsLine}";


                _toolTip.SetToolTip(this, tooltipContent);
            });
        }

        public void SetChromosome(WordChromosome word)
        {
            var wordText = word.ToString();

            Text = wordText;
            SetTooltip(word);

            this.InvokeIfRequired(() =>
            {
                this.Select(0, Text.Length);
                SelectionBackColor = Color.WhiteSmoke;
                foreach (var matchedWord in word.EvaluateInfo.MatchedUniqueWords)
                {
                    var indexOfWord = wordText.IndexOf(matchedWord.Item1, StringComparison.Ordinal);
                    Select(indexOfWord, matchedWord.Item1.Length);

                    SelectionBackColor = matchedWord.Item1.ToColor();
                }
            });
        }
    }
}