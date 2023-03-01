namespace TurboAzClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin,SuperAdmin")]
    public class ColorsController : Controller
    {
        private readonly IColorService _service;
        private readonly ColorPostDtoValidation _validator;
        public ColorsController(IColorService service, ColorPostDtoValidation validator)
        {
            _service = service;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
            => View(await _service.GetAllAsync());

        public IActionResult Create()
            => View();

        [HttpPost]
        public async Task<IActionResult> Create(ColorPostDto postDto)
        {
            var result = await _validator.ValidateAsync(postDto);
            if (!result.IsValid)
            {
                var error = result.Errors.FirstOrDefault();
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return View();
            }
            try
            {
                await _service.CreateAsync(postDto);
            }
            catch (ImageException ex) { ModelState.AddModelError("formFile", ex.Message); return View(); }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            ColorUpdateDto updateDto = new ColorUpdateDto();
            try { updateDto.getDto = await _service.GetByIdAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("NotFound", "Error"); }
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ColorUpdateDto updateDto)
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
            catch (NotFoundException ex) { TempData["NaMessageme"] = ex.Message; return RedirectToAction("NotFound", "Error"); }
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
