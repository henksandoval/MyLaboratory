namespace NetCoreExamples.BestPractices.SOLID.SingleResponsability.FirtsExample.Refactor
{
	using System;
	using System.Collections.Generic;
	using Microsoft.Data.Sqlite;

	internal class ProductRepository : IDisposable
	{
		private SqliteConnection sqliteDb;
		private readonly bool disposedValue;

		public ProductRepository()
		{
			InitDatabase();
		}

		public void Save(Product newProduct)
		{
			var insertCommand = sqliteDb.CreateCommand();
			insertCommand.CommandText = "INSERT INTO Product ( ProductId, Name, Price ) " +
										"VALUES ( $id, $name, $price )";
			insertCommand.Parameters.AddWithValue("$id", newProduct.ProductId);
			insertCommand.Parameters.AddWithValue("$name", newProduct.Name);
			insertCommand.Parameters.AddWithValue("$price", newProduct.Price);
			insertCommand.ExecuteNonQuery();
		}

		public List<Product> List()
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

			const string connectionString = "DataSource=Example;Mode=Memory;Cache=Shared";
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
				if (sqliteDb != null)
				{
					sqliteDb.Dispose();
					sqliteDb = null;
				}
		}
	}
}
