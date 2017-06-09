using System;

namespace Acme.Universe
{
    public class PlanetAnalyzer
    {
        public PlanetAnalyzer(Planet planet)
        {
            Planet = planet ?? throw new ArgumentNullException(nameof(planet));
        }

        public Planet Planet { get; }

        public int MeasureOxygenLevel()
        {
            return Planet.OxygenLevel;
        }

        public int MeasureOceanCoverage()
        {
            return Planet.OceanCoverage;
        }

        public int MeasureAverageTemperature()
        {
            return Planet.AverageTemperature;
        }
    }
}
