using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class Calculator
    {
        /// <summary>
        /// Sum any positive given numbers within a string
        /// </summary>
        /// <param name="numbers">Any text with numbers</param>
        /// <returns>An <see cref="int"/> as sum</returns>
        /// <exception cref="ArgumentException"></exception>
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers))
                return 0;

            var regexPattern = new Regex(@"(\-)\d+|\d+");

            return regexPattern.Matches(numbers)
                .Select(x => Convert.ToInt32(x.Value))
                .Sum(x =>
                {
                    if (x < 0)
                        throw new ArgumentException($"Negatives numbers are not allowed: {x}.");
                    else if (x > 1000)
                        return 0;

                    return x;
                });
        }
    }
}
