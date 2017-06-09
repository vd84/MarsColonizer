using Acme.Universe;
using FluentAssertions;

namespace Acme.MarsColonizer.Tests.AcceptanceTests
{
    public class TerraformerTests
    {
        protected Terraformer Sut;
        protected PlanetAnalyzer Analyzer;

        public void GivenThatIAmTerraformingMars()
        {
            var mars = Planet.Mars;
            Sut = new Terraformer(mars);
            Analyzer = new PlanetAnalyzer(mars);
        }

        public void WhenIPerformTerraformingUsing(string orders)
        {
            Sut.PerformTerraforming(orders);
        }

        public void ThenTheOxygenLevelShouldBeEqualTo(int expected)
        {
            Analyzer.MeasureOxygenLevel().Should().Be(expected);
        }

        public void ThenTheAverageTemperatureShouldBeEqualTo(int expected)
        {
            Analyzer.MeasureAverageTemperature().Should().Be(expected);
        }

        public void ThenTheOceanCoverageShouldBeEqualTo(int expected)
        {
            Analyzer.MeasureOceanCoverage().Should().Be(expected);
        }
    }
}
