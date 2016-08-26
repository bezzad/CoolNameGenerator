﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CoolNameGenerator.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
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
                var chunkCount = RandomNumber.Next(0, 100000);
                var aryLength = RandomNumber.Next(0, 100000);

                // build sample data with aryLength Strings
                string[] items = Enumerable.Range(1, aryLength).Select(i => "Item" + i).ToArray();

                // split on groups with each chunkSize items
                var arys = items.ChunkArray(chunkCount);

                Assert.AreEqual(items.Length, aryLength, "items array lenght not equal by artLenght variable");

                Assert.AreEqual(arys.Length, chunkCount, "Splited arrays count not equal by chunkSize variable");

                Assert.AreEqual(arys.Sum(x => x.Length), aryLength, "Sum of chunk arrays length not equal by aryLength variable");
            }
        }
    }
}