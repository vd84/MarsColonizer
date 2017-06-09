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

        public void PerformTerraforming(string orders)
        {
            var directive = DirectiveIdentifier.Parse(orders);
            if (directive is ConstructGreenery)
                Planet.ConstructGreenery();
        }
    }
}
