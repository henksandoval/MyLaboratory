﻿namespace NetCoreExamples.Examples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AsynFor : IRunnable
    {
        public void Run()
        {
            AsynExample.MainAsync().GetAwaiter();
        }

        public static class AsynExample
        {
            public static async Task MainAsync()
            {
                IList<Task<string>> tasks = new List<Task<string>>();

                for (int i = 0; i < 10; i++)
                {
                    tasks.Add(Geeter(i));
                }
                await Task.WhenAll(tasks.ToArray());
                tasks.ToList().ForEach(x => Console.WriteLine(x.Result));
            }

            private static async Task<string> Geeter(int number)
            {
                if (number % 2 == 0)
                {
                    await Task.Delay(3000);
                }
                else
                {
                    await Task.Delay(500);
                }

                string text = $"Executed call async number: {number}";
                Console.WriteLine(text);
                return $"Welcome: {number}";
            }
        }
    }
}