using Business.Services.Interfaces;
using Entities.DTOs.VehicleDtos;
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

        public async Task<IViewComponentResult> InvokeAsync(List<VehicleGetDto> vehicles)
        {
            if(vehicles is null)
                vehicles= await _service.GetAllAsync(x=>!x.isDeleted && x.isConfirmed,true);
            return View(vehicles);
        }
    }
}
