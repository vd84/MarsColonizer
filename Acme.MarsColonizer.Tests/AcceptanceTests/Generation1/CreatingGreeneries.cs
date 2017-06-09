using TestStack.BDDfy;
using Xunit;

namespace Acme.MarsColonizer.Tests.AcceptanceTests.Generation1
{
    [Story(
        AsA = "Terraforming engineer",
        IWant = "To enter the directive for creating greeneries as a G followed by the number of greeneries",
        SoThat = "I can terraform Mars more efficiently")]
    public class CreatingGreeneries : TerraformerAcceptanceTests
    {
        [Fact]
        public void CreatingGreenery()
        {
            var terraformingOrders = string.Empty;
            var oxygenLevel = 0;
            this.Given(_ => _.GivenThatIAmTerraformingMars())
                .When(_ => _.WhenIPerformTerraformingUsing(terraformingOrders))
                .Then(_ => _.ThenTheOxygenLevelShouldBeEqualTo(oxygenLevel))
                .WithExamples(new ExampleTable("Terraforming orders", "Oxygen Level")
                {
                    { "", 0 },
                    { "G0", 0 },
                    { "G2", 2 },
                    { "G10", 10 }
                })
                .BDDfy();
        }
    }
}
