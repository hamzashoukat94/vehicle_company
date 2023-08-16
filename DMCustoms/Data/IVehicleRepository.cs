using DMCustoms.Models;

namespace DMCustoms.Data
{
    /// <summary>
    /// Represents a repository interface following the Repository Design Pattern for managing vehicle-related data.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Retrieves a dictionary containing the interest rates for different types of vehicles.
        /// The keys represent the VehicleType enumeration, and the values represent the corresponding interest rates.
        /// </summary>
        /// <returns>A dictionary with VehicleType as keys and decimal interest rates as values.</returns>
        Dictionary<VehicleType, decimal> GetInterestRates();

        /// <summary>
        /// Retrieves a dictionary containing the rental rates for different types of vehicles.
        /// The keys represent the VehicleType enumeration, and the values represent the corresponding rental rates.
        /// </summary>
        /// <returns>A dictionary with VehicleType as keys and integer rental rates as values.</returns>
        Dictionary<VehicleType, int> GetRentalRates();
    }

}
