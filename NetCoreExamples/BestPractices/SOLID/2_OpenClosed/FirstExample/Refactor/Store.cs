namespace NetCoreExamples.BestPractices.SOLID.OpenClosed.FirstExample.Refactor
{
	using NetCoreExamples.BestPractices.SOLID.OpenClosed.FirstExample.Refactor.Delivery;

	internal class Store : IStore
	{
		public double CalculateDeliveryCost(Order order)
		{
			if (order == null) return -1;

			IDelivery delivery = Factory.Instance.Get(order.Country);
			double result = delivery.CalculateCost(order);

			return result;
		}
	}
}
