using System;
using System.Windows.Forms;

namespace CoolNameGenerator.Graphics
{
    public sealed class WordsPanel : FlowLayoutPanel
    {
        public Control[] WordsLabels;

        public WordsPanel(int wordsCount) : this()
        {
            SetWordsCount(wordsCount);
        }

        public WordsPanel()
        {
            //
            // Initialize Control
            //
            AutoScroll = true;
            AutoSize = true;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            Dock = System.Windows.Forms.DockStyle.Fill;
        }

        public void SetWordsCount(int count)
        {
            Controls.Clear();

            WordsLabels = new Control[count];
            for (var i = 0; i < count; i++)
            {
                WordsLabels[i] = new WordLabel();
            }

            Controls.AddRange(WordsLabels);
        }
    }
}
