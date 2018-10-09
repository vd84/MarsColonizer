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
            Planet.ConstructGreenery();
        }
    }

    public static class DirectiveIdentifier
    {
        public static Directive Parse(string input)
        {
            return new ConstructGreenery(1);
        }
    }
}