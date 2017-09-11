using TestStack.BDDfy;
using Xunit;

namespace Acme.MarsColonizer.Tests.AcceptanceTests.Generation2
{
    [Trait("Category", "Generation 2")]
    [Story(
        AsA = "Interplanetary colonist",
        IWant = "To to analyze the conditions on a planet",
        SoThat = "I can be certain that I can live there perpetually")]
    public class SustainableLife : TerraformerAcceptanceTests
    {
        [Fact(Skip = "Not run in the first generation")]
        public void TerraformingMarsCompletely()
        {
            this.Given(_ => _.GivenThatIAmConsideringSettlingOnEarth())
                .When(_ => _.WhenIAnalyzeThePlanet())
                .Then(_ => _.ThenItIsFoundSuitableForSustainableHumanLife())
                .BDDfy();
        }
    }
}