using TestStack.BDDfy;
using Xunit;

namespace Acme.MarsColonizer.Tests.AcceptanceTests
{
    [Story(
        AsA = "Terraforming engineer",
        IWant = "To include directives of different types in a single order",
        SoThat = "I can create more efficient orders")]
    public class Round2Tests : TerraformerTests
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
                .Then(_ => _.ThenTheOxygenLevelShouldBeEqualTo(oxygenLevel))
                .And(_ => _.ThenTheAverageTemperatureShouldBeEqualTo(averageTemperature))
                .And(_ => _.ThenTheOceanCoverageShouldBeEqualTo(oceanCoverage))
                .WithExamples(new ExampleTable("Terraforming orders", "Oxygen Level", "Average Temperature", "Ocean Coverage")
                {
                    { "G1,A1,P1", 1 , -28, 1 },
                    { "A1,G2", 2, -28, 0 },
                    { "A1,G2 ", 2, -28, 0 },
                    { " A1,G2", 2, -28, 0 },
                    { "A1, G2", 2, -28, 0 },
                    { "G2;A0", 2, -30, 0 },
                    { "P1,G10,A0", 10, -30, 1 },
                    { "G1\nA2,P2", 3, -26, 2 },
                    { "\nG1\nA2\nP2\n", 3, -26, 2 },
                    { "\nG1;A2,P2\n", 3, -26, 2 }
                })
                .BDDfy();
        }
    }
}
