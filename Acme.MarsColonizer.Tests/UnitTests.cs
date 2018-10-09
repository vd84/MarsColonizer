using Acme.MarsColonizer;
using Acme.Universe;
using Acme.Universe.Terraforming;
using Acme.Universe.Terraforming.Directives;
using FluentAssertions;
using Xunit;

namespace UnitTests
{
    [Trait("Category", "Unit")]
    public class TerraformerTests
    {
        protected readonly Planet Mars = Planet.Mars;
        protected readonly Terraformer Sut; // System Under Test
        protected readonly PlanetAnalyzer Analyzer;

        public TerraformerTests()
        {
            Sut = new Terraformer(Mars);
            Analyzer = new PlanetAnalyzer(Mars);
        }

        [Fact]
        public void SingleAsteroid()
        {
            // Arrange
            var directive = new CrashAsteroid(1);

            // Act
            Sut.ProcessDirective(directive);
            var analysis = Analyzer.Analyze();

            // Assert
            analysis.AverageTemperature
                .Should().Be(-28);
        }
    }

    [Trait("Category", "Unit")]
    public class DirectiveIdentifierTests
    {
        [Fact]
        public void CanIdentifyGreenery()
        {
            DirectiveIdentifier.Parse("G1")
                .Should().BeOfType<ConstructGreenery>();
        }
    }
}