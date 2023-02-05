using Core.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Entities.Concrets;

namespace DAL.Repositories.Implementations;

public class ColorRepository : TEntityRepository<Color, AppDbContext>, IColorRepository
{
    public ColorRepository(AppDbContext db) : base(db) { }
}
