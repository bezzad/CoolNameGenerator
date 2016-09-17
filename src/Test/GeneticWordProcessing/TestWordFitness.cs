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
                {"add", -1},
                {"namaat", -1},
                {"robbad", -1},
                {"tabiiat", -1},
                {"fashhh", -3},
                {"matmmit", -1},
                {"matmit", 1},
                {"abababab", 1},
                {"aacadd", -2},
                {"aaadaaa", -6},
                {"abcdefgh", 1},
                {"khizzdn", -1},
                {"khizdar", 1},
                {"matter", -1},
                {"system", 1},
                {"esttar", -1},
                {"behzad", 1},
                {"ahmad", 1},
                {"ogoo", -1},
                {"aaaaax", -7},
                {"aaaabbaaa", -9},
                {"axcca", -1},
                {"axaaaaa", -7},
                {"aaaa", -5}
            };

            foreach (var word in words)
            {
                Assert.AreEqual(fitness.EvaluateDuplicatChar(word.Key), word.Value,
                    $"The {word.Key} fitness is not equal by: {word.Value}");
            }
        }


        [TestMethod]
        public void TestEvaluateLength()
        {
            var fitness = new WordFitness();

            var words = new Dictionary<string, int>()
            {
                {"12", 0},
                {"123", 1},
                {"1234", 3},
                {"12345", 9},
                {"123456", 10},
                {"1234567", 10},
                {"12345678", 9},
                {"123456789", 8},
                {"1234567890", 7},
                {"12345678901", 3},
                {"123456789012", 3},
                {"1234567890123", 1},
                {"12345678901234", 0},
                {"123456789012345", 0},
                {"1234567890123456", 0},
                {"12345678901234567", 0},
                {"123456789012345678", 0},
                {"1234567890123456789", 0},
                {"12345678901234567890", -1},
                {"123456789012345678901", -2},
                {"1234567890123456789012", -3},
                {"12345678901234567890123", -4},
                {"123456789012345678901234", -5},
                {"1234567890123456789012345", -6}
            };

            foreach (var word in words)
            {
                Assert.AreEqual(fitness.EvaluateLength(word.Key.Length), word.Value,
                    $"The {word.Key} fitness is not equal by: {word.Value}");
            }
        }

        [TestMethod]
        public void TestEvaluateMatchingEnglishWords()
        {
            var fitness = new WordFitness();

            var englishWords = new UniqueWords("EnglishWords", new[]
            {
                "book",
                "keeper",
                "eye",
                "name",
                "taxi",
                "hotel",
                "okey"
            })
            {
                DuplicateMatchingFitness = -2,
                MatchingFitness = 3,
                UnMatchingFitness = -1
            };

            var englishNames = new UniqueWords("EnglishNames", new[]
            {
                "davis",
                "miller",
                "wilson",
                "moore",
                "taylor",
                "anderson",
                "thoma",
                "jackson",
                "white",
                "harris",
                "martin"
            })
            {
                DuplicateMatchingFitness = -2,
                MatchingFitness = 2,
                UnMatchingFitness = 0
            };

            var finglishWords = new UniqueWords("FinglishWords", new[]
            {
                "taxi",
                "hotel",
                "raftan",
                "ketabdar",
                "esfand",
                "mahi",
                "harris"
            })
            {
                DuplicateMatchingFitness = -3,
                FriendWordList = new List<UniqueWords>() {englishWords, englishNames},
                MatchingFitness = 2,
                MatchingFriendsFitness = 2,
                UnMatchingFitness = 0
            };

            var finglishNames = new UniqueWords("FinglishNames", new[]
            {
                "arezoo",
                "behzad",
                "ahmad",
                "reza",
                "homaiun",
                "ande"
            })
            {
                DuplicateMatchingFitness = -2,
                FriendWordList = new List<UniqueWords>() {englishWords, englishNames, finglishWords},
                MatchingFitness = 4,
                MatchingFriendsFitness = 4,
                UnMatchingFitness = -1
            };


            var words = new Dictionary<string, int>()
            {
                {"bookeye", +8},
                {"hotelmoore", +8},
                {"1esfand8", +2},
                {"ataxi", +11},
                {"abook", -3},
                {"harris", -1},
                {"anderson", 1},
                {"thomaiun", 1},
                {"white", -2},
                {"abcde", -6},
                {"abcdefgh", 1},
                {"khizzdn", -1},
                {"khizdar", 1},
                {"matter", -1},
                {"system", 1},
                {"esttar", -1},
                {"behzad", 1},
                {"ahmedbehzadahmedbehzadahmed", 1},
                {"ahmedbehzadahmed", 1},
                {"ahmadahmedavis", 1},
                {"ahmadavisande", 1},
                {"ahmadahmedahmedahmed", 1},
                {"ahmadahmed", 1},
            };

            foreach (var word in words)
            {
                Assert.AreEqual(fitness.EvaluateMatchingEnglishWords(word.Key, englishNames, englishWords, finglishNames, finglishWords), word.Value,
                    $"The {word.Key} fitness is not equal by: {word.Value}");
            }
        }
    }
}