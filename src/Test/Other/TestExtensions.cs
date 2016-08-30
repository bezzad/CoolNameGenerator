using System;
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
            for (int i = 2; i < 100; i++)
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
    }
}