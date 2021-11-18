namespace NetCoreExamples
{
	using System;
	using System.Linq;
	using NetCoreExamples.RunnableInterfaces;

	internal class Program
	{
		private static void Main(string[] args)
		{
			ExecuteRunnables(typeof(IRunnable));
			Console.ReadKey();
		}

		private static void ExecuteRunnables(Type typeInterfaceToRun)
		{
			var instances = typeof(Program).Assembly.ExportedTypes
				.Where(x => typeInterfaceToRun.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
				.Select(Activator.CreateInstance)
				.ToList();

			instances.ForEach(instance =>
			{
				Console.BackgroundColor = ConsoleColor.DarkBlue;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine($"Demostration of: <------------{instance.GetType()}--------------->");
				Console.ResetColor();
				var specificClass = (IRunnable)instance;
				specificClass.Run();
				Console.WriteLine();
			});
		}
	}
}
