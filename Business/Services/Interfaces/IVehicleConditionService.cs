using Entities.DTOs.VehicleConditionDtos;
namespace Business.Services.Interfaces{
    public interface IVehicleConditionService
    {
        Task<List<VehicleConditionGetDto>> GetAllAsync();
        Task<VehicleConditionGetDto> GetByIdAsync(int id);
        Task CreateAsync(VehicleConditionPostDto postDto);
        Task UpdateAsync(VehicleConditionUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}