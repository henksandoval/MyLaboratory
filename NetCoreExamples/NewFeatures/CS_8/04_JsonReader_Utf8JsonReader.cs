namespace NetCoreExamples.NewFeatures.CS_8
{
	using System;
	using System.IO;
	using System.Text.Json;
	using NetCoreExamples.RunnableInterfaces;

	public class JsonReader_Utf8JsonReader : IRunnableCS_8
	{
		public void Run()
		{
			ExampleUseUTF8JsonReader();
		}

		public void ExampleUseUTF8JsonReader()
		{
			var jsonBytes = File.ReadAllBytes("JsonFiles/OpenLibraSample.json");
			var span = jsonBytes.AsSpan();
			var jsonData = new Utf8JsonReader(span);

			while (jsonData.Read())
			{
				Console.WriteLine(GetTokenDesc(jsonData));
			}
		}

		private string GetTokenDesc(Utf8JsonReader json) => json.TokenType switch
		{
			JsonTokenType.None => "None",
			JsonTokenType.StartObject => "Start Object",
			JsonTokenType.EndObject => "End Object",
			JsonTokenType.StartArray => "Start Array",
			JsonTokenType.EndArray => "End Array",
			JsonTokenType.PropertyName => $"Property Name: {json.GetString()}",
			JsonTokenType.Comment => $"Comment: {json.GetString()}",
			JsonTokenType.String => $"String: {json.GetString()}",
			JsonTokenType.Number => $"Number: {json.GetInt32()}",
			JsonTokenType.True or JsonTokenType.False => $"Bool: {json.GetBoolean()}",
			JsonTokenType.Null => "NULL",
			_ => $"**UNHANDLED TOKEN: {json.TokenType}"
		};
	}
}
