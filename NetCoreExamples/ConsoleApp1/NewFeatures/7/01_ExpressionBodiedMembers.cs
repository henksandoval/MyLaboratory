﻿namespace NetCoreExamples.NewFeatures._7
{
    using System;
    public class ExpressionBodiedMembers : IRunnable
    {
        public void Run()
        {
            Animal snake = new Animal("snake");
            snake = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    public class Animal
    {
        private string family;
        public string Family
        {
            get => family;
            set => family = value;
        }
        public Animal(string family)
        {
            Family = family;
        }

        ~Animal() => Console.WriteLine("Destructing Animal instance");

    }
}
