using Entities.DTOs.DriveTrainDtos;

namespace Business.Services.Interfaces
{
    public interface IDriveTrainService
    {
        Task<List<DriveTrainGetDto>> GetAllAsync();
        Task<DriveTrainGetDto> GetByIdAsync(int id);
        Task CreateAsync(DriveTrainPostDto postDto);
        Task UpdateAsync(DriveTrainUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
