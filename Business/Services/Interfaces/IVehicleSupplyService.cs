using Entities.DTOs.VehicleSupplyDtos;
namespace Business.Services.Interfaces{
    public interface IVehicleSupplyService
    {
        Task<List<VehicleSupplyGetDto>> GetAllAsync();
        Task<VehicleSupplyGetDto> GetByIdAsync(int id);
        Task CreateAsync(VehicleSupplyPostDto postDto);
        Task UpdateAsync(VehicleSupplyUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}