using System;
using System.Text;

namespace ScientificMath
{
    public class StringMultiplier
    {
        public string ReversedFirst { get; private set; }
        public string ReversedSecond { get; private set; }

        public StringMultiplier(string first, string second)
        {
            if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(second))
                throw new ArgumentException();
            if (!first.IsDigit() || !second.IsDigit())
                throw new ArgumentException();
            ReversedFirst = first.Reverse();
            ReversedSecond = second.Reverse();
        }

        public string Multiply()
        {
            StringBuilder result = InitializeResult();
            result = DoMultiply(result);
            return PrepareResult(result);
        }

        private StringBuilder InitializeResult()
        {
            StringBuilder result =
                new StringBuilder(ReversedFirst.Length + ReversedSecond.Length + 1);
            for (int i = 0; i < result.Capacity; i++)
            {
                result.Append('0');
            }
            return result;
        }

        private StringBuilder DoMultiply(StringBuilder result)
        {
            for (int i = 0; i < ReversedFirst.Length; i++)
            {
                result = MultiplyOneRow(result, i);
            }
            return result;
        }

        private StringBuilder MultiplyOneRow(StringBuilder result, int i)
        {
            int index = i;
            for (int j = 0; j < ReversedSecond.Length; j++)
            {
                var multi = result[index].ToInt() +
                    ReversedFirst[i].ToInt() * ReversedSecond[j].ToInt();
                result[index] = (multi % 10).ToChar();
                AddCarry(result, index + 1, multi / 10);
                index++;
            }
            return result;
        }

        private StringBuilder AddCarry(StringBuilder result, int index, int carry)
        {
            while (carry > 0)
            {
                var add = result[index].ToInt() + carry;
                result[index] = (add % 10).ToChar();
                carry = add / 10;
                index++;
            }
            return result;
        }
        
        private string PrepareResult(StringBuilder result)
        {
            return result.ToString().Substring(0, result.ToString().FirstNonZeroInRightHandIndex() + 1).Reverse();
        }
    }
}
