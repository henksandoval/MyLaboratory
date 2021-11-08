namespace NetCoreExamples.NewFeatures._7
{
    using System;
    using System.Collections.Generic;

    public class TuplesAndDeconstructions : IRunnable
    {
        public void Run()
        {
            (int sum, int total, string) result = SumNumbers(2, 12, 56, 3);

            (string key, string value) = GetGameSetting("GameDifficulty");
        }

        public (int sum, int total, string) SumNumbers(params int[] numbers)
        {
            int total = 0;
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
                total += 1;
            }
            return (sum, total, "manolo");
        }

        public (string setting, string value) GetGameSetting(string key)
        {
            return configuration.ContainsKey(key) ?
                    (key, configuration[key]) :
                    throw new Exception("Key not found");
        }

        private Dictionary<string, string> configuration = new Dictionary<string, string>()
        {
            ["GameDifficulty"] = "Hard",
            ["MaxPlayers"] = "5",
            ["GameMaxTime"] = "2"
        };


    }

    internal class User { }
}
