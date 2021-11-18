namespace NetCoreExamples.BestPractices.SOLID.OpenClosed.FirstExample
{
	using System;
	using NetCoreExamples.RunnableInterfaces;
	using BadStore = Symptom.Store;
	using GoodStore = Refactor.Store;

	public class OpenClosed : IRunnableSolid
	{
		public void Run()
		{
			Console.BackgroundColor = ConsoleColor.DarkRed;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Bad example");
			Console.ResetColor();
			Implementation(new BadStore());

			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Good example");
			Console.ResetColor();
			Implementation(new GoodStore());
		}

		private void Implementation(IStore store)
		{
			var orderOne = new Order
			{
				Country = CountryEnum.Mexico,
				Total = 8000,
				Weight = 1
			};

			var orderTwo = new Order
			{
				Country = CountryEnum.Colombia,
				Total = 100000,
				Weight = 10
			};

			var costOne = store.CalculateDeliveryCost(orderOne);
			Console.WriteLine($"Order One cost: {costOne} pesos mexicanos");

			var costTwo = store.CalculateDeliveryCost(orderTwo);
			Console.WriteLine($"Order Two cost: {costTwo} pesos colombianos");
		}
	}
}
