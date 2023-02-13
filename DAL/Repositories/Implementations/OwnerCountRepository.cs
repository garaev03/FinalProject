using Entities.Concrets;
using DAL.Repositories.Interfaces;
using Core.Repositories.Implementations;

namespace DAL.Repositories.Implementations{
    public class OwnerCountRepository:TEntityRepository<OwnerCount,AppDbContext>,IOwnerCountRepository
    {
        public OwnerCountRepository(AppDbContext db):base(db){}         
    }
}