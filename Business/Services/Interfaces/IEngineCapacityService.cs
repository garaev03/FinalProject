using Entities.DTOs.EngineCapacityDtos;

namespace Business.Services.Interfaces
{
    public interface IEngineCapacityService
    {
        Task<List<EngineCapacityGetDto>> GetAllAsync();
        Task<EngineCapacityGetDto> GetByIdAsync(int id);
        Task CreateAsync(EngineCapacityPostDto postDto);
        Task UpdateAsync(EngineCapacityUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
