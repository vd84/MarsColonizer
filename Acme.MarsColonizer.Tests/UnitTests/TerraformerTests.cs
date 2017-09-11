using Acme.MarsColonizer.Directives;
using Acme.Universe;
using FluentAssertions;
using Xunit;

namespace Acme.MarsColonizer.Tests.UnitTests
{
    [Trait("Category", "Unit")]
    public class TerraformerTests
    {
        protected readonly Planet Mars = Planet.Mars;
        protected readonly Terraformer Sut;
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
}