using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CoolNameGenerator.Helper
{
    /// <summary>Enumerable extensions.</summary>
    public static class EnumerableExtensions
    {
        /// <summary>Gets the types of the specified objects.</summary>
        /// <returns>The types.</returns>
        /// <param name="objects">The objects.</param>
        public static Type[] GetTypes(this IEnumerable objects)
        {
            List<Type> typeList = new List<Type>();
            if (objects != null)
            {
                foreach (object @object in objects)
                {
                    if (@object == null)
                        typeList.Add((Type)null);
                    else
                        typeList.Add(@object.GetType());
                }
            }
            return typeList.ToArray();
        }

        /// <summary>
        /// Iterates in the collection calling the action for each item.
        /// </summary>
        /// <param name="self">The enumerable it self.</param>
        /// <param name="action">The each action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Each<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (T obj in self)
                action(obj);
        }

        /// <summary>
        /// Iterates in the collection calling the action for each item using index.
        /// </summary>
        /// <param name="self">The enumerable it self.</param>
        /// <param name="action">The each action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Each<T>(this IEnumerable<T> self, Action<T, int> action)
        {
            List<T> list = self.ToList<T>();
            for (int index = 0; index < list.Count; ++index)
                action(list[index], index);
        }

        /// <summary>
        /// Iterates in the collection calling the action for each item and concatenating the result.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="self">The enumerable it self.</param>
        /// <param name="function">The ToString function.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static string ToString<T>(this IEnumerable<T> self, Func<T, object> function)
        {
            StringBuilder result = new StringBuilder();
            self.Each<T>((Action<T>)(i => result.Append(function(i))));
            return result.ToString();
        }

        /// <summary>
        /// Iterates in the collection calling the action for each item using String.Format.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="self">The enumerable it self.</param>
        /// <param name="format">The string format.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static string ToString<T>(this IEnumerable<T> self, string format)
        {
            return self.ToString<T>((Func<T, object>)(i => (object)string.Format((IFormatProvider)CultureInfo.InvariantCulture, format, new object[1] { (object)i })));
        }
    }
}
