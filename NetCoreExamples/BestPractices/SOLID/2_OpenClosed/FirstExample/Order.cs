namespace NetCoreExamples.BestPractices.SOLID.OpenClosed.FirstExample
{
	internal class Order
	{
		public CountryEnum Country { get; set; }

		public double Weight { get; set; }

		public double Total { get; set; }
	}
}
