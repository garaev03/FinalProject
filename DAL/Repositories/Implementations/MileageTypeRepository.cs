using Core.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Entities.Concrets;

namespace DAL.Repositories.Implementations
{
    public class MileageTypeRepository : TEntityRepository<MileageType, AppDbContext>, IMileageTypeRepository
    {
        public MileageTypeRepository(AppDbContext db) : base(db) { }
    }
}
