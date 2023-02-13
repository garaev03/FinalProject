using Entities.Concrets;
using DAL.Repositories.Interfaces;
using Core.Repositories.Implementations;

namespace DAL.Repositories.Implementations{
    public class StatusRepository:TEntityRepository<Status,AppDbContext>,IStatusRepository
    {
        public StatusRepository(AppDbContext db):base(db){}         
    }
}
