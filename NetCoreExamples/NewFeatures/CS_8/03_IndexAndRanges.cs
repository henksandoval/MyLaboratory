namespace NetCoreExamples.NewFeatures.CS_8
{
	using System;
	using System.Linq;
	using NetCoreExamples.RunnableInterfaces;

	public class IndexAndRanges : IRunnableCS_8
	{
		private string[] Words => new string[]
		{
						// index from start    index from end
			"The",      // 0                   ^9
			"quick",    // 1                   ^8
			"brown",    // 2                   ^7
			"fox",      // 3                   ^6
			"jumped",   // 4                   ^5
			"over",     // 5                   ^4
			"the",      // 6                   ^3
			"lazy",     // 7                   ^2
			"dog"       // 8                   ^1
		};              // 9 (or words.Length) ^0

		public void Run()
		{
			IndexExampleWithWords();
			IndexExampleWithNumbers();
		}

		private void IndexExampleWithNumbers()
		{
			var numbers = Enumerable.Range(1, 10).ToArray();

			var copyAllData = numbers[0..^0];
			Console.WriteLine($@"Copying all data from array ({string.Join("-", copyAllData)})");
			var allButFirst = numbers[1..];
			Console.WriteLine($@"All but first ({string.Join("-", allButFirst)})");
			var lastItemRange = numbers[^1..];
			Console.WriteLine($@"Last item range ({string.Join("-", lastItemRange)})");
			var lastItem = numbers[^1];
			Console.WriteLine($@"Last item ({string.Join("-", lastItem)})");
			var lastThree = numbers[^3];
			Console.WriteLine($@"Last three ({string.Join("-", lastThree)})");

			Index middle = 4;
			Index threeFromEnd = ^3;
			Range customRange = middle..threeFromEnd;
			var custom = numbers[customRange];
			Console.WriteLine($@"Example using System.Range ({string.Join("-", custom)})");
		}

		public void IndexExampleWithWords()
		{
			Console.WriteLine($"The first word is {Words[0]}");
			Console.WriteLine($"The last word is {Words[^1]}");

			var quickBrownFox = Words[1..4];
			Console.WriteLine(@$"The following code creates a subrange with the words ""quick"", ""brown"", and ""fox"".
It includes words[1] through words[3]. The element words[4] isn't in the range. ({string.Join(",", quickBrownFox)})");

			var lazyDog = Words[^2..^0];
			Console.WriteLine($@"The following code creates a subrange with ""lazy"" and ""dog"". 
It includes words[^2] and words[^1]. The end index words[^0] isn't included. ({string.Join(",", lazyDog)})");

			var allWords = Words[..];
			Console.WriteLine($@"The following code contains ""The"" through ""dog"". ({string.Join(",", allWords)})");

			var firstPhrase = Words[..4];
			Console.WriteLine($@"The following code contains contains ""The"" through ""fox"". ({string.Join(",", firstPhrase)})");

			var lastPhrase = Words[6..];
			Console.WriteLine($@"The following code contains contains ""The"", ""lazy"" and ""dog"". ({string.Join(",", lastPhrase)})");

			Range rangeAsVariable = 1..4;
			var text = Words[rangeAsVariable];
			Console.WriteLine($@"Using range as variable. ({string.Join(",", text)})");
		}
	}
}
