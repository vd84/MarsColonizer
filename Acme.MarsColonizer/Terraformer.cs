using System;
using Acme.MarsColonizer.Directives;
using Acme.MarsColonizer.Text;
using Acme.Universe;

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
}