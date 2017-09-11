using System;

namespace Acme.Universe
{
    public class Planet : IPlanet
    {
        public static Planet Mars => new Planet("Mars", 0, 0, -30);
        public static Planet Earth => new Planet("Earth", 71, 21, 15);
        public static Planet Venus => new Planet("Venus", 0, 0, 462);

        private Planet(string name, int oceanCoverage, int oxygenLevel, int averageTemperature)
        {
            Name = name;
            OceanCoverage = oceanCoverage;
            OxygenLevel = oxygenLevel;
            AverageTemperature = averageTemperature;
        }

        public string Name { get; }

        public void ConstructGreenery()
        {
            OxygenLevel++;
        }

        public void DissipateOxygen()
        {
            OxygenLevel--;
        }

        public void PumpAquifer()
        {
            OceanCoverage++;
        }

        public void VaporizeWater()
        {
            OceanCoverage--;
        }

        public void CrashAsteroid()
        {
            AverageTemperature += 2;
        }

        private int _oceanCoverage;
        internal int OceanCoverage
        {
            get => _oceanCoverage;
            set
            {
                if(value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _oceanCoverage = value;
            }
        }

        private int _oxygenLevel;
        internal int OxygenLevel
        {
            get => _oxygenLevel;
            set
            {
                if(value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _oxygenLevel = value;
            }
        }

        internal int AverageTemperature { get; set; }

        public override string ToString()
        {
            return
                $"Planet {Name}.";
        }
    }
}