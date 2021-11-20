namespace NetCoreExamples.NewFeatures.CS_8
{
	using System;
	using System.IO;
	using System.Text.Json;
	using NetCoreExamples.RunnableInterfaces;

	public class JsonReader_JsonDocument : IRunnableCS_8
	{
		public void Run() => ExampleUseJsonDocument();

		private void ExampleUseJsonDocument()
		{
			using var stream = File.OpenRead("JsonFiles/OpenLibraSample.json");
			using var document = JsonDocument.Parse(stream);

			var root = document.RootElement;

			var author = root
				.GetProperty("author")
				.GetProperty("firstName")
				.GetString();

			Console.WriteLine($"Author: {author}");
			EnumerateElement(root);
		}

		private void EnumerateElement(JsonElement element)
		{
			foreach (var prop in element.EnumerateObject())
			{
				if (prop.Value.ValueKind == JsonValueKind.Object)
				{
					Console.WriteLine($"{prop.Name}");
					Console.WriteLine($"--BEGIN OBJECT--");
					EnumerateElement(prop.Value);
					Console.WriteLine($"--END OBJECT--");
				}
				else
					Console.WriteLine($"{prop.Name}: {prop.Value.GetRawText()}");
			}
		}
	}
}
