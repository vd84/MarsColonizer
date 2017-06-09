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
        public void SimpleGreenery()
        {
            // Arrange
            var orders = "G1";

            // Act
            Sut.PerformTerraforming(orders);

            // Assert
            Analyzer.MeasureOxygenLevel().Should().Be(1);
        }

        [Fact]
        public void SimpleAsteroid()
        {
            // Arrange
            var orders = "A1";

            // Act
            Sut.PerformTerraforming(orders);

            // Assert
            Analyzer.MeasureAverageTemperature().Should().Be(-28);
        }
    }
}

