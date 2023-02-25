namespace Entities.DTOs.VehicleDtos
{
    public class VehicleGetDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int BanId { get; set; }
        public int FuelId { get; set; }
        public int DriveTrainId { get; set; }
        public int GearBoxId { get; set; }
        public int MileageTypeId { get; set; }
        public int YearId { get; set; }
        public int ColorId { get; set; }
        public int EngineCapacityId { get; set; }
        public int CurrencyId { get; set; }
        public int OwnerId { get; set; }
        public int CountryId { get; set; }
        public int VehicleConditionId { get; set; }
        public int SeatId { get; set; }
        public int CityId { get; set; }
        public int Milage { get; set; }
        public int Price { get; set; }
        public int EnginePower { get; set; }
        public string? VIN { get; set; }
        public string? Description { get; set; }
        public string? OwnerName { get; set; }
        public string? Email { get; set; }
        public int PhoneNumberId { get; set; }
        public bool isCredit { get; set; }
        public bool isBarter { get; set; }
        public bool isConfirmed { get; set; }
        public bool isCancelled { get; set; }
        public bool inAwait { get; set; }
        public bool isExpired { get; set; }
        public bool isEdited { get; set; }
        public string? PINCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }

        public PhoneNumber? PhoneNumber { get; set; }
        public Model? Model { get; set; }
        public Ban? Ban { get; set; }
        public Fuel? Fuel { get; set; }
        public DriveTrain? DriveTrain { get; set; }
        public GearBox? GearBox { get; set; }
        public MileageType? MileageType { get; set; }
        public Year? Year { get; set; }
        public Color? Color { get; set; }
        public EngineCapacity? EngineCapacity { get; set; }
        public Currency? Currency { get; set; }
        public OwnerCount? Owner { get; set; }
        public Country? Country { get; set; }
        public City? City { get; set; }
        public Seat? Seat { get; set; }
        public List<VehicleReport> Reports { get; set; }
        public List<VehicleSupply> Supplies { get; set; }
        public List<VehicleImage> Images { get; set; }
        public VehicleGetDto()
        {
            Reports = new();
            Supplies = new();
            Images = new();
        }
    }
}
