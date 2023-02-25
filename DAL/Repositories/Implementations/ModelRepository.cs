namespace DAL.Repositories.Implementations;
public class ModelRepository : TEntityRepository<Model, AppDbContext>, IModelRepository
{
    public ModelRepository(AppDbContext db) : base(db) { }
}