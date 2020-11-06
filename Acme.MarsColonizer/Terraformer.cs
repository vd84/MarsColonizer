using Acme.Universe;
using Acme.Universe.Terraforming.Directives;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var directiveList = DirectiveIdentifier.ParseList(orders);
            foreach (var directive in directiveList)
            {
                ProcessDirective(directive);
            }
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
            }
            catch (Exception)
            {
                return;
            }
        }
    }

    public static class DirectiveIdentifier
    {
        public static List<Directive> ParseList(string input)
        {

            var directiveList = input.Split(',', '\n', ' ', ';') ;

            return directiveList.Select(Parse).ToList();
        }

        public static Directive Parse(string input)
        {
            if (input == "")
            {
                return null;
            }

            switch (input.Substring(0, 1))
            {
                case "G":
                    return new ConstructGreenery(int.Parse(input.Substring(1, input.Length - 1)));
                case "A":
                    return new CrashAsteroid(int.Parse(input.Substring(1, input.Length - 1)));
                case "P":
                    return new PumpAquifer(int.Parse(input.Substring(1, input.Length - 1)));
            }
            return null;
        }
    }
}