namespace NetCoreExamples.NewFeatures.CS_7
{
    using System;
    using System.Collections.Generic;

    public class InlineOutVariables : IRunnable
    {
        private readonly Dictionary<int, string> People = new Dictionary<int, string>
        {
            {1, "Pedro"},
            {2, "Esteban" }
        };

        public void Run()
        {
            People.TryGetValue(1, out var name);
            Console.WriteLine(name);

            if (int.TryParse("10", out int parsedInteger))
            {
                Console.WriteLine(parsedInteger);
            }
        }

    }
}
