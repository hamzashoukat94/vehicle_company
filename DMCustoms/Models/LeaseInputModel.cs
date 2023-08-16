using DMCustoms.Data;
using Microsoft.VisualBasic;
using System.Reflection;

namespace DMCustoms.Models
{
    /// <summary>
    /// Represents an input model for calculating lease payment details.
    /// </summary>
    public class LeaseInputModel
    {
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// The type of the leased vehicle.
        /// </summary>
        public VehicleType VehicleType { get; set; }

        /// <summary>
        /// The initial amount of the lease.
        /// </summary>
        public decimal LeaseAmount { get; set; }

        /// <summary>
        /// The residual value of the leased vehicle at the end of the lease term.
        /// </summary>
        public decimal ResidualValue { get; set; }

        /// <summary>
        /// The duration of the lease in years.
        /// </summary>
        public int LeaseDuration { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeaseInputModel"/> class with the provided vehicle repository.
        /// </summary>
        /// <param name="vehicleRepository">The repository used to access vehicle-related data.</param>
        public LeaseInputModel(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Calculates and returns the monthly lease payment details.
        /// </summary>
        /// <returns>A <see cref="LeaseOutputModel"/> containing calculated payment details.</returns>
        public LeaseOutputModel CalculateMonthlyPayment()
        {
            Dictionary<VehicleType, decimal> interestRates = _vehicleRepository.GetInterestRates();

            if (!interestRates.TryGetValue(VehicleType, out decimal interestRate))
            {
                throw new InvalidOperationException("Invalid vehicle type.");
            }

            int numberOfPayments = LeaseDuration * 12;
            decimal amount = LeaseAmount - ResidualValue;

            int monthlyPayment = CalculateMonthlyPayment(interestRate, numberOfPayments, amount);

            decimal totalInterest = (monthlyPayment * numberOfPayments) - amount;
            decimal totalAmountToPay = monthlyPayment * numberOfPayments;

            return new LeaseOutputModel
            {
                MonthlyPayment = monthlyPayment,
                TotalInterest = totalInterest,
                TotalAmountToPay = totalAmountToPay,
            };
        }

        /// <summary>
        /// Calculates the monthly payment amount based on the provided interest rate, number of payments, and principal amount.
        /// </summary>
        /// <param name="interestRate">The interest rate for the calculation.</param>
        /// <param name="numberOfPayments">The total number of monthly payments.</param>
        /// <param name="amount">The principal amount to be paid off.</param>
        /// <returns>The calculated monthly payment amount.</returns>
        private int CalculateMonthlyPayment(decimal interestRate, int numberOfPayments, decimal amount)
        {
            DateTime dueDate = DateTime.Now.AddMonths(1);
            double doubleInterestRate = (double)interestRate;
            double doubleAmount = (double)amount;
            // Used the VB Financial Package
            return (int)Financial.Pmt(doubleInterestRate, numberOfPayments, -doubleAmount, 0, DueDate.EndOfPeriod);
        }
    }
}
