namespace DAL.Repositories.Implementations;
public class SettingRepository : TEntityRepository<Setting, AppDbContext>, ISettingRepository
{
    public SettingRepository(AppDbContext db) : base(db) { }
}