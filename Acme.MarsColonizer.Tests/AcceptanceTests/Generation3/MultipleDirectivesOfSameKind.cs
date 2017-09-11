using TestStack.BDDfy;
using Xunit;

namespace Acme.MarsColonizer.Tests.AcceptanceTests.Generation3
{
    [Trait("Category", "Generation 3")]
    [Story(
        AsA = "Terraforming engineer",
        IWant = "To combine multiple directives of the same type",
        SoThat = "I can receive orders from various sources more easily")]
    public class MultipleDirectivesOfSameKind : TerraformerAcceptanceTests
    {
        [Fact(Skip = "Not run in the first 2 generations")]
        public void UsingMultipleDirectivesOfSameKind()
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
                    { "G1,G1", 2, -30, 0 },
                    { "A2,A2", 0, -22, 0 },
                    { "P10,P0", 0, -30, 10 },
                    { "G1,G1,G1", 3, -30, 0 },
                    { "G1,G1,G1,G1,G1,G1,G1,G1,G1,G1", 10, -30, 0 },
                    { "G1,P1,G1,P1,G1", 3, -30, 2 },
                })
                .BDDfy();
        }
    }
}