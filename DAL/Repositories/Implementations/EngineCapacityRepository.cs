namespace DAL.Repositories.Implementations;
public class EngineCapacityRepository : TEntityRepository<EngineCapacity, AppDbContext>, IEngineCapacityRepository
{
    public EngineCapacityRepository(AppDbContext db) : base(db) { }
}