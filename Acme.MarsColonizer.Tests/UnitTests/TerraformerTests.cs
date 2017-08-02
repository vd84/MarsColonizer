using Acme.MarsColonizer.Directives;
using Acme.Universe;
using FluentAssertions;
using Xunit;

namespace Acme.MarsColonizer.Tests.UnitTests
{
    public class TerraformerTests
    {
        protected readonly Planet Mars = Planet.Mars;
        protected readonly Terraformer Sut;
        protected readonly SustainableLifePlanetAnalyzer Analyzer;

        public TerraformerTests()
        {
            Sut = new Terraformer(Mars);
            Analyzer = new SustainableLifePlanetAnalyzer(Mars);
        }

        [Fact]
        public void SingleAsteroid()
        {
            // Arrange
            var directive = new CrashAsteroid(1);

            // Act
            Sut.ProcessDirective(directive);

            // Assert
            Analyzer.MeasureAverageTemperature()
                .Should().Be(-28);
        }
    }
}

