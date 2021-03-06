namespace NetCoreExamples.NewFeatures.CS_6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
	using NetCoreExamples.RunnableInterfaces;

	public class StringInterpolation : IRunnableCS_6
    {
        public void Run()
        {
            string averageValue = InterpolationTests.Average(new[] { 5, 6, 100, 2, 4 });
            Console.WriteLine(averageValue);

            string multiPlyResult = InterpolationTests.Multiply(5, 2);
            Console.WriteLine(multiPlyResult);

            string formatTextExample = InterpolationTests.FormatExample();
            Console.WriteLine(formatTextExample);
        }
    }
    public class InterpolationTests
    {
        public static string Average(IEnumerable<int> numbers)
        {
            return $"Average value of {numbers?.Count()} is {numbers.Average()}";
        }

        public static string Multiply(int number, int multiplyBy)
        {
            Func<int, int> multiplier = (num) => num * multiplyBy;

            return $"{number} multiplied by {multiplyBy} is {multiplier(number)}";
        }

        public static string FormatExample()
		{
            DateTime currentDate = DateTime.Now;
            Decimal somethingDecimal = 13.47212m;

            return $"Date formatted: {currentDate:F} or {currentDate:d} Decimal formatted: {somethingDecimal:N1} or {somethingDecimal:N3}";
		}
    }
}
