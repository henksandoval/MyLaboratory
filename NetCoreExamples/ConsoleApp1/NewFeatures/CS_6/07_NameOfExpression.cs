namespace NetCoreExamples.NewFeatures.CS_6
{
    using System;
    using System.Collections.Generic;

    public class NameOfExpression : IRunnable
    {
        public void Run()
        {
            Fighter fighter = new Fighter("Shinobi");
            IEnumerable<string> fighterStatus = FighterStatus.AllStatus;
            Console.WriteLine(string.Join(" ", fighterStatus));
        }
    }

    public class Fighter
    {
        public Fighter(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
        }
    }

    public class FighterStatus
    {
        public const string Alive = "Vivo";
        public const string Dead = "Muerto";
        public const string Resurrecting = "Resucitando";

        public static IEnumerable<string> AllStatus = new[] { nameof(Alive),
                                                              nameof(Resurrecting),
                                                              nameof(Dead) };
    }


}
