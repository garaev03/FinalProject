using Entities.DTOs.FuelDtos;

namespace Business.Services.Interfaces
{
    public interface IFuelService
    {
        Task<List<FuelGetDto>> GetAllAsync();
        Task<FuelGetDto> GetByIdAsync(int id);
        Task CreateAsync(FuelPostDto postDto);
        Task UpdateAsync(FuelUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}