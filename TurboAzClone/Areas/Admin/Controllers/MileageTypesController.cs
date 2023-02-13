using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using Business.Utilities.Validations.MileageTypeValidations;
using Entities.DTOs.MileageTypeDtos;
using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MileageTypesController : Controller
    {
        private readonly IMileageTypeService _service;
        private readonly MileageTypePostValidation _validator;
        public MileageTypesController(IMileageTypeService service, MileageTypePostValidation validator)
        {
            _service = service;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
            => View(await _service.GetAllAsync());
        public IActionResult Create()
            => View();

        [HttpPost]
        public async Task<IActionResult> Create(MileageTypePostDto postDto)
        {
            var result = await _validator.ValidateAsync(postDto);
            if (!result.IsValid)
            {
                var error = result.Errors.FirstOrDefault();
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return View();
            }
            await _service.CreateAsync(postDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            MileageTypeUpdateDto updateDto = new MileageTypeUpdateDto();
            try { updateDto.getDto = await _service.GetByIdAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("NotFound", "Error"); }
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(MileageTypeUpdateDto updateDto)
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

