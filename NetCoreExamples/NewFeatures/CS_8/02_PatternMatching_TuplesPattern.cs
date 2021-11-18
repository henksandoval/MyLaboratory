namespace NetCoreExamples.NewFeatures.CS_8
{
	using System;
	using NetCoreExamples.RunnableInterfaces;

	public class PatternMatching_TuplesPattern : IRunnableCS_8
	{
		public void Run()
		{
			var yellow = Color.Yellow;
			var blue = Color.Blue;
			var red = Color.Red;
			var orange = Color.Orange;

			var resultMix = MixPrimaryColors(yellow, red);
			WriteLine(yellow, red, resultMix);
			resultMix = MixPrimaryColors(red, blue);
			WriteLine(red, blue, resultMix);
			resultMix = MixPrimaryColors(orange, blue);
			WriteLine(orange, blue, resultMix);
		}

		private void WriteLine(Color yellow, Color red, Color resultMix) => Console.WriteLine($"After mixing {yellow} with {red} we get {resultMix}");

		public Color MixPrimaryColors(Color color01, Color color02)
		{
			return (color01, color02) switch
			{
				(Color.Blue, Color.Yellow) => Color.Green,
				(Color.Yellow, Color.Blue) => Color.Green,
				(Color.Blue, Color.Red) => Color.Purple,
				(Color.Red, Color.Blue) => Color.Purple,
				(Color.Yellow, Color.Red) => Color.Orange,
				(Color.Red, Color.Yellow) => Color.Orange,
				(_, _) when color01 == color02 => color01,
				_ => Color.Unknown
			};
		}

		public enum Color
		{
			Yellow,
			Blue,
			Red,
			Green,
			Purple,
			Orange,
			Unknown,
		}
	}
}
