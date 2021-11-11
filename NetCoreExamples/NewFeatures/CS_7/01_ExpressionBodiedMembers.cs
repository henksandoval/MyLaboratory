namespace NetCoreExamples.NewFeatures.CS_7
{
    using System;
	using NetCoreExamples.RunnableInterfaces;

	public class ExpressionBodiedMembers : IRunnableCS_7
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
