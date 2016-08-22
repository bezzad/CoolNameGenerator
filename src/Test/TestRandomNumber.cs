using System;
using System.Diagnostics;
using System.IO;
using CoolNameGenerator.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestRandomNumber
    {
        [TestMethod]
        [TestCategory("Next(...)")]
        public void TestRandomMaxMinRangeLimit()
        {
            for (var i = 0; i < 1000000; i++)
            {
                var rand = RandomNumber.Next(1000, 10000);
                Assert.AreEqual(rand >= 1000, true, "Min not correct");
                Assert.AreEqual(rand <= 10000, true, "Max not correct");
            }
        }

        [TestMethod]
        [TestCategory("Next(...)")]
        public void TestMaxMinNominalNearbly()
        {
            int minRand = 100, maxRand = 1000;
            int minApplyCount = 0, maxApplyCount = 0;
            var nearblyPercent = 0.05; // 5% range
            var maxTestRepeat = 1000000;

            for (var i = 0; i < maxTestRepeat; i++)
            {
                var rand = RandomNumber.Next(minRand, maxRand);
                if (rand >= minRand && rand <= (maxRand - minRand) * nearblyPercent + minRand) minApplyCount++;
                if (rand >= maxRand - (maxRand - minRand) * nearblyPercent && rand <= maxRand) maxApplyCount++;
            }

            Assert.AreEqual(minApplyCount >= maxTestRepeat * nearblyPercent, true, "Min not correct");
            Assert.AreEqual(maxApplyCount >= maxTestRepeat * nearblyPercent, true, "Max not correct");
        }

        [TestMethod]
        [TestCategory("Next(...)")]
        public void TestNearblyPercentage()
        {
            int minRand = 100, maxRand = 1000;
            int[] buffer = new int[maxRand + 1];
            for (var i = 0; i < 1000000; i++)
            {
                var rand = RandomNumber.Next(minRand, maxRand);
                buffer[rand]++;
            }

            var testFilePath = $@"{Environment.CurrentDirectory}\TestNearblyPercentage.txt";
            File.WriteAllText(testFilePath, "");
            for (int i = minRand; i <= maxRand; i++)
            {
                File.AppendAllText(testFilePath, $"{i} Duplication: {buffer[i]} {Environment.NewLine}");
            }
            Process.Start(testFilePath);

            for (int i = minRand; i <= maxRand; i++)
            {
                Assert.AreNotEqual(buffer[i], 0, $"Number {i} is Zero duplicate!");
                Assert.AreNotEqual(buffer[i] <= 50, true, $"Number {i} is less than 50 duplicate!");
            }
        }
    }
}