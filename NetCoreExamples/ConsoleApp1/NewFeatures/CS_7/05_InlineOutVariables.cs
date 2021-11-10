namespace NetCoreExamples.NewFeatures.CS_7
{
    using System;
    using System.Collections.Generic;
	using NetCoreExamples.RunnableInterfaces;

	public class InlineOutVariables : IRunnableCS_7
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
