using Entities.DTOs.MileageTypeDtos;

namespace Business.Services.Interfaces
{
    public interface IMileageTypeService
    {
        Task<List<MileageTypeGetDto>> GetAllAsync();
        Task<MileageTypeGetDto> GetByIdAsync(int id);
        Task CreateAsync(MileageTypePostDto postDto);
        Task UpdateAsync(MileageTypeUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
