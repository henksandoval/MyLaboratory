namespace NetCoreExamples.NewFeatures.CS_7
{
    using System;
	using NetCoreExamples.RunnableInterfaces;

	public class ThrowExpressions : IRunnableCS_7
    {
        public void Run()
        {
            PersonGreeter personGreeter = new PersonGreeter("Lucas");
            string salute = personGreeter.Greet(() => "Hola, como estas");
            string englishSalute = personGreeter.Greet(() => "Hi, how are you");
            // personGreeter.Greet(null);
        }

        public class PersonGreeter
        {
            public string Name { get; }
            public PersonGreeter(string name)
            {
                Name = name ?? throw new ArgumentNullException(nameof(name));
            }

            public string Greet(Func<string> greeter)
            {
                string greeting = greeter?.Invoke() ?? throw new ArgumentNullException(nameof(greeter));
                return $"{greeting} {Name}";
            }
        }
    }
}
