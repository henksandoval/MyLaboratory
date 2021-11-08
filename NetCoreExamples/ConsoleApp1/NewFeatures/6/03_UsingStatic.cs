namespace NetCoreExamples.NewFeatures._6
{
    using static NetCoreExamples.NewFeatures._6.Greeter;

    public class UsingStatic : IRunnable
    {
        public void Run()
        {
            Salute("Henk");
        }
    }

    public class Greeter
    {
        public static string Salute(string name)
        {
            return $"Hello {name}";
        }
    }
}
