using DMCustoms.Models;

namespace DMCustoms.Data
{
    /// <summary>
    /// Implementation of the <see cref="IVehicleRepository"/> interface providing access to interest rates and rental rates for different vehicle types.
    /// </summary>
    public class VehicleRepository : IVehicleRepository
    {
        // Static dictionaries to store interest rates and rental rates for different vehicle types.
        private static readonly Dictionary<VehicleType, decimal> InterestRates = new Dictionary<VehicleType, decimal>
        {
            { VehicleType.MotorCycle, 0.03m },   // Interest rate for MotorCycle.
            { VehicleType.Hatchback, 0.04m },    // Interest rate for Hatchback.
            { VehicleType.Sedan, 0.05m },        // Interest rate for Sedan.
            { VehicleType.SUV, 0.06m }           // Interest rate for SUV.
        };


        // Collections is being used
        private static readonly Dictionary<VehicleType, int> rentalRates = new Dictionary<VehicleType, int>
        {
            { VehicleType.MotorCycle, 500 },     // Rental rate for MotorCycle.
            { VehicleType.Hatchback, 700 },      // Rental rate for Hatchback.
            { VehicleType.Sedan, 1000 },         // Rental rate for Sedan.
            { VehicleType.SUV, 1500 }            // Rental rate for SUV.
        };

        /// <summary>
        /// Retrieves the interest rates for different types of vehicles.
        /// </summary>
        /// <returns>A dictionary containing VehicleType as keys and corresponding decimal interest rates as values.</returns>
        public Dictionary<VehicleType, decimal> GetInterestRates()
        {
            return InterestRates;
        }

        /// <summary>
        /// Retrieves the rental rates for different types of vehicles.
        /// </summary>
        /// <returns>A dictionary containing VehicleType as keys and corresponding integer rental rates as values.</returns>
        public Dictionary<VehicleType, int> GetRentalRates()
        {
            return rentalRates;
        }
    }
}
