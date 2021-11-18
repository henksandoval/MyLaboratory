namespace NetCoreExamples.BestPractices.SOLID.LiskovSustitution.Symptom
{
	using System;

	public class StandardSubscriber : BaseSubscriber
	{
		public override void AccessToLimitedTitles() => base.AccessToLimitedTitles();

		public override void AccessToUnlimitedTitles() => throw new InvalidOperationException("Method not allowed for Standard account");

		public override void GiveAccessToFamilyMembers() => throw new InvalidOperationException("Method not allowed for Standard account");
	}
}
