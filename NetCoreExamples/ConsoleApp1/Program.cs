namespace NetCoreExamples
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using NetCoreExamples.RunnableInterfaces;

	internal class Program
	{
		private static void Main(string[] args)
		{
			ExecuteRunnables();
			Console.ReadKey();
		}

		private static void ExecuteRunnables()
		{
			typeof(Program).Assembly.ExportedTypes
				.Where(x => typeof(IRunnableExamples).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
				.Select(Activator.CreateInstance)
				.Cast<IRunnableExamples>()
				.ToList()
				.ForEach(initializer => initializer.Run());
		}
	}
}
