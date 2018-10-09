using Acme.Universe;
using Acme.Universe.Terraforming;
using FluentAssertions;

namespace Acme.MarsColonizer.Tests.AcceptanceTests.Common
{
    public abstract class TerraformerAcceptanceTests
    {
        protected Terraformer Sut { get; private set; }
        protected Planet CurrentPlanet { get; private set; }
        protected PlanetaryAnalysis Analysis { get; private set; }

        protected void GivenThatIAmTerraformingMars()
        {
            CurrentPlanet = Planet.Mars;
            Sut = new Terraformer(CurrentPlanet);
        }

        protected void GivenThatIAmConsideringSettlingOnEarth()
        {
            CurrentPlanet = Planet.Earth;
        }

        protected void WhenIAnalyzeThePlanet()
        {
            var analyzer = new PlanetAnalyzer(CurrentPlanet);
            Analysis = analyzer.Analyze();
        }

        protected void WhenIPerformTerraformingUsing(string orders)
        {
            Sut.Execute(orders);
        }

        protected void ThenTheOxygenLevelShouldBeEqualTo(int expected)
        {
            Analysis.OxygenLevel
                .Should().Be(expected);
        }

        protected void ThenTheAverageTemperatureShouldBeEqualTo(int expected)
        {
            Analysis.AverageTemperature
                .Should().Be(expected);
        }

        protected void ThenTheOceanCoverageShouldBeEqualTo(int expected)
        {
            Analysis.OceanCoverage
                .Should().Be(expected);
        }

        protected void ThenItIsFoundSuitableForSustainableHumanLife()
        {
            var analyzer = new SustainableLifeAnalyzer(Analysis);

            analyzer.HasConditionsSuitableForSustainableHumanLife()
                .Should().BeTrue();
        }

        protected void ThenItIsFoundUnsuitableForSustainableHumanLife()
        {
            var analyzer = new SustainableLifeAnalyzer(Analysis);

            analyzer.HasConditionsSuitableForSustainableHumanLife()
                .Should().BeFalse();
        }
    }
}