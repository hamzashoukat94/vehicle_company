using DMCustoms.Data;
using System.Reflection;

namespace DMCustoms.Models
{
    /// <summary>
    /// Represents an input model for calculating the total cost of renting a vehicle based on vehicle type and number of days.
    /// </summary>
    public class RentalInputModel
    {
        private IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Gets or sets the number of days for which the rental cost is calculated.
        /// </summary>
        public int NumberOfDays { get; set; }

        /// <summary>
        /// Gets or sets the type of the rented vehicle.
        /// </summary>
        public VehicleType VehicleType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalInputModel"/> class with the provided vehicle repository.
        /// </summary>
        /// <param name="vehicleRepository">The repository used to access vehicle-related data.</param>
        public RentalInputModel(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Calculates and returns the total cost of renting a vehicle based on the specified vehicle type and number of days.
        /// </summary>
        /// <returns>The calculated total rental cost.</returns>
        public decimal Calculate()
        {
            // Repository patterns is used to find the rental rates.
            // In my case, I'm not creating or deleting the data in the repository but I'm using it as a datasource.
            // I may use the strategy design pattern but in interest of time I used the repository one.
            Dictionary<VehicleType, int> rentalRates = _vehicleRepository.GetRentalRates();

            // While I could utilize the iterator of the rentalRates dictionary, I opted for a more effective method.

            if (!rentalRates.TryGetValue(VehicleType, out int dailyRent))
            {
                throw new InvalidOperationException("Invalid vehicle type.");
            }

            return dailyRent * NumberOfDays;
        }
    }
}
