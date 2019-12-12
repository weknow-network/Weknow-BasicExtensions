using System;
using System.Linq;

namespace System
{
    public static class StringExtensions
    {
        #region ToCamelCase

        /// <summary>
        /// Converts to camelCase.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="seperator">The seperator.</param>
        /// <returns></returns>
        public static string ToCamelCase(this string text)
        {
            // TODO: use slice to minimize allocation

            if (string.IsNullOrEmpty(text))
                return string.Empty;


            return $"{Char.ToLower(text[0])}{text[1..]}";
        }

        #endregion // ToCamelCase

        #region ToPascalCase

        /// <summary>
        /// Converts to PascalCase.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="seperator">The seperator.</param>
        /// <returns></returns>
        public static string ToPascalCase(this string text)
        {
            // TODO: use slice to minimize allocation

            if (string.IsNullOrEmpty(text))
                return string.Empty;


            return $"{Char.ToUpper(text[0])}{text[1..]}";
        }

        #endregion // ToPascalCase

        #region ToSCREAMING

        /// <summary>
        /// Converts to SCREAMING_CASE.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="seperator">The seperator.</param>
        /// <returns></returns>
        public static string ToSCREAMING(this string text, char seperator = '_')
        {
            // TODO: use slice to minimize allocation

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
                           return ($"{result}{seperator}", seperator);
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

                   if (current == seperator || last == seperator)
                   {
                       if (current == last)
                           return (result, current);
                       return ($"{result}{CURRENT}", current);
                   }
                   if ((char.IsLower(last) || !char.IsLetter(last)) && char.IsUpper(current))
                       return ($"{result}{seperator}{CURRENT}", current);
                   return ($"{result}{CURRENT}", current);
               });

            //(string Result, char Last) aggregate = text.Aggregate(
            //    (Result: "", Last: char.MinValue),
            //    (acc, current) => (result: acc.Result, last: acc.Last, current) switch {
            //        ("", _, _) => (current.ToString().ToUpper(), current),
            //        var (r, l, c) when char.IsLower(l) && char.IsUpper(c) => ($"{r}{seperator}{c}".ToUpper(), current),
            //        var (r, _, c) => ($"{r}{current}".ToUpper(), c)
            //    });

            return aggregate.Result;
        } 

        #endregion // ToSCREAMING
    }
}
