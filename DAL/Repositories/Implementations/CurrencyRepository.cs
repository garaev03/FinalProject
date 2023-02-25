namespace DAL.Repositories.Implementations;
public class CurrencyRepository : TEntityRepository<Currency, AppDbContext>, ICurrencyRepository
{
    public CurrencyRepository(AppDbContext db) : base(db) { }
}