namespace NetCoreExamples.NewFeatures.CS_8
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using NetCoreExamples.RunnableInterfaces;

	public class AsyncStreams : IRunnableCS_8
	{
		private static int ThreadId => Environment.CurrentManagedThreadId;

		public void Run()
		{
			Console.WriteLine("<---- Running Blocking Process ---->");
			RunningBlockingThread();

			Console.WriteLine("<---- Running Unblocking Process ---->");
			var task = Task.Run(() => RunningUnblockingThread());
			task.Wait();
		}

		private async Task RunningUnblockingThread()
		{
			var orderFactory = new OrderFactory();
			Console.WriteLine($"[{ThreadId}] Enumerating orders...");

			await foreach (var order in orderFactory.MakeOrdersAsync(5))
				Console.WriteLine(order.GetMessage(ThreadId));

			Console.WriteLine($"[{ThreadId}] All orders created!");
		}

		private void RunningBlockingThread()
		{
			var orderFactory = new OrderFactory();
			Console.WriteLine($"[{ThreadId}] Enumerating orders...");

			foreach (var order in orderFactory.MakeOrders(5))
				Console.WriteLine(order.GetMessage(ThreadId));

			Console.WriteLine($"[{ThreadId}] All orders created!");
		}
	}

	internal class Order
	{
		public int Id { get; set; }

		public int DelayTime { get; set; }

		public string GetMessage(int threadId) => $"[{threadId}] Received order Id:{Id} Delay:{DelayTime}";
	}

	internal class OrderFactory
	{
		public IEnumerable<Order> MakeOrders(int count)
		{
			for (var i = 0; i < count; i++)
			{
				var delay = GetRandomDelay();
				Task.Delay(delay).Wait();
				yield return new Order { Id = i + 1, DelayTime = delay };
			}
		}

		public async IAsyncEnumerable<Order> MakeOrdersAsync(int count)
		{
			for (var i = 0; i < count; i++)
			{
				var delay = GetRandomDelay();
				await Task.Delay(delay);
				yield return new Order { Id = i + 1, DelayTime = delay };
			}
		}

		private int GetRandomDelay()
		{
			var rnd = new Random();
			var delay = rnd.Next(1000, 3000);
			return delay;
		}
	}
}
