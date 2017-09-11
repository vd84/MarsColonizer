using TestStack.BDDfy;
using Xunit;

namespace Acme.MarsColonizer.Tests.AcceptanceTests.Generation1
{
    [Trait("Category", "Generation 1")]
    [Story(
        AsA = "Terraforming engineer",
        IWant = "To enter the directive for pumping aquifers as a P followed by the number of aquifers",
        SoThat = "I can terraform Mars more efficiently")]
    public class PumpingAquifers : TerraformerAcceptanceTests
    {
        [Fact]
        public void PumpingAquifer()
        {
            var terraformingOrders = string.Empty;
            var oceanCoverage = 0;
            this.Given(_ => _.GivenThatIAmTerraformingMars())
                .When(_ => _.WhenIPerformTerraformingUsing(terraformingOrders))
                .And(_ => _.WhenIAnalyzeThePlanet())
                .Then(_ => _.ThenTheOceanCoverageShouldBeEqualTo(oceanCoverage))
                .WithExamples(new ExampleTable("Terraforming orders", "Ocean Coverage")
                {
                    { "", 0 },
                    { "P0", 0 },
                    { "P2", 2 },
                    { "P10", 10 }
                })
                .BDDfy();
        }
    }
}