﻿using System;
using System.Collections.Generic;

namespace CoolNameGenerator.GeneticWordProcessing
{
    public class WordChromosomeInfo
    {
        public WordChromosomeInfo()
        {
            Reset();
        }

        public void Reset()
        {
            MatchedUniqueWords = new List<Tuple<string, string>>();
            MatchedUniqueSubWords = new List<string>();
        }

        #region Properties      

        public List<Tuple<string, string>> MatchedUniqueWords { get; set; }
        public List<string> MatchedUniqueSubWords { get; set; }

        #endregion
    }
}