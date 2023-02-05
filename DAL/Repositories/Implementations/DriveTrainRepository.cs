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
    public class DriveTrainRepository : TEntityRepository<DriveTrain, AppDbContext>, IDriveTrainRepository
    {
        public DriveTrainRepository(AppDbContext db) : base(db) { }
    }
}
