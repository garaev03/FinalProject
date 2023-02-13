using Entities.DTOs.MakeDtos;
namespace Business.Services.Interfaces{
    public interface IMakeService
    {
        Task<List<MakeGetDto>> GetAllAsync();
        Task<MakeGetDto> GetByIdAsync(int id);
        Task CreateAsync(MakePostDto postDto);
        Task UpdateAsync(MakeUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}