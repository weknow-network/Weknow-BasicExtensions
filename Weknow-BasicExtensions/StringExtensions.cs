using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtensions
    {
        private static readonly Regex IGNORED = new Regex("[^a-zA-Z0-9]");

        #region ToCamelCase

        /// <summary>
        /// Converts to camelCase.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string ToCamelCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;


            string[] parts = IGNORED.Split(text);
            if (parts.Length == 1)
            {
                return ToCamelSimple(text);
            }

            string result = string.Join("", parts.Select((m, i) => i == 0 ? ToCamelSimple(m) : ToPascalSimple(m)));
            return result;

            string ToCamelSimple(string candidate)
            {
                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                if (Char.IsLower(candidate[0]))
                    return candidate;
                return $"{Char.ToLower(candidate[0])}{candidate[1..]}";
            }

            string ToPascalSimple(string candidate)
            {
                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                if (Char.IsUpper(candidate[0]))
                    return candidate;
                return $"{Char.ToUpper(candidate[0])}{candidate[1..]}";
            }
        }

        #endregion // ToCamelCase

        #region ToPascalCase

        /// <summary>
        /// Converts to PascalCase.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string ToPascalCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;


            string[] parts = IGNORED.Split(text);
            if (parts.Length == 1)
            {
                return ToPascalSimple(text);
            }

            return string.Join("", parts.Select(m => ToPascalSimple(m)));

            string ToPascalSimple(string candidate)
            {
                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                if (Char.IsUpper(candidate[0]))
                    return candidate;
                return $"{Char.ToUpper(candidate[0])}{candidate[1..]}";
            }

        }

        #endregion // ToPascalCase

        #region ToSCREAMING

        /// <summary>
        /// Converts to SCREAMING_CASE.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string ToSCREAMING(this string text, char separator = '_')
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            (string Result, char Last) aggregate = text.Trim().Aggregate(
               (Result: "", Last: char.MinValue),
               (acc, current) =>
               {
                   char CURRENT = char.ToUpper(current);
                   var (result, last) = acc;
                   bool isCurWS = char.IsWhiteSpace(current);
                   if (isCurWS && result.Length != 0)
                   {
                       if (char.IsLetter(last) || char.IsDigit(last))
                           return ($"{result}{separator}", separator);
                       else
                           return (result, last);
                   }
                   if (result.Length == 0)
                   {
                       if (isCurWS)
                           return (result, char.MinValue);
                       else
                           return ($"{result}{CURRENT}", current);
                   }

                   if (current == separator || last == separator)
                   {
                       if (current == last)
                           return (result, current);
                       return ($"{result}{CURRENT}", current);
                   }
                   if ((char.IsLower(last) || !char.IsLetter(last)) && char.IsUpper(current))
                       return ($"{result}{separator}{CURRENT}", current);
                   return ($"{result}{CURRENT}", current);
               });

            //(string Result, char Last) aggregate = text.Aggregate(
            //    (Result: "", Last: char.MinValue),
            //    (acc, current) => (result: acc.Result, last: acc.Last, current) switch {
            //        ("", _, _) => (current.ToString().ToUpper(), current),
            //        var (r, l, c) when char.IsLower(l) && char.IsUpper(c) => ($"{r}{separator}{c}".ToUpper(), current),
            //        var (r, _, c) => ($"{r}{current}".ToUpper(), c)
            //    });

            return aggregate.Result;
        }

        #endregion // ToSCREAMING

        #region ToDash

        /// <summary>
        /// Converts to dash-separated (ignore anything which is not letter or digit).
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string ToDash(this string text, char separator = '-')
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            (string Result, char Last) aggregate = text.Trim().Aggregate(
               (Result: "", Last: char.MinValue),
               (acc, current) =>
               {
                   char CURRENT = char.ToLower(current);
                   var (result, last) = acc;
                   bool ignore = !char.IsDigit(current) && !char.IsLetter(current) || current == '_';
                   if (ignore && result.Length != 0)
                   {
                       return (result, separator);
                   }
                   if (result.Length == 0)
                   {
                       if (ignore)
                           return (result, char.MinValue);
                       else
                           return ($"{result}{CURRENT}", current);
                   }

                   if (current == separator || last == separator)
                   {
                       if (current == last)
                           return (result, current);
                       else if (last == separator)
                           return ($"{result}{separator}{CURRENT}", current);
                   }
                   if (char.IsUpper(current) && !char.IsUpper(last))
                       return ($"{result}{separator}{CURRENT}", current);
                   return ($"{result}{CURRENT}", current);
               });


            return aggregate.Result;
        }

        #endregion // ToDash
    }
}
