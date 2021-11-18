namespace NetCoreExamples.BestPractices.SOLID.LiskovSustitution.Symptom
{
	public class PremiumSubscriber : BaseSubscriber
	{
		public override void AccessToLimitedTitles() => base.AccessToUnlimitedTitles();

		public override void AccessToUnlimitedTitles() => base.AccessToLimitedTitles();

		public override void GiveAccessToFamilyMembers() => base.GiveAccessToFamilyMembers();
	}
}
