namespace NetCoreExamples.BestPractices.SOLID.LiskovSustitution.Refactor
{
	public interface IUserSubscriber
	{
		string Email { get; set; }
		string FullName { get; set; }
		string Password { get; set; }
	}
}