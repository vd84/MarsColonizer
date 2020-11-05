using System;
using Acme.Universe;
using Acme.Universe.Terraforming.Directives;

namespace Acme.MarsColonizer
{
    public class Terraformer
    {
        public Terraformer(IPlanet planet)
        {
            Planet = planet ?? throw new ArgumentNullException(nameof(planet));
        }

        public IPlanet Planet { get; }

        public void Execute(string orders)
        {
            var directive = DirectiveIdentifier.Parse(orders);
            ProcessDirective(directive);
        }

        internal void ProcessDirective(Directive directive)
        {
            try
            {
                switch (directive.GetType().Name.ToString())
                {
                    case "ConstructGreenery":
                        for (var i = 0; i < directive.Times; i++)
                            Planet.ConstructGreenery();
                        break;
                    case "CrashAsteroid":
                        for (var i = 0; i < directive.Times; i++)
                            Planet.CrashAsteroid();
                        break;
                    case "PumpAquifer":
                        for (var i = 0; i < directive.Times; i++)
                            Planet.PumpAquifer();
                        break;

                }
            } catch(Exception)
            {
                return;
            }
        }
    }

    public static class DirectiveIdentifier
    {
        public static Directive Parse(string input)
        {
            if(input == "")
            {
                return null;
            }
            switch (input.Substring(0,1))
            {
                case "G":
                    return new ConstructGreenery(int.Parse(input.Substring(1,input.Length-1)));
                case "A":
                    return new CrashAsteroid(int.Parse(input.Substring(1, input.Length - 1)));
                case "P":
                    return new PumpAquifer(int.Parse(input.Substring(1, input.Length - 1)));
            }
            return null;
        }
    }
}