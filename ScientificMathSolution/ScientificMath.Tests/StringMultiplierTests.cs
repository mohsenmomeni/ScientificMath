using FluentAssertions;
using System;
using Xunit;

namespace ScientificMath.Tests
{
    public class ScientificMathTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("  ", "  ")]
        [InlineData("12", "21")]
        [InlineData("2345121331", "1331215432")]
        public void String_Reverse_Should_Return_Reverse_Of_Entry(string entry, string expectedResult)
        {
            entry.Reverse().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("12", true)]
        [InlineData("23451213319786886979856785876856", true)]
        [InlineData("234512133197868869r79856785876856", false)]
        [InlineData("ahmad", false)]
        [InlineData("   ", false)]
        [InlineData(null, false)]
        public void String_IsDigit_Should_Return_IsDigit_Of_Entry(string entry, bool expectedResult)
        {
            entry.IsDigit().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("234512133197868869r79856785876856")]
        [InlineData("ahmad")]
        [InlineData("   ")]
        [InlineData(null)]
        public void String_FirstNonZeroInRightHandIndex_Should_ThrowException_When_Entry_Is_Not_Digit(string entry)
        {
            void Action()
            {
                entry.FirstNonZeroInRightHandIndex();
            }
            var exception = Assert.Throws<ArgumentException>((Action)Action);
        }

        [Theory]
        [InlineData("23451213319", 10)]
        [InlineData("23451213319000000", 10)]
        [InlineData("100000000000", 0)]
        [InlineData("000000000000", 0)]
        public void String_FirstNonZeroInRightHandIndex_Should_ReturnIndex_When_Entry_Is_Digit(string entry, int index)
        {
            entry.FirstNonZeroInRightHandIndex().Should().Be(index);
        }

        [Theory]
        [InlineData(2345121)]
        [InlineData(12)]
        public void Int_ToChar_Should_ThrowException_When_Entry_Is_MoreThan_One_Digit(int entry)
        {
            void Action()
            {
                entry.ToChar();
            }
            var exception = Assert.Throws<FormatException>((Action)Action);
        }

        [Theory]
        [InlineData(1,'1')]
        [InlineData(0,'0')]
        public void Int_ToChar_Should_Return_Its_CharEquivalent(int entry, char result)
        {
            entry.ToChar().Should().Be(result);
        }

        [Theory]
        [InlineData('a')]
        [InlineData('@')]
        public void Char_ToInt_Should_ThrowException_When_Char_Is_not_A_Digit(char entry)
        {
            void Action()
            {
                entry.ToInt();
            }
            var exception = Assert.Throws<FormatException>((Action)Action);
        }

        [Theory]
        [InlineData('1', 1)]
        [InlineData('0', 0)]
        public void Char_ToInt_Should_Return_Its_IntEquivalent(char entry, int result)
        {
            entry.ToInt().Should().Be(result);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("ahmad", "12")]
        [InlineData("12", "ahmad")]
        public void String_Multiply_Should_Throw_Exception_When_They_Are_Not_Digits(string firstNumber, string secondNumber)
        {
            void Action()
            {
                firstNumber.Multiply(secondNumber);
            }
            var exception = Assert.Throws<ArgumentException>((Action)Action);
        }

        [Theory]
        [InlineData("12", "12", "144")]
        [InlineData("99", "99", "9801")]
        [InlineData("895", "984", "880680")]
        [InlineData("89658", "75999", "6813918342")]
        public void String_Multiply_Should_Return_Multiply_When_They_Are_Digits(string firstNumber,
                        string secondNumber, string rexpectedResult)
        {
            firstNumber.Multiply(secondNumber).Should().Be(rexpectedResult);
        }

        [Theory]
        [InlineData(-15)]
        [InlineData(-1)]
        public void Long_Factoriel_Should_Throw_Exception_When_It_Is_Negative(long entry)
        {
            void Action()
            {
                entry.Factorial();
            }
            var exception = Assert.Throws<ArgumentException>((Action)Action);
        }

        [Theory]
        [InlineData(0, "1")]
        [InlineData(6, "720")]
        [InlineData(7, "5040")]
        [InlineData(15, "1307674368000")]
        public void Long_Factoriel_Should_Return_Its_Factorial(long entry, string expectedResult)
        {
            entry.Factorial().Should().Be(expectedResult);
        }
    }
}
