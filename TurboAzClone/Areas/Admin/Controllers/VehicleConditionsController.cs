using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using Business.Utilities.Validations.VehicleConditionValidations;
using Entities.DTOs.VehicleConditionDtos;
using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehicleConditionsController : Controller
    {
        private readonly IVehicleConditionService _service;
        private readonly VehicleConditionPostDtoValidation _validator;
        public VehicleConditionsController(IVehicleConditionService service, VehicleConditionPostDtoValidation validator)
        {
            _service = service;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
            => View(await _service.GetAllAsync());
        public IActionResult Create()
            => View();

        [HttpPost]
        public async Task<IActionResult> Create(VehicleConditionPostDto postDto)
        {
            if (!_validator.ValidateAsync(postDto).Result.IsValid) return View();
            await _service.CreateAsync(postDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            VehicleConditionUpdateDto updateDto = new VehicleConditionUpdateDto();
            try { updateDto.getDto = await _service.GetByIdAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("NotFound", "Error"); }
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(VehicleConditionUpdateDto updateDto)
        {
            updateDto.getDto.Name = updateDto.postDto.Name;
            var result = await _validator.ValidateAsync(updateDto.postDto);
            if (!result.IsValid)
            {
                var error = result.Errors.FirstOrDefault();
                ModelState.AddModelError("", error.ErrorMessage);
                return View(updateDto);
            }
            try { await _service.UpdateAsync(updateDto); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("NotFound", "Error"); }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try { await _service.DeleteAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("NotFound", "Error"); }
            return RedirectToAction("Index");
        }
    }
}
