using Entities.DTOs.SeatDtos;

namespace Business.Services.Interfaces
{
    public interface ISeatService
    {
        Task<List<SeatGetDto>> GetAllAsync();
        Task<SeatGetDto> GetByIdAsync(int id);
        Task CreateAsync(SeatPostDto postDto);
        Task UpdateAsync(SeatUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
