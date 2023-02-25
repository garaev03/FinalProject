namespace DAL.Repositories.Implementations;
public class CountryRepository : TEntityRepository<Country, AppDbContext>, ICountryRepository
{
    public CountryRepository(AppDbContext db) : base(db) { }
}