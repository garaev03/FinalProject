using Core.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class CountryRepository : TEntityRepository<Country, AppDbContext>, ICountryRepository
    {
        public CountryRepository(AppDbContext db) : base(db) { }
    }
}
