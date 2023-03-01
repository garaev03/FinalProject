namespace Entities.DTOs.VehicleDtos
{
    public class VehicleUpdateDto
    {
        public int Milage { get; set; }
        public int Price { get; set; }
        public int EnginePower { get; set; }
        public string? Description { get; set; }
        public int BanId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int EngineCapacityId { get; set; }
        public int MileageTypeId { get; set; }
        public int CurrencyId { get; set; }
        public int YearId { get; set; }
        public int DriveTrainId { get; set; }
        public int SeatId { get; set; }
        public int FuelId { get; set; }
        public int ColorId { get; set; }
        public int GearBoxId { get; set; }
        public int MainImageId { get; set; }
        public bool isCredit { get; set; }
        public bool isBarter { get; set; }
        public List<int> SupplyIds { get; set; }
        public List<int> ReportIds { get; set; }
        public List<int> ImageIds { get; set; }
        public List<IFormFile> formFiles { get; set; }
        public VehicleGetDto getDto { get; set; }
        public VehicleUpdateDto()
        {
            getDto = new();
            ImageIds = new();
            ReportIds = new();
            SupplyIds = new();
            formFiles = new();
        }
    }
}
