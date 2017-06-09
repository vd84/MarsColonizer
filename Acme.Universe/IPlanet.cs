namespace Acme.Universe
{
    public interface IPlanet
    {
        ///<summary>Gets the name of the planet</summary>
        string Name { get; }
        
        /// <summary>
        /// Creates a greenery on the planet, increasing its oxygen levels
        /// </summary>
        void ConstructGreenery();

        /// <summary>
        /// Dissipates oxygen from the atmosphere into space, decreasing the oxygen levels
        /// </summary>
        void DissipateOxygen();

        /// <summary>
        /// Pumps water from an aquifer to the planet's surface, forming a new or increasing the size of an existing ocean
        /// </summary>
        void PumpAquifer();

        /// <summary>
        /// Dissipates water from the surface into space, decreasing the ocean coverage
        /// </summary>
        void VaporizeWater();

        /// <summary>
        /// Crashes an asteroid into the atmosphere where the friction combusts it, increasing the average temperature of the planet
        /// </summary>
        void CrashAsteroid();
    }
}
