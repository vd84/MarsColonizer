using TestStack.BDDfy;
using Xunit;

namespace Acme.MarsColonizer.Tests.AcceptanceTests.Generation4
{
    [Trait("Category", "Generation 4")]
    [Story(
        AsA = "Interplanetary colonist",
        IWant = "To to analyze the conditions on a planet",
        SoThat = "I can be certain that I can live there perpetually")]
    public class SustainableLife : TerraformerAcceptanceTests
    {
        [Fact(Skip = "Not run in the first 3 generations")]
        public void TerraformingMarsCompletely()
        {
            var minimumTerraformingNecessary = "P9,A19,G14";
            this.Given(_ => _.GivenThatIAmTerraformingMars())
                .When(_ => _.WhenIPerformTerraformingUsing(minimumTerraformingNecessary))
                .And(_ => _.WhenIAnalyzeThePlanet())
                .Then(_ => _.ThenItIsFoundSuitableForSustainableHumanLife())
                .BDDfy();
        }

        [Fact(Skip = "Not run in the first 3 generations")]
        public void TerraformingMarsAlmostCompletely()
        {
            var terraformingOrders = string.Empty;
            this.Given(_ => _.GivenThatIAmTerraformingMars())
                .When(_ => _.WhenIPerformTerraformingUsing(terraformingOrders))
                .And(_ => _.WhenIAnalyzeThePlanet())
                .Then(_ => _.ThenItIsFoundUnsuitableForSustainableHumanLife())
                .WithExamples(new ExampleTable("Terraforming orders")
                {
                    "P8,A19,G14",
                    "P9,A18,G14",
                    "P9,A19,G13"
                })
                .BDDfy();
        }
    }
}