using TestStack.BDDfy;
using Xunit;

namespace Acme.MarsColonizer.Tests.AcceptanceTests.Generation1
{
    [Trait("Category", "Generation 1")]
    [Story(
        AsA = "Terraforming engineer",
        IWant = "To enter the directive for crashing asteroids as an A followed by the number of asteroids",
        SoThat = "I can terraform Mars more efficiently")]
    public class CrashingAsteroids : TerraformerAcceptanceTests
    {
        [Fact]
        public void CrashingAsteroid()
        {
            var terraformingOrders = string.Empty;
            var averageTemperature = 0;
            this.Given(_ => _.GivenThatIAmTerraformingMars())
                .When(_ => _.WhenIPerformTerraformingUsing(terraformingOrders))
                .And(_ => _.WhenIAnalyzeThePlanet())
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
    }
}