using Entities.DTOs.StatusDtos;

namespace Business.Services.Interfaces
{
    public interface IStatusService
    {
        Task<List<StatusGetDto>> GetAllAsync();
        Task<StatusGetDto> GetByIdAsync(int id);
        Task CreateAsync(StatusPostDto postDto);
        Task UpdateAsync(StatusUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}