namespace Acme.Universe.Terraforming
{
    public class SustainableLifeAnalyzer
    {
        private readonly PlanetaryAnalysis _analysis;

        public SustainableLifeAnalyzer(PlanetaryAnalysis analysis)
        {
            _analysis = analysis;
        }

        public bool IsAirBreathableForHumans()
        {
            return _analysis.OxygenLevel >= 14;
        }

        public bool ContainsEnoughWaterForEarthLikeWeather()
        {
            return _analysis.OceanCoverage >= 9;
        }

        public bool HasAverageTemperatureWellAboveFreezingPoint()
        {
            return _analysis.AverageTemperature >= 8;
        }

        public bool HasConditionsSuitableForSustainableHumanLife()
        {
            return IsAirBreathableForHumans() 
                   && ContainsEnoughWaterForEarthLikeWeather() 
                   && HasAverageTemperatureWellAboveFreezingPoint();
        }
    }
}