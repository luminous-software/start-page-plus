using System;
using System.Collections.Generic;
using System.Linq;

namespace Luminous.Code.Extensions.Strings
{
    public static class StringExtensions
    {
        public static List<string> SplitIntoWords(this string instance)
        {
            //https://stackoverflow.com/questions/16725848/how-to-split-text-into-words

            //var text = "'Oh, you can't help that,' said the Cat: 'we're all mad here. I'm mad. You're mad.'";

            var punctuation = instance.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = instance.Split().Select(x => x.Trim(punctuation)).ToList();

            return words;
        }

        public static bool MatchesFilter(this string instance, string filter, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            var index = instance.IndexOf(filter, 0, comparison);

            return (index > -1);
        }

        public static string ToPlural(this string instance, int count)
        {
            if (string.IsNullOrEmpty(instance))
                return "";

            switch (count)
            {
                case 0:
                    return $"{instance}s";

                case 1:
                    return instance;

                default:
                    return $"{instance}s";
            }
        }

        public static string ToQuotedString(this string instance)
        {
            if (string.IsNullOrEmpty(instance))
                return "";

            return !instance.Contains(" ")
                ? instance
                : (char)34 + instance + (char)34;
        }
    }
}