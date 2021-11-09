/// <summary>
/// The static modifier imports the static members and nested types from a single type rather than importing all the types in a namespace.
/// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-directive
/// </summary>
namespace NetCoreExamples.NewFeatures.CS_6
{
    using static NetCoreExamples.NewFeatures.CS_6.Greeter;

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
