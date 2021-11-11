﻿namespace NetCoreExamples.BestPractices.SOLID.SingleResponsability.FirtsExample
{
	using System;
	using NetCoreExamples.RunnableInterfaces;
	using BadService = Symptom.Service;
	using GoodService = Refactor.Service;

	public class SingleResponsability : IRunnableSolid
	{
		public void Run()
		{
			var exampleWithBadService = new BadService();
			Implementation(exampleWithBadService);
			exampleWithBadService.Dispose();

			var exampleWithGoodService = new GoodService();
			Implementation(exampleWithGoodService);
			exampleWithGoodService.Dispose();
		}

		private void Implementation(IService service)
		{
			var product = new Product
			{
				ProductId = 1,
				Name = "Product One",
				Price = 10
			};

			Console.WriteLine(service.CalculateProductTax(product));

			service.SaveProduct(product);

			var products = service.ListProducts();
			foreach (var currentProduct in products)
			{
				Console.WriteLine($"Id: {currentProduct.ProductId}, name: {currentProduct.Name}");
			}
		}
	}
}
