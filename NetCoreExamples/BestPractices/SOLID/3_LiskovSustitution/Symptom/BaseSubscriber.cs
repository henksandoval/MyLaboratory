namespace NetCoreExamples.BestPractices.SOLID.LiskovSustitution.Symptom
{
	using System;

	public class BaseSubscriber
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public virtual void GiveAccessToFamilyMembers() => Console.WriteLine("Access granted to family members");

		public virtual void AccessToLimitedTitles() => Console.WriteLine("Access to limited titles");

		public virtual void AccessToUnlimitedTitles() => Console.WriteLine("Access to unlimited titles");
	}
}
