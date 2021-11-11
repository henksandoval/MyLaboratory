namespace NetCoreExamples.BestPractices.SOLID.OpenClosed.FirstExample
{
	internal interface IStore
	{
		double CalculateDeliveryCost(Order order);
	}
}