using System;

namespace Acme.Universe
{
    public class PlanetAnalyzer
    {
        public PlanetAnalyzer(Planet planet)
        {
            Planet = planet ?? throw new ArgumentNullException(nameof(planet));
        }

        public PlanetaryAnalysis Analyze()
        {
            return new PlanetaryAnalysis(
                Planet.Name, 
                MeasureOxygenLevel(), 
                MeasureOceanCoverage(),
                MeasureAverageTemperature());
        }

        public Planet Planet { get; }

        private int MeasureOxygenLevel()
        {
            return Planet.OxygenLevel;
        }

        private int MeasureOceanCoverage()
        {
            return Planet.OceanCoverage;
        }

        private int MeasureAverageTemperature()
        {
            return Planet.AverageTemperature;
        }
    }
}
