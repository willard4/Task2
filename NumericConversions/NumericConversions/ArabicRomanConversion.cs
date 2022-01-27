using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumericConversions
{
    /// <summary>
    /// This static class contains an extension method for type (int) arabic to roman numbers conversion.
    /// </summary>
    public static class ArabicRomanConversion
    {
        /// <summary>
        /// This property Contains pairs for maping.
        /// </summary>
        private static readonly Dictionary<string, int> ArabicRomanPairs;

        static ArabicRomanConversion()
        {
            ArabicRomanPairs = new Dictionary<string, int>
            {
                {"M", 1000},
                {"CM", 900},
                {"D", 500},
                {"CD", 400},
                {"C", 100},
                {"XC", 90},
                {"L", 50},
                {"XL", 40},
                {"X", 10},
                {"IX", 9},
                {"V", 5},
                {"IV", 4},
                {"I", 1}
            };
        }

        /// <summary>
        /// This method converts integer value to (string) arabic value.
        /// </summary>
        public static string ToRoman(this int number)
        {
            if (number <= 0 || number > 3999)
                throw new ArgumentOutOfRangeException();

            var result = new StringBuilder();

            foreach (var pair in ArabicRomanPairs)
            {
                if (number / pair.Value == 0)
                    continue;

                result.Append(string.Join(string.Empty, Enumerable.Repeat(pair.Key, number / pair.Value)));
                number %= pair.Value;
            }

            return result.ToString();
        }
    }
}
