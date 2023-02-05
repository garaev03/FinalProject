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
    public class CurrencyRepository : TEntityRepository<Currency, AppDbContext>, ICurrencyRepository
    {
        public CurrencyRepository(AppDbContext db) : base(db) { }
    }
}
