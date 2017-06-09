using TestStack.BDDfy;
using Xunit;

namespace Acme.MarsColonizer.Tests.AcceptanceTests
{
    [Story(
        AsA = "Terraforming engineer",
        IWant = "To enter directives as a letter representing the terraforming action followed by a number for how many times to repeat the action", 
        SoThat = "I can terraform Mars more efficiently")]
    public class Round1Tests : TerraformerTests
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

        [Fact]
        public void CrashingAsteroid()
        {
            var terraformingOrders = string.Empty;
            var averageTemperature = 0;
            this.Given(_ => _.GivenThatIAmTerraformingMars())
                .When(_ => _.WhenIPerformTerraformingUsing(terraformingOrders))
                .Then(_ => _.ThenTheAverageTemperatureShouldBeEqualTo(averageTemperature))
                .WithExamples(new ExampleTable("Terraforming orders", "Average Temperature")
                {
                    { "", -30 },
                    { "A0", -30 },
                    { "A2", -26 },
                    { "A10", -10 }
                })
                .BDDfy();
        }

        [Fact]
        public void PumpingAquifer()
        {
            var terraformingOrders = string.Empty;
            var oceanCoverage = 0;
            this.Given(_ => _.GivenThatIAmTerraformingMars())
                .When(_ => _.WhenIPerformTerraformingUsing(terraformingOrders))
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
