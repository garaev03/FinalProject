using Entities.DTOs.CityDtos;

namespace Business.Services.Interfaces
{
    public interface ICityService
    {
        Task<List<CityGetDto>> GetAllAsync();
        Task<CityGetDto> GetByIdAsync(int id);
        Task CreateAsync(CityPostDto postDto);
        Task UpdateAsync(CityUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
