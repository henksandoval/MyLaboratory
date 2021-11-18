namespace NetCoreExamples.BestPractices.SOLID.LiskovSustitution.Refactor
{
	using System;

	public class StandardSubscriber : BaseSubscriber, IUserSubscriber, IStandardSubscriber
	{
		public void AccessToLimitedTitles() => Console.WriteLine("Access to limited titles");
	}
}
