using System;
using System.Collections.Generic;
using System.Linq;
using CoolNameGenerator.Properties;

namespace CoolNameGenerator.GA.Randomizations
{
    public static class FastRandom
    {
        public static int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(minValue), Localization.Argument_MinMaxValue);
            }

            return (int)Math.Round(Next() * (maxValue - minValue) + minValue);
        }

        /// <summary>
        /// Randoms the number.
        /// </summary>
        /// <param name="maxValue">One more than the greatest legal return value</param>
        /// <returns>An int [0..maxValue)</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">maxValue;ArgumentOutOfRange MustBePositive</exception>
        public static int Next(int maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxValue), Localization.ArgumentOutOfRange_MustBePositive);
            }
            return Next(0, maxValue);
        }

        /// <summary>
        /// Randoms the number.
        /// </summary>
        /// <returns>A double [0..1)</returns>
        public static double Next()
        {
            var guid = Guid.NewGuid().GetHashCode();
            var floatingGuid = Math.Abs((double)guid / (int.MaxValue));
            return floatingGuid;
        }

        public static int[] GetUniqueInts(int count, int minValue, int maxValue)
        {
            if(count >= maxValue-minValue) throw new ArgumentOutOfRangeException(nameof(count), "The count of array index must be less than max - min values");

            var result = new HashSet<int>();
          
            var seq = Enumerable.Range(0, count).GetEnumerator();
            while (seq.MoveNext())
            {
                while (!result.Add(Next(minValue, maxValue))) {};
            }

            return result.ToArray();
        }
    }
}