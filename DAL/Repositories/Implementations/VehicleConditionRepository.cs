using Entities.Concrets;
using DAL.Repositories.Interfaces;
using Core.Repositories.Implementations;

namespace DAL.Repositories.Implementations{
    public class VehicleConditionRepository:TEntityRepository<VehicleCondition,AppDbContext>,IVehicleConditionRepository
    {
        public VehicleConditionRepository(AppDbContext db):base(db){}         
    }
}