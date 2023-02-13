using Entities.DTOs.VehicleReportDtos;
namespace Business.Services.Interfaces{
    public interface IVehicleReportService
    {
        Task<List<VehicleReportGetDto>> GetAllAsync();
        Task<VehicleReportGetDto> GetByIdAsync(int id);
        Task CreateAsync(VehicleReportPostDto postDto);
        Task UpdateAsync(VehicleReportUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}