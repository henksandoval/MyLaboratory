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
			var runnables = typeof(Program).Assembly.ExportedTypes
				.Where(x => typeof(IRunnableCS_8).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
				.Select(Activator.CreateInstance)
				.Cast<IRunnableCS_8>()
				.ToList();

			runnables.ForEach(initializer =>
			{
				Console.BackgroundColor = ConsoleColor.DarkBlue;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine($"Demostration of: <------------{initializer.GetType()}--------------->");
				Console.ResetColor();
				initializer.Run();
				Console.WriteLine();
			});
		}
	}
}
