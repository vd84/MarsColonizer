using System;
using Acme.Universe;

namespace Acme.MarsColonizer
{
    public class SustainableLifePlanetAnalyzer : PlanetAnalyzer
    {
        public SustainableLifePlanetAnalyzer(Planet planet) 
            : base(planet)
        {
        }

        public bool IsAirBreathableForHumans()
        {
            throw new NotImplementedException();
        }

        public bool ContainsEnoughWaterForEarthLikeWeather()
        {
            throw new NotImplementedException();
        }

        public bool HasAverageTemperatureWellAboveFreezingPoint()
        {
            throw new NotImplementedException();
        }

        public bool HasConditionsSuitableForSustainableHumanLife()
        {
            return IsAirBreathableForHumans() 
                && ContainsEnoughWaterForEarthLikeWeather() 
                && HasAverageTemperatureWellAboveFreezingPoint();
        }
    }
}
