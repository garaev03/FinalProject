using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace TurboAzClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _service;
        public VehiclesController(IVehicleService service)
        {
            _service = service;
        }

        public async Task<IActionResult> All()
            => View(await _service.GetAllAsync(x => x.isConfirmed && !x.isExpired, true));

        public async Task<IActionResult> News()
            => View(await _service.GetAllAsync(x => x.inAwait && !x.isExpired, true));

        public async Task<IActionResult> Cancels()
            => View(await _service.GetAllAsync(x => x.isCancelled && !x.isDeleted, true));

        public async Task<IActionResult> Editeds()
            => View(await _service.GetAllAsync(x => x.isEdited, true));

        public async Task<IActionResult> Expireds()
           => View(await _service.GetAllAsync(x => x.isExpired, true));

        public async Task<IActionResult> Confirm(int id)
        {
            try { await _service.ConfirmAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("notfound", "error"); }
            return RedirectToAction("news");
        }

        public async Task<IActionResult> Await(int id)
        {
            try { await _service.AwaitAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("notfound", "error"); }
            return RedirectToAction("cancels");
        }

        public async Task<IActionResult> Cancel(int id)
        {
            try { await _service.CancelAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("notfound", "error"); }
            return RedirectToAction("news");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try { await _service.DeleteAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("notfound", "error"); }
            return RedirectToAction("news");
        }
        public async Task<IActionResult> RenewExpireDate(int id)
        {
            try { await _service.RenewExpireDateAsync(id); }
            catch (NotFoundException ex) { TempData["Message"] = ex.Message; return RedirectToAction("notfound", "error"); }
            return RedirectToAction("news");
        }
    }
}
