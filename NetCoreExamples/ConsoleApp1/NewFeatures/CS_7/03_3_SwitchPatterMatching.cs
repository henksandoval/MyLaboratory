namespace NetCoreExamples.NewFeatures.CS_7
{
	using System;
	using NetCoreExamples.RunnableInterfaces;

	public class SwitchPatterMatching3 : IRunnableCS_7
	{
		private enum TypeJutsu
		{
			Ninjutsu,
			Taijutsu,
			Genjutsu
		}

		private class Ninja
		{
			public Ninja(int powerLevel, TypeJutsu jutsu)
			{
				PowerLevel = powerLevel;
				Jutsu = jutsu;
			}

			public int PowerLevel { get; set; }

			public TypeJutsu Jutsu { get; set; }
		}

		public void Run()
		{
			Ninja naruto = new Ninja(9999, TypeJutsu.Ninjutsu);
			Ninja boruto = new Ninja(1000, TypeJutsu.Ninjutsu);
			Ninja sasuke = new Ninja(9999, TypeJutsu.Genjutsu);

			Console.WriteLine(GetDescriptionTextByNinja(naruto));
			Console.WriteLine(GetDescriptionTextByNinja(boruto));
			Console.WriteLine(GetDescriptionTextByNinja(sasuke));
		}

		private string GetDescriptionTextByNinja(Ninja someNinja)
		{
			string parseText = string.Empty;

			switch (someNinja)
			{
				case var ninja when ninja.PowerLevel == 9999 && ninja.Jutsu.Equals(TypeJutsu.Ninjutsu):
					parseText = $"This ninja is Naruto her power level is {someNinja.PowerLevel} and her special ability is {someNinja.Jutsu}";
					break;
				case var ninja when ninja.PowerLevel == 1000 && ninja.Jutsu.Equals(TypeJutsu.Ninjutsu):
					parseText = $"This ninja is Boruto her power level is {someNinja.PowerLevel} and her special ability is {someNinja.Jutsu}, he's Naruto's son";
					break;
				case var ninja when ninja.PowerLevel == 9999 && ninja.Jutsu.Equals(TypeJutsu.Ninjutsu):
					parseText = $"This ninja is Sasuke her power level is {someNinja.PowerLevel} and her special ability is {someNinja.Jutsu}";
					break;
			}

			return parseText;
		}
	}
}
