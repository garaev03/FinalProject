namespace DAL.Repositories.Implementations;
public class BanRepository : TEntityRepository<Ban, AppDbContext>, IBanRepository
{
    public BanRepository(AppDbContext db) : base(db) { }
}