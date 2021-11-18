namespace NetCoreExamples.Extensions
{
	using System;
	using System.Threading.Tasks;

	public static class TaskExtensions
	{
		public static async Task<T> ForceAsync<T>(Func<Task<T>> func)
		{
			await Task.Yield();
			return await func();
		}

		public static async Task ForceAsync(Func<Task> func)
		{
			await Task.Yield();
			await func();
		}

		public static void ForceAsync(this Task task)
		{
			if (task == null) throw new ArgumentNullException(nameof(task));
			try
			{
				task.GetAwaiter().GetResult();
			}
			catch (AggregateException es)
			{
				if (es.InnerExceptions.Count == 1)
				{
					var e = es.InnerExceptions[0];
				}
				throw;
			}
		}
	}
}
