namespace NetCoreExamples.NewFeatures.CS_8
{
	using System;
	using System.IO;
	using System.Text.Json;
	using System.Text.Json.Serialization;
	using NetCoreExamples.RunnableInterfaces;

	public class JsonSerializerDeserialize: IRunnableCS_8
	{
		public void Run()
		{
			var document = File.ReadAllText("JsonFiles/OpenLibraSample.json");
			var book = JsonSerializer.Deserialize<Book>(document, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			Console.WriteLine($"Book title: {book.Title}");
			Console.WriteLine($"Author: {book.Author.FullName}");
		}

		public class Book
		{
			public string ID { get; set; }
			public string Title { get; set; }
			public string Content { get; set; }
			[JsonPropertyName("content_short")]
			public string ContentShort { get; set; }
			public string Publisher { get; set; }
			public string PublisherDate { get; set; }
			public string Pages { get; set; }
			public string Language { get; set; }
			[JsonPropertyName("url_details")]
			public string UrlDetails { get; set; }
			[JsonPropertyName("url_download")]
			public string UrlDownload { get; set; }
			[JsonPropertyName("url_read_online")]
			public string UrlReadOnline { get; set; }
			public string Cover { get; set; }
			public string Thumbnail { get; set; }
			[JsonPropertyName("num_comments")]
			public string NumComments { get; set; }
			public bool Enabled { get; set; }
			public Author Author { get; set; }
			public Tag[] Tags { get; set; }
			public Category[] Categories { get; set; }
		}

		public class Author
		{
			public string FirstName { get; private set; }
			public string LastName { get; private set; }

			public string FullName => $"{FirstName} {LastName}";

			public Author(string firstName, string lastName)
			{
				FirstName = firstName;
				LastName = lastName;
			}

			[JsonConstructor]
			public Author(string fullName)
			{
				var nameArray = fullName.Split(" ");
				FirstName = nameArray[0];
				LastName = nameArray[^1];
			}
		}

		public class Category
		{
			public string Name { get; set; }
		}

		public class Tag
		{
			public string Name { get; set; }
		}
	}
}
