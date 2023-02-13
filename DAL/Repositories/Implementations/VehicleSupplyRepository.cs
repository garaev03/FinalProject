using Entities.Concrets;
using DAL.Repositories.Interfaces;
using Core.Repositories.Implementations;

namespace DAL.Repositories.Implementations{
    public class VehicleSupplyRepository:TEntityRepository<VehicleSupply,AppDbContext>,IVehicleSupplyRepository
    {
        public VehicleSupplyRepository(AppDbContext db):base(db){}         
    }
}