using Core.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Entities.Concrets;

namespace DAL.Repositories.Implementations
{
    public class CountryRepository : TEntityRepository<Country, AppDbContext>, ICountryRepository
    {
        public CountryRepository(AppDbContext db) : base(db) { }
    }
}
