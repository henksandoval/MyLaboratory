namespace NetCoreExamples.NewFeatures.CS_8
{
	using System;
	using System.Buffers;
	using System.Text;
	using System.Text.Json;
	using NetCoreExamples.RunnableInterfaces;

	public class JsonWriter : IRunnableCS_8
	{
		public void Run() => JsonWriterSample();

		private void JsonWriterSample()
		{
			var buffer = new ArrayBufferWriter<byte>();
			using var json = new Utf8JsonWriter(buffer, new JsonWriterOptions { Indented = true });

			PopulateJson(json);
			json.Flush();

			var output = buffer.WrittenSpan.ToArray();
			var ourJson = Encoding.UTF8.GetString(output);
			Console.WriteLine(ourJson);
		}

		private void PopulateJson(Utf8JsonWriter json)
		{
			json.WriteStartObject();

			json.WritePropertyName("courseName");
			json.WriteStringValue("What's New in C# 8.0 and .NET Core 3.0");
			json.WritePropertyName("language");
			json.WriteStringValue("C#");

			json.WriteStartObject("author");

			json.WritePropertyName("firstName");
			json.WriteStringValue("Matt");
			json.WritePropertyName("lastName");
			json.WriteStringValue("Honeycutt");

			json.WriteEndObject();

			json.WriteEndObject();
		}
	}
}
