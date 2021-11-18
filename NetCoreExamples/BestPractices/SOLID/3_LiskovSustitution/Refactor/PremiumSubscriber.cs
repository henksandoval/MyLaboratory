namespace NetCoreExamples.BestPractices.SOLID.LiskovSustitution.Refactor
{
	using System;

	public class PremiumSubscriber : BaseSubscriber, IUserSubscriber, IStandardSubscriber, IPremiumSubscriber
	{

		public void GiveAccessToFamilyMembers() => Console.WriteLine("Access granted to family members");

		public void AccessToLimitedTitles() => Console.WriteLine("Access to limited titles");

		public void AccessToUnlimitedTitles() => Console.WriteLine("Access to unlimited titles");
	}
}
