using Entities.Concrets;
using DAL.Repositories.Interfaces;
using Core.Repositories.Implementations;

namespace DAL.Repositories.Implementations{
    public class FuelRepository:TEntityRepository<Fuel,AppDbContext>,IFuelRepository
    {
        public FuelRepository(AppDbContext db):base(db){}         
    }
}
