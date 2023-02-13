using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using Business.Utilities.Validations.MakeValidations;
using Entities.DTOs.MakeDtos;
using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MakesController : Controller
    {
        private readonly IMakeService _service;
        private readonly MakePostDtoValidation _validator;
        public MakesController(IMakeService service, MakePostDtoValidation validator)
        {
            _service = service;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
            => View(await _service.GetAllAsync());

        public IActionResult Create()
            => View();

        [HttpPost]
        public async Task<IActionResult> Create(MakePostDto postDto)
        {
            if (!_validator.ValidateAsync(postDto).Result.IsValid) return View();
            try
            {
                await _service.CreateAsync(postDto);
            }
            catch (ImageException ex) { ModelState.AddModelError("formFile", ex.Message); return View(); }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            MakeUpdateDto updateDto = new MakeUpdateDto();
            try { updateDto.getDto = await _service.GetByIdAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("NotFound", "Error"); }
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(MakeUpdateDto updateDto)
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
            catch (ImageException ex) { ModelState.AddModelError("", ex.Message); return View(updateDto); }
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
