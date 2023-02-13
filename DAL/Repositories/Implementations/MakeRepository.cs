using Entities.Concrets;
using DAL.Repositories.Interfaces;
using Core.Repositories.Implementations;

namespace DAL.Repositories.Implementations{
    public class MakeRepository:TEntityRepository<Make,AppDbContext>,IMakeRepository
    {
        public MakeRepository(AppDbContext db):base(db){}         
    }
}