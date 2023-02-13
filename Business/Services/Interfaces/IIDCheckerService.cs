
namespace Business.Services.Interfaces
{
    public interface IIDCheckerService
    {
        Task CheckModelId(int id);
        Task CheckBanId(int id);
        Task CheckFuelId(int id);
        Task CheckDriveTrainId(int id);
        Task CheckGearBoxId(int id);
        Task CheckMileageTypeId(int id);
        Task CheckYearId(int id);
        Task CheckColorId(int id);
        Task CheckEngineCapacityId(int id);
        Task CheckCurrencyId(int id);
        Task CheckOwnerCountId(int id);
        Task CheckCountryId(int id);
        Task CheckCityId(int id);
        Task CheckSeatId(int id);
        Task CheckVehicleConditionId(int id);
        Task CheckVehicleReportId(int id);
        Task CheckVehicleSupplyId(int id);
        Task CheckVehicleImageId(int id);
    }
}
