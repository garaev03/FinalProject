using Core.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Entities.Concrets;

namespace DAL.Repositories.Implementations
{
    public class CityRepository : TEntityRepository<City, AppDbContext>, ICityRepository
    {
        public CityRepository(AppDbContext db) : base(db) { }
    }
}
