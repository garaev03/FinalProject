namespace Core.Repositories.Implementations;
public class TEntityRepository<T, Context> : ITEntityRepository<T>
    where T : Entity
    where Context : IdentityDbContext<AppUser>
{
    private readonly Context _db;

    public TEntityRepository(Context db)
    {
        _db = db;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp, params string[]? includes)
    {
        IQueryable<T> query = _db.Set<T>().Where(exp);
        if (includes is not null)
            foreach (var item in includes) { query = query.Include(item); }
        return await query.ToListAsync();
    }
    public async Task<T?> GetByIdAsync(int id, params string[]? includes)
    {
        IQueryable<T> db = _db.Set<T>().Where(x => !x.isDeleted);
        if (includes is not null)
            foreach (var item in includes) { db = db.Include(item); }
        T? model = await db.FirstOrDefaultAsync(x => x.Id == id);
        return model;
    }
    public async Task CreateAsync(T model)
    {
        await _db.Set<T>().AddAsync(model);
    }
    public void DeleteAsync(T model)
    {
        model.isDeleted = true;
    }
    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}