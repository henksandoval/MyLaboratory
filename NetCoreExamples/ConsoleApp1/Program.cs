namespace NetCoreExamples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    class Program
    {
        private static void Main(string[] args)
        {
            ExecuteRunnables();
        }

        private static void ExecuteRunnables()
        {
            IEnumerable<Type> runnables = (
                from type in typeof(Program).GetTypeInfo().Assembly.GetTypes()
                let typeInfo = type.GetTypeInfo()
                where typeInfo.IsClass && typeof(IRunnable).IsAssignableFrom(type)
                select type).ToList().OrderBy(x => x.Namespace.PadRight(1));

            foreach (Type type in runnables)
            {
                IRunnable runnable = (IRunnable)Activator.CreateInstance(type);
                Console.WriteLine($"--------Example: {type.Name} ----------");
                runnable.Run();
            }

            Console.ReadKey();
        }

    }
}
