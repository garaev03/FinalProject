using Entities.DTOs.ModelDtos;
namespace Business.Services.Interfaces{
    public interface IModelService
    {
        Task<List<ModelGetDto>> GetAllAsync(int makeId=0,params string[]? includes);
        Task<ModelGetDto> GetByIdAsync(int id);
        Task CreateAsync(ModelPostDto postDto);
        Task UpdateAsync(ModelUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}