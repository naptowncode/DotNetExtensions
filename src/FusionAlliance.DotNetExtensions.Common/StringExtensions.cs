﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FusionAlliance.DotNetExtensions.Common
{
    /// <summary>
    ///     Extension methods for the <see cref="string" /> type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Base64 decode a string.
        /// </summary>
        /// <param name="stringToDecode">String to decode.</param>
        /// <returns>Decoded string.</returns>
        public static string Base64Decode(this string stringToDecode)
        {
            if (stringToDecode == null)
            {
                throw new ArgumentNullException("stringToDecode");
            }

            var stringAsBytes = Convert.FromBase64String(stringToDecode);
            return Encoding.UTF8.GetString(stringAsBytes);
        }

        public static string Base64Encode(this string stringToEncode)
        {
            if (stringToEncode == null)
            {
                throw new ArgumentNullException("stringToEncode");
            }

            var stringAsBytes = Encoding.UTF8.GetBytes(stringToEncode);
            return Convert.ToBase64String(stringAsBytes);
        }

        /// <summary>
        ///     Converts the string to a nullable integer.
        /// </summary>
        /// <param name="stringToConvert">String representation of an int. Internal use only.</param>
        /// <param name="defaultValue">The default value to return in case <paramref name="stringToConvert" /> is null or empty.</param>
        /// <returns>
        ///     The string converted to a nullable integer, or <paramref name="defaultValue" /> in cases where
        ///     <paramref name="stringToConvert" /> is null or empty.
        /// </returns>
        public static int? ToInt(this string stringToConvert, int? defaultValue = null)
        {
            if (string.IsNullOrEmpty(stringToConvert))
            {
                if (defaultValue.HasValue)
                {
                    return defaultValue.Value;
                }
                return null;
            }

            return Convert.ToInt32(stringToConvert);
        }

        /// <summary>
        ///     Gets the string formatted as a phone number with parenthesis.
        /// </summary>
        /// <example>"1234567890".ToPhoneNumberWithParens() will return "(123) 456-7890"</example>
        public static string ToPhoneNumberWithParens(this string phoneString)
        {
            if (string.IsNullOrEmpty(phoneString))
            {
                return phoneString;
            }

            return phoneString.Length == 10
                ? Regex.Replace(phoneString, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3")
                : phoneString;
        }

        /// <summary>
        ///     Gets the string formatted as a phone number without parenthesis.
        /// </summary>
        /// <example>"1234567890".ToPhoneNumberWithParens() will return "123-456-7890"</example>
        public static string ToPhoneNumberNoParens(this string phoneString)
        {
            if (string.IsNullOrEmpty(phoneString))
            {
                return phoneString;
            }

            return phoneString.Length == 10
                ? Regex.Replace(phoneString, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3")
                : phoneString;
        }

        /// <summary>
        ///     Safely retrieves the substring, beginning at the specified index.
        /// </summary>
        /// <returns>
        ///     The substring, beginning at the specified index. If the index is out of bounds, the original substring is
        ///     returned.
        /// </returns>
        public static string SubstringSafe(this string value, int index)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= index)
            {
                return value;
            }

            return value.Substring(index);
        }

        /// <summary>
        ///     Converts the string from PascalCase to camelCase.
        /// </summary>
        public static string ConvertPascalCaseToCamelCase(this string stringToConvert)
        {
            var sb = new StringBuilder(stringToConvert);
            sb[0] = char.ToLower(sb[0]);
            return sb.ToString();
        }

        /// <summary>
        ///     Converts the string from camelCase to PascalCase.
        /// </summary>
        public static string ConvertCamelCaseToPascalCase(this string stringToConvert)
        {
            var sb = new StringBuilder(stringToConvert);
            sb[0] = char.ToUpper(sb[0]);
            return sb.ToString();
        }
    }
}