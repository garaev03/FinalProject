namespace DAL.Repositories.Implementations;
public class CityRepository : TEntityRepository<City, AppDbContext>, ICityRepository
{
    public CityRepository(AppDbContext db) : base(db) { }
}