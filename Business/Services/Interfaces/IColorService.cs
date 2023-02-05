using Entities.DTOs.ColorDtos;

namespace Business.Services.Interfaces;

public interface IColorService
{
    Task<List<ColorGetDto>> GetAllAsync();
    Task<ColorGetDto> GetByIdAsync(int id);
    Task CreateAsync(ColorPostDto postDto);
    Task UpdateAsync(ColorUpdateDto updateDto);
    Task DeleteAsync(int id);
}
