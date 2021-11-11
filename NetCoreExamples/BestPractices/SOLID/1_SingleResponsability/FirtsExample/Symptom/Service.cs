namespace NetCoreExamples.BestPractices.SOLID.SingleResponsability.FirtsExample.Symptom
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Microsoft.Data.Sqlite;

	internal class Service : IService, IDisposable
	{
		private SqliteConnection sqliteDb;

		public Service()
		{
			InitDatabase();
		}

		public double CalculateProductTax(Product product)
		{
			if (product == null) return 0;

			const double Tax = 0.19;
			var productTax = product.Price * Tax;
			return productTax;
		}

		public bool SaveProduct(Product newProduct)
		{
			if (newProduct == null || newProduct.ProductId < 0 || string.IsNullOrEmpty(newProduct.Name))
			{
				return false;
			}

			var insertCommand = sqliteDb.CreateCommand();
			insertCommand.CommandText = "INSERT INTO Product ( ProductId, Name, Price ) " +
										"VALUES ( $id, $name, $price )";
			insertCommand.Parameters.AddWithValue("$id", newProduct.ProductId);
			insertCommand.Parameters.AddWithValue("$name", newProduct.Name);
			insertCommand.Parameters.AddWithValue("$price", newProduct.Price);
			insertCommand.ExecuteNonQuery();

			return true;
		}

		public List<Product> ListProducts()
		{
			var products = new List<Product>();

			var selectCommand = sqliteDb.CreateCommand();
			selectCommand.CommandText = "SELECT ProductId, Name, Price FROM Product";
			using (var reader = selectCommand.ExecuteReader())
			{
				while (reader.Read())
				{
					var product = new Product
					{
						ProductId = reader.GetInt32(0),
						Name = reader.GetString(1),
						Price = reader.GetDouble(2)
					};
					products.Add(product);
				}
			}

			return products;
		}

		private void InitDatabase()
		{
			const string connectionString = @"Data Source=SRP.db;Mode=Memory;Cache=Shared";
			sqliteDb = new SqliteConnection(connectionString);
			sqliteDb.Open();

			var createCommand = sqliteDb.CreateCommand();
			createCommand.CommandText =
			@"
                CREATE TABLE Product (
                    ProductId INTEGER,
                    Name TEXT,
                    Price REAL
                )
            ";
			createCommand.ExecuteNonQuery();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
				switch (sqliteDb)
				{
					case var db when db == null:
						break;
					case var db when db.ConnectionString.Contains("Memory"):
						sqliteDb.Dispose();
						sqliteDb = null;
						break;
					case var db when !db.ConnectionString.Contains("Memory"):
						sqliteDb.Close();
						db.Close();
						sqliteDb.Dispose();
						db.Dispose();
						GC.Collect();
						GC.WaitForPendingFinalizers();
						var dbPath = $"{Directory.GetCurrentDirectory()}\\SRP.db";
						var dbFile = new FileInfo(dbPath);
						dbFile.Delete();
						break;
				}
		}
	}
}
