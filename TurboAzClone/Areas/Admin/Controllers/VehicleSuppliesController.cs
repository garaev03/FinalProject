﻿using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using Business.Utilities.Validations.VehicleSupplyValidations;
using Entities.DTOs.VehicleSupplyDtos;
using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehicleSuppliesController : Controller
    {
        private readonly IVehicleSupplyService _service;
        private readonly VehicleSupplyPostDtoValidation _validator;
        public VehicleSuppliesController(IVehicleSupplyService service, VehicleSupplyPostDtoValidation validator)
        {
            _service = service;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
            => View(await _service.GetAllAsync());
        public IActionResult Create()
            => View();

        [HttpPost]
        public async Task<IActionResult> Create(VehicleSupplyPostDto postDto)
        {
            if (!_validator.ValidateAsync(postDto).Result.IsValid) return View();
            await _service.CreateAsync(postDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            VehicleSupplyUpdateDto updateDto = new VehicleSupplyUpdateDto();
            try { updateDto.getDto = await _service.GetByIdAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("NotFound", "Error"); }
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(VehicleSupplyUpdateDto updateDto)
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
