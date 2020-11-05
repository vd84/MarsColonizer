using Acme.MarsColonizer;
using Acme.Universe;
using Acme.Universe.Terraforming;
using Acme.Universe.Terraforming.Directives;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    [Trait("Category", "Unit")]
    public class TerraformerTests
    {
        protected readonly Planet Mars = Planet.Mars;
        protected readonly Terraformer Sut; // System Under Test
        protected readonly PlanetAnalyzer Analyzer;

        public TerraformerTests()
        {
            Sut = new Terraformer(Mars);
            Analyzer = new PlanetAnalyzer(Mars);
        }

        [Theory]
        [InlineData(0, -30)]
        [InlineData(1, -28)]
        [InlineData(10, -10)]
        [InlineData(15, 0)]
        [InlineData(20, 10)]
        public void CrashingAsteroidTest( int times, int averageTemperature)
        {
            // Arrange
            var directive = new CrashAsteroid(times);

            // Act
            Sut.ProcessDirective(directive);
            var analysis = Analyzer.Analyze();

            // Assert
            analysis.AverageTemperature
                .Should().Be(averageTemperature);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        [InlineData(2, 2)]
        [InlineData(10, 10)]
        public void CreatingGreeneryTest(int times, int oxygenLevel)
        {
            // Arrange
            var directive = new ConstructGreenery(times);

            // Act
            Sut.ProcessDirective(directive);
            var analysis = Analyzer.Analyze();

            // Assert
            analysis.OxygenLevel
                .Should().Be(oxygenLevel);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        [InlineData(2, 2)]
        [InlineData(10, 10)]
        public void PumpingAquiferTest(int times, int oceanCoverage)
        {
            // Arrange
            var directive = new PumpAquifer(times);

            // Act
            Sut.ProcessDirective(directive);
            var analysis = Analyzer.Analyze();

            // Assert
            analysis.OceanCoverage
                .Should().Be(oceanCoverage);
        }
        
        [Fact]
        public void MutipleValuesTest()
        {
            // Arrange
            var directiveCrashAsteroid = new CrashAsteroid(1);
            var directiveConstructGreenery = new ConstructGreenery(1);
            var directivePumpAquifer = new PumpAquifer(1);

            // Act
            Sut.ProcessDirective(directiveCrashAsteroid);
            Sut.ProcessDirective(directiveConstructGreenery);
            Sut.ProcessDirective(directivePumpAquifer);
            var analysis = Analyzer.Analyze();

            // Assert
            analysis.AverageTemperature
                .Should().Be(-28);
            analysis.OxygenLevel
                .Should().Be(1);
            analysis.OceanCoverage
                .Should().Be(1);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, -28, 1)]
        [InlineData(2, 1, 0, 2, -28, 0)]
        [InlineData(2, 1, 0, 2, -28, 0)]
        [InlineData(2, 0, 0, 2, -30, 0)]
        [InlineData(10, 0, 1, 10, -30, 1)]
        [InlineData(1, 2, 2, 1, -26, 2)]
        public void MultipleDirectiveAndvaluesTest(
            int G,
            int A,
            int P,
            int oxygenLevel,
            int averageTemperature,
            int oceanCoverage)
        {
            // Arrange
            var directiveCrashAsteroid = new CrashAsteroid(A);
            var directiveConstructGreenery = new ConstructGreenery(G);
            var directivePumpAquifer = new PumpAquifer(P);


            // Act
            Sut.ProcessDirective(directiveCrashAsteroid);
            Sut.ProcessDirective(directiveConstructGreenery);
            Sut.ProcessDirective(directivePumpAquifer);
            var analysis = Analyzer.Analyze();

            // Assert
            analysis.AverageTemperature
                .Should().Be(averageTemperature);
            analysis.OxygenLevel
                .Should().Be(oxygenLevel);
            analysis.OceanCoverage
                .Should().Be(oceanCoverage);
        }

        [Theory]       
        [InlineData("A1,G2", 2, -28, 0)]
        [InlineData("A1\nG2 ", 2, -28, 0)]
        [InlineData("A1\nG2\n", 2, -28, 0)]
        [InlineData("\nA1\nG2", 2, -28, 0)]
        [InlineData(" G2,A0", 2, -30, 0)]
        [InlineData("P1,G10,A0 ", 10, -30, 1)]
        [InlineData("G1;A2,P2", 1, -26, 2)]
        [InlineData(",G1,A2\nP2;", 1, -26, 2)]
        [InlineData("G1, G1", 2, -30, 0)]
        [InlineData("A2,A2", 0, -22, 0)]
        [InlineData("P10,P0", 0, -30, 10)]
        [InlineData("G1,G1,G1", 3, -30, 0)]
        [InlineData("G1,G1,G1,G1,G1,G1,G1,G1,G1,G1", 10, -30, 0)]
        [InlineData("G1,P1,G1,P1,G1", 3, -30, 2)]
        public void UsingMultipleDirectivesOfSameAndDifferentKind(
           string orders,
           int oxygenLevel,
           int averageTemperature,
           int oceanCoverage)
        {
            // Arrange
            Sut.Execute(orders);
            var analysis = Analyzer.Analyze();

            // Assert
            analysis.AverageTemperature
                .Should().Be(averageTemperature);
            analysis.OxygenLevel
                .Should().Be(oxygenLevel);
            analysis.OceanCoverage
                .Should().Be(oceanCoverage);
        }

    }

    [Trait("Category", "Unit")]
    public class DirectiveIdentifierTests
    {
        [Fact]
        public void CanIdentifyAsteroid()
        {
            DirectiveIdentifier.Parse("A1")
                .Should().BeOfType<CrashAsteroid>();
        }

        [Fact]
        public void CanIdentifyGreenery()
        {
            DirectiveIdentifier.Parse("G1")
                .Should().BeOfType<ConstructGreenery>();
        }
        [Fact]
        public void CanIdentifyAquifer()
        {
            DirectiveIdentifier.Parse("P1")
                .Should().BeOfType<PumpAquifer>();
        }

        [Theory]
        [InlineData ("G1,A1,P1")]
        [InlineData("A1,G2")]
        [InlineData("G2,A0")]
        [InlineData("P1,G10,A0")]
        [InlineData("G1,A2,P2")]
        [InlineData("G1,A1,P1")]
        [InlineData("A2,G1,P2")]
        [InlineData("P2,G1,A2")]
        [InlineData("G1;A1;P1")]
        [InlineData("A1,G2")]
        [InlineData("A1\nG2 ")]
        [InlineData("A1\nG2\n")]
        [InlineData("\nA1\nG2")]
        [InlineData(" G2,A0")]
        [InlineData("P1,G10,A0 ")]
        [InlineData("G1;A2,P2")]
        [InlineData(",G1,A2\nP2;")]
        [InlineData("G1, G1")]
        [InlineData("A2,A2")]
        [InlineData("P10,P0")]
        [InlineData("G1,G1,G1")]
        [InlineData("G1,G1,G1,G1,G1,G1,G1,G1,G1,G1")]
        [InlineData("G1,P1,G1,P1,G1")]

        public void CanIdentifyrDirective(string directiveList)
        {
            DirectiveIdentifier.ParseList(directiveList)
                .Should().BeOfType<List<Directive>>();
        }
    }
}