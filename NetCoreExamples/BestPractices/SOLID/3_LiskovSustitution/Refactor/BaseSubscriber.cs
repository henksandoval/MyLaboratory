namespace NetCoreExamples.BestPractices.SOLID.LiskovSustitution.Refactor
{
	public class BaseSubscriber : IUserSubscriber
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
