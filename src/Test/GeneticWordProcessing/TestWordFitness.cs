using System;
using System.Collections.Generic;
using CoolNameGenerator.GeneticWordProcessing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.GeneticWordProcessing
{
    [TestClass]
    public class TestWordFitness
    {
        [TestMethod]
        public void TestEvaluateDuplicatChar()
        {
            var fitness = new WordFitness();

            var words = new Dictionary<string, int>()
            {
                { "add", -1},
                { "namaat", -1},
                { "robbad", -1},
                { "tabiiat", -1},
                { "fashhh", -3},
                { "matmmit", -1},
                { "matmit", 1},
                { "abababab", 1},
                { "aacadd", -2},
                { "aaadaaa", -6},
                { "abcdefgh", 1},
                { "khizzdn", -1},
                { "khizdar", 1},
                { "matter", -1},
                { "system", 1},
                { "esttar", -1},
                { "behzad", 1},
                { "ahmad", 1},
                { "ogoo", -1},
                { "aaaaax", -7},
                { "aaaabbaaa", -9},
                { "axcca", -1},
                { "axaaaaa", -7},
                { "aaaa", -5}
            };

            foreach (var word in words)
            {
                Assert.AreEqual(fitness.EvaluateDuplicatChar(word.Key), word.Value, $"The {word.Key} fitness is not equal by: {word.Value}");
            }
        }
    }
}
