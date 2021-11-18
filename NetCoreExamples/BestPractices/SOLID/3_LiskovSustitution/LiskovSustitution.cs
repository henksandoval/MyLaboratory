namespace NetCoreExamples.BestPractices.SOLID.LiskovSustitution
{
	using System;
	using NetCoreExamples.RunnableInterfaces;
	using BaseSubscriberBad = Symptom.BaseSubscriber;
	using PremiumSubscriberBad = Symptom.PremiumSubscriber;
	using PremiumSubscriberGood = Refactor.PremiumSubscriber;
	using StandardSubscriberBad = Symptom.StandardSubscriber;
	using StandardSubscriberGood = Refactor.StandardSubscriber;

	public class LiskovSustitution : IRunnableSolid
	{
		public void Run()
		{
			Console.BackgroundColor = ConsoleColor.DarkRed;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Bad example");
			Console.ResetColor();
			ExampleWithBadAbstraction();

			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Good abstraction");
			Console.ResetColor();
			ExampleWithGoodAbstraction();
		}

		public void ExampleWithBadAbstraction()
		{
			try
			{
				var baseSubscriber = new BaseSubscriberBad();
				var premiumSubscriber = new PremiumSubscriberBad();
				var standardSubscriber = new StandardSubscriberBad();

				baseSubscriber.AccessToLimitedTitles();
				baseSubscriber.AccessToUnlimitedTitles();
				baseSubscriber.GiveAccessToFamilyMembers();

				premiumSubscriber.AccessToLimitedTitles();
				premiumSubscriber.GiveAccessToFamilyMembers();
				premiumSubscriber.AccessToUnlimitedTitles();

				standardSubscriber.AccessToLimitedTitles();
				standardSubscriber.AccessToUnlimitedTitles();
				standardSubscriber.GiveAccessToFamilyMembers();
			}
			catch (Exception e)
			{
				Console.WriteLine($"One or more errors occurred. {e.Message}");
			}
		}

		public void ExampleWithGoodAbstraction()
		{
			var premiumSubscriber = new PremiumSubscriberGood();
			var standardSubscriber = new StandardSubscriberGood();

			premiumSubscriber.AccessToLimitedTitles();
			premiumSubscriber.GiveAccessToFamilyMembers();
			premiumSubscriber.AccessToUnlimitedTitles();

			standardSubscriber.AccessToLimitedTitles();
		}
	}
}
