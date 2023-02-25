namespace DAL.Repositories.Implementations;
public class ColorRepository : TEntityRepository<Color, AppDbContext>, IColorRepository
{
    public ColorRepository(AppDbContext db) : base(db) { }
}