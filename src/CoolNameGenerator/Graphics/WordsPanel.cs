using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GeneticWordProcessing;

namespace CoolNameGenerator.Graphics
{
    public sealed class WordsPanel : FlowLayoutPanel
    {
        public List<WordLabel> WordsLabels { get; set; }

        public int Count { get; private set; }

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
            Count = count;
            Controls.Clear();

            WordsLabels = new List<WordLabel>();
            for (var i = 0; i < count; i++)
            {
                WordsLabels.Add(new WordLabel());
            }

            Controls.AddRange(WordsLabels.ToArray());
        }

        public void SetWords(IList<IChromosome> chromosomes)
        {
            if (chromosomes.Count > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(chromosomes));
            }

            for (var i = 0; i < Count; i++)
            {
                WordsLabels[i].SetChromosome((WordChromosome)chromosomes[i]);
            }
        }
    }
}
