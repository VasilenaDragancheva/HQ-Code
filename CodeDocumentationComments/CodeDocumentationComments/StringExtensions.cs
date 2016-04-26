namespace CodeDocumentationComments
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    ///  Static class containing static methods that extend functionality of string type objects
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// capitalizes first letter and the keep the rest as given.
        /// </summary>
        /// <param name="input">Current instance of string</param>
        /// <returns>String with first capitalized letter and other remains same</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Converts latin letters to cyrillic on phonetics principle
        /// </summary>
        /// <param name="input">Current instance of string</param>
        /// <returns>String of latin letters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", 
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k", 
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h", 
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(
                    bulgarianLetters[i].ToUpper(),
                    latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts cyrillic to latin on phonetics principle
        /// </summary>
        /// <param name="input">Current instance of string</param>
        /// <returns>String of cyrillic letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", 
                                       "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к", 
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж", 
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (var i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        ///  Extracts file extension from  given file name.
        /// </summary>
        /// <param name="fileName">full name of file</param>
        /// <returns>String representing file extension</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            var fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Gets first of wanted count of chars
        /// </summary>
        /// <param name="input">Current instance of string</param>
        /// <param name="charsCount">count of chars to be returned</param>
        /// <returns>String with length equal to wanted count or input string</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns substring after startFrom index and between startString and endString, or empty string.
        /// </summary>
        /// <param name="input">Current instance of string</param>
        /// <param name="startString">string before </param>
        /// <param name="endString">string after</param>
        /// <param name="startFrom">Index to start looking for startString</param>
        /// <returns>String, between startString and endString </returns>
        public static string GetStringBetween(
            this string input,
            string startString,
            string endString,
            int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!(input.Contains(startString) && input.Contains(endString)))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Compares if string is with certain meaning of true or false;
        /// </summary>
        /// <param name="input">Current instance of string </param>
        /// <returns>Boolean whether string means true or false</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Copies bytes from input string as char array;
        /// </summary>
        /// <param name="input">Current instance of string</param>
        /// <returns>Byte array</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }

        /// <summary>
        /// Returns type of file depending on file extension
        /// </summary>
        /// <param name="fileExtension">file Extension</param>
        /// <returns>String representing name of content type</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" }, 
                                                     { "jpeg", "image/jpeg" }, 
                                                     { "png", "image/x-png" }, 
                                                     {
                                                         "docx", 
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     }, 
                                                     { "doc", "application/msword" }, 
                                                     { "pdf", "application/pdf" }, 
                                                     { "txt", "text/plain" }, 
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Tries to parse date from string.
        /// If parsing fails returns default value of DateTime struct
        /// </summary>
        /// <param name="input">Current instance of string </param>
        /// <returns> Return DateTime default or parsed value </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Tries to parse signed 32 bit integers from string.
        /// If parsing fails returns default value of zero
        /// </summary>
        /// <param name="input">Current instance of string </param>
        /// <returns>Returns parsed integer or default value of 0</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        ///     Tries to parse signed 64 bit integers from string.
        ///     If parsing fails returns default value of zero
        /// </summary>
        /// <param name="input">Current instance of string </param>
        /// <returns>Returns parsed long or default value </returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        ///  Does hashing through MD5 on given string
        /// </summary>
        /// <param name="input">Current Instance of string </param>
        /// <returns>Returns string ,hashed input</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            for (var i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        ///     Try to parse signed 16 bit integers from string.
        ///     If parsing fails returns default value of zero
        /// </summary>
        /// <param name="input">Current instance of string </param>
        /// <returns> Returns parsed short integer or default 0</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        ///  Converts cyrillic lettered string in valid latin name of file
        /// </summary>
        /// <param name="input">Current instance of string</param>
        /// <returns>string, cleaned off of chars different from letters, digits, dot and dash </returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Converts given string from cyrillic to latin letters, and removes every character which is not letter digit or dot.
        /// </summary>
        /// <param name="input">Current instance of string</param>
        /// <returns>Returns string,cleaned off of chars different from letters, digits, dot and das </returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }
    }
}