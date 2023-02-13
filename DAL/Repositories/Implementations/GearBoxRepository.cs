using Entities.Concrets;
using DAL.Repositories.Interfaces;
using Core.Repositories.Implementations;

namespace DAL.Repositories.Implementations{
    public class GearBoxRepository:TEntityRepository<GearBox,AppDbContext>,IGearBoxRepository
    {
        public GearBoxRepository(AppDbContext db):base(db){}         
    }
}