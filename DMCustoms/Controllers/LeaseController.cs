using DMCustoms.Data;
using DMCustoms.Models;
using Microsoft.AspNetCore.Mvc;

namespace DMCustoms.Controllers
{
    public class LeaseController : Controller
    {
        private IVehicleRepository _vehicleRepository;
        public LeaseController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(LeaseInputViewModel viewModel)
        {
            var model = new LeaseInputModel(_vehicleRepository)
            {
                VehicleType = viewModel.VehicleType,
                LeaseAmount = viewModel.LeaseAmount,
                ResidualValue = viewModel.ResidualValue,
                LeaseDuration = viewModel.LeaseDuration
            };

            LeaseOutputModel leaseOutputModel = model.CalculateMonthlyPayment();
            ViewBag.MonthlyPayment = leaseOutputModel.MonthlyPayment;
            ViewBag.TotalInterest = leaseOutputModel.TotalInterest;
            ViewBag.TotalAmountToPay = leaseOutputModel.TotalAmountToPay;

            return View(viewModel);
        }
    }
}
