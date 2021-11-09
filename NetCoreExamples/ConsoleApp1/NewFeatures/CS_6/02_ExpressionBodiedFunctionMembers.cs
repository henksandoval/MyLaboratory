namespace NetCoreExamples.NewFeatures.CS_6
{
    using System;

    public class ExpressionBodiedFunctionMembers : IRunnable
    {
        public void Run()
        {
            Person person = new Person() { Name = "Henk", SurName = "Sandoval", Age = DateTime.Now.Year - 1990 };
            string fullName = person.FullName;
            string description = person.GetDescription();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public string FullName => $"{Name} {SurName}";
        public string GetDescription() => $"{FullName} has {Age} years";
    }
}
