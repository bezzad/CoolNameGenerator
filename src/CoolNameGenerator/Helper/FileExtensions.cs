﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CoolNameGenerator.Helper
{
    public static class FileExtensions
    {
        public static async Task<HashSet<string>> ReadWordFileAsync(string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory, $"Resources\\{fileName}.txt");

            if (!File.Exists(path)) return null;

            var words = await path.ReadAllLinesAsync(Encoding.UTF8);
            var uniqueWords = words.GetUniqueWords();

            return uniqueWords;
        }

        public static async Task<string[]> ReadAllLinesAsync(this string path, Encoding encoding)
        {
            var lines = new List<string>();

            using (var reader = new StreamReader(path, encoding))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines.ToArray();
        }
    }
}