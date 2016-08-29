﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolNameGenerator.GA.Fitnesses
{
    public static class FitnessExtensions
    {
        public static double EvaluateScoreByIntVal(this int totalFitness)
        {
            return 1 - ((double) 1/totalFitness);
        }
    }
}
