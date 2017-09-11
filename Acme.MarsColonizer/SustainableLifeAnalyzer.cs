using System;
using Acme.Universe;

namespace Acme.MarsColonizer
{
    public class SustainableLifeAnalyzer
    {
        public SustainableLifeAnalyzer(PlanetaryAnalysis analysis) 
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