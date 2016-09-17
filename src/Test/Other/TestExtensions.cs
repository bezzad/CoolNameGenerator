using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using CoolNameGenerator.GA.Randomizations;
using CoolNameGenerator.GeneticWordProcessing;
using CoolNameGenerator.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Other
{
    [TestClass]
    public class TestExtensions
    {
        [TestMethod]
        [TestCategory("ChunkArray(...)")]
        public void TestChunkArray()
        {
            for (int dup = 0; dup < 100; dup++)
            {
                var chunkCount = FastRandom.Next(0, 100000);
                var aryLength = FastRandom.Next(0, 100000);

                // build sample data with aryLength Strings
                string[] items = Enumerable.Range(1, aryLength).Select(i => "Item" + i).ToArray();

                // split on groups with each chunkSize items
                var arys = items.ChunkArray(chunkCount);

                Assert.AreEqual(items.Length, aryLength, "items array length not equal by aryLength variable");

                Assert.AreEqual(arys.Length, chunkCount, "Splited arrays count not equal by chunkSize variable");

                Assert.AreEqual(arys.Sum(x => x.Length), aryLength, "Sum of chunk arrays length not equal by aryLength variable");
            }
        }

        [TestMethod]
        public void TestGetSubWords()
        {
            for (int i = 2; i < 1000; i++)
            {
                var word = new WordChromosome(i * FastRandom.Next(1, 10), false, false).ToString();
                var subWords = word.GetSubWords();
                // if n=word.Length  then  subWords.Count = n*(n-1)/2
                var n = word.Length;
                var count = n * (n - 1) / 2;
                Assert.AreEqual(count, subWords.Count);

                foreach (var subWord in subWords)
                {
                    Assert.IsTrue(word.Contains(subWord));
                }
            }
        }

        [TestMethod]
        public void TestGetSubWordsByCoveragePercent()
        {
            for (int i = 2; i < 100; i++)
            {
                var word = new WordChromosome(i * FastRandom.Next(1, 10), false, false).ToString();
                var subWords = word.GetSubWordsByCoverage();
                // if n=word.Length  then  subWords.Count = n*(n-1)/2
                var n = word.Length;
                //var count = n * (n - 1) / 2;
                //Assert.AreEqual(count, subWords.Count, "Count of sub words is incorrect!");// may be some sub words of a word are duplicate

                foreach (var subWord in subWords)
                {
                    Assert.IsTrue(word.Contains(subWord.Key));
                }
            }

            var words = new Dictionary<string, Dictionary<string, double>>
            {
                ["test"] = "test".GetSubWordsByCoverage(),
                ["behzad"] = "behzad".GetSubWordsByCoverage(),
                ["ahmed"] = "ahmed".GetSubWordsByCoverage()
            };

            Assert.AreEqual(words["test"].Count, 6);
            Assert.AreEqual(words["test"]["test"], 100);
            Assert.AreEqual(words["test"]["tes"], 75);
            Assert.AreEqual(words["test"]["te"], 50);
            Assert.AreEqual(words["test"]["es"], 50);
            Assert.AreEqual(words["test"]["st"], 50);
            Assert.AreEqual(words["test"]["est"], 75);


            Assert.AreEqual(words["behzad"].Count, 15);
        }

        [TestMethod]
        public void TestCountOverlap()
        {
            var overlappingWords = new Dictionary<string, int>()
            {
                { "abookeye", 2},
                { "waterminate", 7 }
            };

            var matchWords = new Dictionary<string, HashSet<string>>()
            {
                { "abookeye", new HashSet<string>() {"book", "okey", "eye"} },
                { "waterminate", new HashSet<string>() {"water", "term", "terminate", "min", "nate"} }
            };

            foreach (var matchWord in matchWords)
            {
                Assert.AreEqual(matchWord.Key.CountOverlap(matchWord.Value), overlappingWords[matchWord.Key]);
            }
        }
    }
}