using TestStack.BDDfy;
using Xunit;

namespace Acme.MarsColonizer.Tests.AcceptanceTests
{
    [Story(
        AsA = "Terraforming engineer",
        IWant = "To include multiple directives in a single order",
        SoThat = "I don't have to do complicated math myself")]
    public class Round3Tests : TerraformerTests
    {
        [Fact]
        public void CreatingSubsequentGreeneries()
        {
            var terraformingOrders = string.Empty;
            var oxygenLevel = 0;
            this.Given(_ => _.GivenThatIAmTerraformingMars())
                .When(_ => _.WhenIPerformTerraformingUsing(terraformingOrders))
                .Then(_ => _.ThenTheOxygenLevelShouldBeEqualTo(oxygenLevel))
                .WithExamples(new ExampleTable("Terraforming orders", "Oxygen Level")
                {
                    { "G1G1", 2 },
                    { "G1G-1", 0 },
                    { "G2G2", 4 },
                    { "G10G0", 10 },
                    { "G1\nG2", 3 }
                })
                .BDDfy();
        }
    }
}
