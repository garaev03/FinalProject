using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.ViewComponents
{
    public class VehicleViewComponent:ViewComponent
    {
        private readonly IVehicleService _service;
        public VehicleViewComponent(IVehicleService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vehicles= await _service.GetAllAsync(x=>!x.isDeleted && x.isConfirmed);
            return View(vehicles);
        }
    }
}
