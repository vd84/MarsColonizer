using Acme.MarsColonizer.Tests.AcceptanceTests.Common;
using TestStack.BDDfy;
using Xunit;

namespace AcceptanceTests.Generation2
{
    [Trait("Category", "Generation 2")]
    [Story(
        AsA = "Terraforming engineer",
        IWant = "To include directives of different types in a single order",
        SoThat = "I can create more efficient orders")]
    public class CombiningDirectives : TerraformerAcceptanceTests
    {
        [Fact]
        public void CombiningDifferentDirectives()
        {
            var terraformingOrders = string.Empty;
            var oxygenLevel = 0;
            var averageTemperature = 0;
            var oceanCoverage = 0;
            this.Given(_ => _.GivenThatIAmTerraformingMars())
                .When(_ => _.WhenIPerformTerraformingUsing(terraformingOrders))
                .And(_ => _.WhenIAnalyzeThePlanet())
                .Then(_ => _.ThenTheOxygenLevelShouldBeEqualTo(oxygenLevel))
                .And(_ => _.ThenTheAverageTemperatureShouldBeEqualTo(averageTemperature))
                .And(_ => _.ThenTheOceanCoverageShouldBeEqualTo(oceanCoverage))
                .WithExamples(new ExampleTable("Terraforming orders", "Oxygen Level", "Average Temperature", "Ocean Coverage")
                {
                    { "G1,A1,P1", 1 , -28, 1 },
                    { "A1,G2", 2, -28, 0 },
                    { "A1,G2", 2, -28, 0 },
                    { "G2,A0", 2, -30, 0 },
                    { "P1,G10,A0", 10, -30, 1 },
                    { "G1,A2,P2", 1, -26, 2 },
                    { "A2,G1,P2", 1, -26, 2 },
                    { "P2,G1,A2", 1, -26, 2 }
                })
                .BDDfy();
        }
    }

    [Trait("Category", "Generation 2")]
    [Story(
        AsA = "Interplanetary colonist",
        IWant = "To to analyze the conditions on a planet",
        SoThat = "I can be certain that I can live there perpetually")]
    public class AnalyzingIfPlanetCanSustainLife : TerraformerAcceptanceTests
    {
        [Fact]
        public void TerraformingMarsCompletely()
        {
            this.Given(_ => _.GivenThatIAmConsideringSettlingOnEarth())
                .When(_ => _.WhenIAnalyzeThePlanet())
                .Then(_ => _.ThenItIsFoundSuitableForSustainableHumanLife())
                .BDDfy();
        }
    }
}
