using DMCustoms.Data;
using DMCustoms.Models;
using Microsoft.AspNetCore.Mvc;

namespace DMCustoms.Controllers
{
    public class RentalController : Controller
    {
        private IVehicleRepository _vehicleRepository;

        public RentalController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(RentalInputViewModel viewModel)
        {
            var model = new RentalInputModel(_vehicleRepository)
            {
                NumberOfDays = viewModel.NumberOfDays,
                VehicleType = viewModel.VehicleType
            };

            ViewBag.CalculatedRental = model.Calculate();

            return View(viewModel);
        }
    }
}
