using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using Entities.DTOs.VehicleDtos;
using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _service;
        private readonly string[] includes = { "Images", "Model", "Model.Make", "Color", "Ban", "Seat", "MileageType", "EngineCapacity", "Year", "DriveTrain", "GearBox", "City", "Currency" };
        public VehiclesController(IVehicleService service)
        {
            _service = service;
        }

        public async Task<IActionResult> News()
            => View(await _service.GetAllAsync(x => x.inAwait, includes));

        public async Task<IActionResult> Edit(int id)
        {
            VehicleGetDto getDto = new();
            try { getDto = await _service.GetByIdAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; RedirectToAction("notfound", "error"); }
            return View(getDto);
        }
    }
}
