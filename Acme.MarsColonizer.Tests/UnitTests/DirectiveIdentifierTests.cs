using Acme.MarsColonizer.Directives;
using Acme.MarsColonizer.Text;
using FluentAssertions;
using Xunit;

namespace Acme.MarsColonizer.Tests.UnitTests
{
    public class DirectiveIdentifierTests
    {
        [Fact]
        public void CanIdentifyGreenery()
        {
            DirectiveIdentifier.Parse("G1").Should().BeOfType<ConstructGreenery>();
        }
    }
}
