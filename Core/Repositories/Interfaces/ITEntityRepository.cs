namespace Core.Repositories.Interfaces;
public interface ITEntityRepository<T>
    where T: Entity
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp, params string[]? includes);
    Task<T?> GetByIdAsync(int id,params string[]? includes);
    Task CreateAsync(T model);
    void DeleteAsync(T model);
    Task SaveChangesAsync();
}