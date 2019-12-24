using System;

namespace ScientificMath
{
    public static class Extensions
    {
        public static string Reverse(this string entry)
        {
            if (string.IsNullOrWhiteSpace(entry))
                return entry;
            string reversed = string.Empty;
            for (int i = entry.Length - 1; i >= 0; i--)
            {
                reversed += entry[i];
            }
            return reversed;
        }

        public static bool IsDigit(this string first)
        {
            if (string.IsNullOrWhiteSpace(first))
                return false;
            foreach (var item in first)
            {
                if (!Char.IsDigit(item))
                    return false;
            }
            return true;
        }

        public static int FirstNonZeroInRightHandIndex(this string entry)
        {
            if (!entry.IsDigit())
                throw new ArgumentException();
            for (int i = entry.Length - 1; i >= 0; i--)
            {
                if (entry[i] != '0')
                    return i;
            }
            return 0;
        }

        public static char ToChar(this int entry)
        {
            return char.Parse(entry.ToString());
        }

        public static int ToInt(this char entry)
        {
            return int.Parse(entry.ToString());
        }

        public static string Factorial(this long entry)
        {
            return (new Factorial()).GetFactorial(entry);
        }

        public static string Multiply(this string entry, string otherNumber )
        {
            return (new StringMultiplier(entry, otherNumber)).Multiply();
        }
    }
}
