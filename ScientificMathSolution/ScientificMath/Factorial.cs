using System;

namespace ScientificMath
{
    public class Factorial
    {
        public string GetFactorial(long entry)
        {
            if (entry < 0)
                throw new ArgumentException();
            string result = "1";
            for (long l = 2; l <= entry; l++)
            {
                result = result.Multiply(l.ToString());
            }
            return result;
        }
    }
}
