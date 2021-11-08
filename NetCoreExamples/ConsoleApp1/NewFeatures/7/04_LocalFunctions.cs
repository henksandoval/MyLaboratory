namespace NetCoreExamples.NewFeatures._7
{
    using System;
    using System.Linq;

    public class LocalFunctions : IRunnable
    {
        public void Run()
        {
            foreach (var number in Enumerable.Range(1, 5))
            {
                ShowFactorial(number);
            }
        }

        public void ShowFactorial(int number)
        {
            Console.WriteLine($"Factorial of {number} is {CalculateFactorial()}");

            int CalculateFactorial()
            {
                return Enumerable.Range(1, number).Aggregate((acc, x) => acc * x);
            }
        }
    }
}
