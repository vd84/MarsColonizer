namespace Acme.Universe.Terraforming
{
    public class PlanetaryAnalysis
    {
        public string Name { get; }
        public int OxygenLevel { get; }
        public int OceanCoverage { get; }
        public int AverageTemperature { get; }

        public PlanetaryAnalysis(string name, int oxygenLevel, int oceanCoverage, int averageTemperature)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            OceanCoverage = oceanCoverage;
            AverageTemperature = averageTemperature;
        }

        public override string ToString()
        {
            return
                $"Analysis of planet {Name}. Atmospheric oxygen: {OxygenLevel}%. Surface water coverage: {OceanCoverage}%. Average surface temperature: {AverageTemperature} degrees C.";
        }
    }
}