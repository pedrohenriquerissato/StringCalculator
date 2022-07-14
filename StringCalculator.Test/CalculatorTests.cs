using FluentAssertions;

namespace StringCalculator.Test
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void Add_StringNullOrEmpty_ShouldReturnZero(string numbers)
        {
            //Arrange

            //Act
            var result = Calculator.Add(numbers);

            //Assert
            result.Should().Be(0);
        }

        [Fact]
        public void Add_StringHasNoNumbers_ShouldReturnZero()
        {
            //Arrange
            var numbers = "//***,@\n";

            //Act
            var result = Calculator.Add(numbers);

            //Assert
            result.Should().Be(0);
        }

        [Theory]
        [InlineData("//****,@\n1***40@70@1000@-1@1001***7")]
        [InlineData("//****,@\n1***40@70@1000@-1@1001@-15***7@-4000")]
        [InlineData("//****,@\n1***40@70@1000@-1@1001@-15\n***7@-4000\n")]
        [InlineData("//****,@\n1***40@70@1000@--1@1001@--15\n***7@--4000\n")]
        public void Add_NegativaNumbers_ShouldThrowArgumentException(string numbers)
        {
            //Arrange

            //Act
            Action result = () => Calculator.Add(numbers);

            //Assert
            result.Should().Throw<ArgumentException>()
                .WithMessage($"Negatives numbers are not allowed: {-1}.");
        }

        [Theory]
        [InlineData("//***\n1***2***3", 6)]
        [InlineData("//$,@\n1$2@3", 6)]
        [InlineData("//$,@\n1$2@1001", 3)]
        [InlineData("//@\n2@3@8", 13)]
        [InlineData("//$\n1$2$3", 6)]
        [InlineData("//;\n1;3;4", 8)]
        [InlineData("1,\n2,4", 7)]
        [InlineData("1\n,2,3", 6)]
        public void Add_GoodNumbers_ShouldReturnCorrectSums(string numbers, int sum)
        {
            //Arrange

            //Act
            var result = Calculator.Add(numbers);

            //Assert
            result.Should().Be(sum);
        }

        [Theory]
        [InlineData("After twenty, numbers such as twenty-five (25), fifty (50), seventy-five (75), and one hundred (100) follow. So long as one knows the core number, or the number situated in the tens or hundreds position that determines the general amount, understanding these more complicated numbers won't be difficult. For example thirty-three (33) is simply thirty plus three; sixty-seven is sixty plus seven; and sixty-nine is simply sixty plus nine.", 283)]
        [InlineData("After ten, eleven (11), twelve (12), thirteen (13), fourteen (14), fifteen (15), sixteen (16), seventeen (17), eighteen (18), nineteen (19), and twenty (20) follow. These numbers are seen less in grocery stores, as most prices are 10 dollars or less; it is however worth knowing these numbers, generally and, in terms of grocery shopping, for when the bill must be paid.", 165)]
        public void Add_EdgeCases_ShouldReturnCorrectSum(string numbers, int sum)
        {
            //Arrange

            //Act
            var result = Calculator.Add(numbers);

            //Assert
            result.Should().Be(sum);
        }

    }
}