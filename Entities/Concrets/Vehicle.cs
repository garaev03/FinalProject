using Core.Entities.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrets
{
    public class Vehicle:Entity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int BanId { get; set; }
        public int FuelId { get; set; }
        public int GearId { get; set; }
        public int GearBoxId { get; set; }
        public decimal Milage { get; set; }
        public int MileageTypeId { get; set; }
        public int YearId { get; set; }
        public int ColorId { get; set; }
        public int EngineCapacityId { get; set; }
        public decimal Price { get; set; }
        public int CurrencyId { get; set; }
        public decimal EnginePower { get; set; }
        public int OwnerId { get; set; }
        public int CountryId { get; set; }
        public int HuId { get; set; }
        public int SeatId { get; set; }
        public int VIN { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public bool inCredit { get; set; }
        public bool BarterAvailable { get; set; }
        public int StatusId { get; set; }


        public Model Model { get; set; }
        public Ban Ban { get; set; }
        public Fuel Fuel { get; set; }
        public DriveTrain DriveTrain { get; set; }
        public GearBox GearBox { get; set; }
        public MileageType MileageType { get; set; }
        public Year Year { get; set; }
        public Color Color { get; set; }
        public EngineCapacity EngineCapacity { get; set; }
        public Currency Currency { get; set; }
        public OwnerCount Owner { get; set; }
        public Country Country { get; set; }
        public VehicleCondition HU { get; set; }
        public List<VehicleReport> Reports { get; set; }
        public Seat Seat { get; set; }
        public Status Status { get; set; }
        public List<VehicleSupply>Supplies { get; set; }
        public List<VehicleImage> Images { get; set; }
        public Vehicle()
        {
            Reports = new();
            Reports = new();
            Supplies = new();
            Images = new();
        }
    }
}
