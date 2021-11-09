namespace NetCoreExamples
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;

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
				.Where(x => typeof(IRunnable).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
				.Select(Activator.CreateInstance)
				.Cast<IRunnable>()
				.ToList()
				.ForEach(initializer => initializer.Run());
		}

#pragma warning disable IDE0051 // Remove unused private members
		private static void ExecuteRunnablesOld()
#pragma warning restore IDE0051 // Remove unused private members
		{
			IEnumerable<Type> runnables = (
				from type in typeof(Program).GetTypeInfo().Assembly.GetTypes()
				let typeInfo = type.GetTypeInfo()
				where typeInfo.IsClass && typeof(IRunnable).IsAssignableFrom(type)
				select type)
				.ToList()
				.OrderBy(x => x.Namespace.PadRight(1));

			foreach (Type type in runnables)
			{
				IRunnable runnable = (IRunnable)Activator.CreateInstance(type);
				Console.WriteLine($"--------Example: {type.Name} ----------");
				runnable.Run();
			}
		}
	}
}
