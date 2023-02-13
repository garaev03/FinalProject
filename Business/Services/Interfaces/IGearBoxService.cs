using Entities.DTOs.GearBoxDtos;
namespace Business.Services.Interfaces{
    public interface IGearBoxService
    {
        Task<List<GearBoxGetDto>> GetAllAsync();
        Task<GearBoxGetDto> GetByIdAsync(int id);
        Task CreateAsync(GearBoxPostDto postDto);
        Task UpdateAsync(GearBoxUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}