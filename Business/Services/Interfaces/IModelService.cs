namespace Business.Services.Interfaces;
public interface IModelService
{
    Task<List<ModelGetDto>> GetAllAsync(Expression<Func<Model, bool>>? exp = null, params string[]? includes);
    Task<ModelGetDto> GetByIdAsync(int id);
    Task CreateAsync(ModelPostDto postDto);
    Task UpdateAsync(ModelUpdateDto updateDto);
    Task DeleteAsync(int id);
}