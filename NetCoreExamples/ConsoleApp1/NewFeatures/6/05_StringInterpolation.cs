namespace NetCoreExamples.NewFeatures._6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringInterpolation : IRunnable
    {
        public void Run()
        {
            string averageValue = InterpolationTests.Average(new[] { 5, 6, 100, 2, 4 });
            Console.WriteLine(averageValue);

            string multiPlyResult = InterpolationTests.Multiply(5, 2);
            Console.WriteLine(multiPlyResult);
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
    }
}
