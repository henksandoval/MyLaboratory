namespace NetCoreExamples.BestPractices.SOLID.SingleResponsability.FirtsExample
{
	using System.Collections.Generic;

	internal interface IService
	{
		double CalculateProductTax(Product product);
		List<Product> ListProducts();
		bool SaveProduct(Product newProduct);
	}
}