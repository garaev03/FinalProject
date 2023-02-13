using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using Business.Utilities.Validations.ModelValidations;
using Entities.DTOs.ModelDtos;
using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModelsController : Controller
    {
        private readonly IModelService _service;
        private readonly IMakeService _makeService;
        private readonly ModelPostDtoValidation _validator;
        public ModelsController(IModelService service, ModelPostDtoValidation validator, IMakeService makeService)
        {
            _service = service;
            _validator = validator;
            _makeService = makeService;
        }

        public async Task<IActionResult> Index()
            => View(await _service.GetAllAsync(includes: "Make"));
        public async Task<IActionResult> Create()
        {
            ViewBag.Makes = await _makeService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModelPostDto postDto)
        {
            ViewBag.Makes = await _makeService.GetAllAsync();
            var result = await _validator.ValidateAsync(postDto);
            if (!result.IsValid) return View();
            try
            {
                await _service.CreateAsync(postDto);
            }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("NotFound", "Error"); }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            ModelUpdateDto updateDto = new ModelUpdateDto();
            try { ViewBag.Makes = await _makeService.GetAllAsync(); updateDto.getDto = await _service.GetByIdAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("NotFound", "Error"); }
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ModelUpdateDto updateDto)
        {
            updateDto.getDto.Name = updateDto.postDto.Name;
            ViewBag.Makes = await _makeService.GetAllAsync();
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
