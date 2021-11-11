namespace NetCoreExamples.BestPractices.SOLID.SingleResponsability.FirtsExample.Refactor
{
	using System;
	using System.Collections.Generic;

	internal class Service : IService, IDisposable
	{
		private ProductRepository repository;

		public Service()
		{
			repository = new ProductRepository();
		}

		public double CalculateProductTax(Product product)
		{
			//Validate product.
			if (product == null) return 0;

			const double Tax = 0.19;
			var productTax = product.Price * Tax;
			return productTax;
		}

		public bool SaveProduct(Product newProduct)
		{

			//Validate product
			if (newProduct == null || newProduct.ProductId < 0 || string.IsNullOrEmpty(newProduct.Name))
			{
				return false;
			}

			repository.Save(newProduct);
			return true;
		}

		public List<Product> ListProducts()
		{

			var products = repository.List();
			return products;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
				if (repository != null)
				{
					repository.Dispose();
					repository = null;
				}
		}
	}
}
