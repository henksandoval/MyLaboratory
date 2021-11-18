namespace NetCoreExamples.Threading
{
	using System;
	using System.Threading;
	using NetCoreExamples.RunnableInterfaces;

	public class MultiThread
	{
		private static int count = 0;
		private static bool execute = true;

		public void Run()
		{
			var thread01 = new Thread(Increase);
			var thread02 = new Thread(Increase);

			thread01.Start();
			thread02.Start();

			while (execute)
				if (count > 20) execute = false;

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Finish run on Multithread");
			Console.ForegroundColor = ConsoleColor.Green;
		}

		private static void Increase()
		{
			while (execute)
			{
				count++;
				Console.WriteLine("-------");
				Console.WriteLine("Thread id --> {0}", Environment.CurrentManagedThreadId);
				Console.WriteLine("Count --> {0}", count);

				Thread.Sleep(300);
			}
		}
	}
}
