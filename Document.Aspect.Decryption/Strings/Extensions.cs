using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Document.Aspect.Decryption.Strings
{
    public static class Extensions
    {
        public static bool IsBase64(this string valueToCheck)
        {
            valueToCheck = valueToCheck.Trim();
            return (valueToCheck.Length % 4 == 0) && Regex.IsMatch(valueToCheck, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

        }

        public static string FromByteArrayToString(this byte[] valueToConvert)
        {
            return System.Text.Encoding.Default.GetString(valueToConvert);
        }
    }
}
