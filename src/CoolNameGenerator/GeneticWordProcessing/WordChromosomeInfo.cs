using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.GA.Chromosomes;
using CoolNameGenerator.GA.Randomizations;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.GeneticWordProcessing
{
    public class WordChromosomeInfo
    {
        #region Properties      

        public HashSet<string> MatchedUniqueWords { get; set; }
        public HashSet<string> MatchedUniqueSubWords { get; set; }

        #endregion

        public WordChromosomeInfo()
        {
            MatchedUniqueWords = new HashSet<string>();
            MatchedUniqueSubWords = new HashSet<string>();
        }
    }
}