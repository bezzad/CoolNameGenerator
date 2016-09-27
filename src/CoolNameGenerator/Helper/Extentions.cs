using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CoolNameGenerator.Helper
{
    public static class Extentions
    {
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public static T[][] ChunkArray<T>(this T[] array, int chunkCount)
        {
            var result = new T[chunkCount][];
            var arrRemainLen = array.Length;
            var chunkFloatSize = (double)arrRemainLen / chunkCount;
            if (chunkFloatSize < 1 && chunkFloatSize > 0) chunkFloatSize = 1;
            var chunkSize = (int)Math.Round(chunkFloatSize);

            // product some arrays[] with chunkCount number
            for (int cc = 0, srcIndex = 0; cc < chunkCount; cc++, srcIndex += chunkSize, arrRemainLen -= chunkSize)
            {
                if (arrRemainLen - chunkSize < 0 || cc + 1 == chunkCount)
                {
                    chunkSize = arrRemainLen;
                }

                result[cc] = new T[chunkSize];

                if (chunkSize > 0) Array.Copy(array, srcIndex, result[cc], 0, chunkSize);
            }
            return result;
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> items, Func<T, T, bool> equals, Func<T, int> hashCode)
        {
            return items.Distinct(new DelegateComparer<T>(equals, hashCode));
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> items, Func<T, T, bool> equals)
        {
            return items.Distinct(new DelegateComparer<T>(equals, null));
        }

        public static T Index<T>(this HashSet<T> hashSet, T containObj) where T : IEquatable<T>
        {
            return hashSet.First(x => ((IEquatable<T>)x).Equals(containObj));
        }


        public static Color ToColor(this string text, byte minRgb = 50, byte maxRgb = 50)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            var r = hash[0] < minRgb ? hash[0] + minRgb : hash[0] > maxRgb ? hash[0] - maxRgb : hash[0];
            var g = hash[1] < minRgb ? hash[1] + minRgb : hash[1] > maxRgb ? hash[1] - maxRgb : hash[1];
            var b = hash[2] < minRgb ? hash[2] + minRgb : hash[2] > maxRgb ? hash[2] - maxRgb : hash[2];
            return Color.FromArgb(r, g, b);
        }
    }
}