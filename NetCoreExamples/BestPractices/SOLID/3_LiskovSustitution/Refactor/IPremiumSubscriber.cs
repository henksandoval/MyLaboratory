namespace NetCoreExamples.BestPractices.SOLID.LiskovSustitution.Refactor
{
	public interface IPremiumSubscriber
	{
		public void AccessToUnlimitedTitles();

		public void GiveAccessToFamilyMembers();
	}
}
