namespace DAL.Repositories.Implementations;
public class YearRepository : TEntityRepository<Year, AppDbContext>, IYearRepository
{
    public YearRepository(AppDbContext db) : base(db) { }
}