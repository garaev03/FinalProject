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
    public class EngineCapacityRepository : TEntityRepository<EngineCapacity, AppDbContext>, IEngineCapacityRepository
    {
        public EngineCapacityRepository(AppDbContext db) : base(db) { }
    }
}
