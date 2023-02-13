using Business.Services.Interfaces;

namespace Business.Services.Implementations
{
    public class IDCheckerService : IIDCheckerService
    {
        private readonly AllServices _service;
        public IDCheckerService(AllServices service)
        {
            _service = service;
        }

        public async Task CheckBanId(int id)
        {
            await _service._banService.GetByIdAsync(id);
        }
        public async Task CheckCityId(int id)
        {
            await _service._cityService.GetByIdAsync(id);
        }
        public async Task CheckColorId(int id)
        {
            await _service._colorService.GetByIdAsync(id);
        }
        public async Task CheckCountryId(int id)
        {
            await _service._countryService.GetByIdAsync(id);
        }
        public async Task CheckCurrencyId(int id)
        {
            await _service._currencyService.GetByIdAsync(id);
        }

        public async Task CheckDriveTrainId(int id)
        {
            await _service._driveTrainService.GetByIdAsync(id);
        }

        public async Task CheckEngineCapacityId(int id)
        {
            await _service._engineCapacityService.GetByIdAsync(id);
        }

        public async Task CheckFuelId(int id)
        {
            await _service._fuelService.GetByIdAsync(id);
        }

        public async Task CheckGearBoxId(int id)
        {
            await _service._gearBoxService.GetByIdAsync(id);
        }

        public async Task CheckMileageTypeId(int id)
        {
            await _service._mileageTypeService.GetByIdAsync(id);
        }

        public async Task CheckModelId(int id)
        {
            await _service._modelService.GetByIdAsync(id);
        }

        public async Task CheckOwnerCountId(int id)
        {
            await _service._ownerCountService.GetByIdAsync(id);
        }

        public async Task CheckSeatId(int id)
        {
            await _service._seatService.GetByIdAsync(id);
        }

        public async Task CheckVehicleConditionId(int id)
        {
            await _service._conditionService.GetByIdAsync(id);
        }

        public async Task CheckVehicleImageId(int id)
        {
            //
        }

        public async Task CheckVehicleReportId(int id)
        {
            await _service._reportService.GetByIdAsync(id);
        }

        public async Task CheckVehicleSupplyId(int id)
        {
            await _service._supplyService.GetByIdAsync(id);
        }

        public async Task CheckYearId(int id)
        {
            await _service._yearService.GetByIdAsync(id);
        }
    }
}
