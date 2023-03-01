namespace TurboAzClone.ViewComponents
{
    public class VehicleViewComponent : ViewComponent
    {
        private readonly IVehicleService _service;
        public VehicleViewComponent(IVehicleService service, AllServices allServices)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<VehicleGetDto> vehicles)
        {
            if (vehicles is null)
            {
                vehicles = await _service.GetAllAsync(x => !x.isDeleted && x.isConfirmed, true);
                vehicles = vehicles.Reverse<VehicleGetDto>().ToList();
            }
            return View(vehicles);
        }
    }
}