using Entities.Concrets;
using Entities.DTOs.VehicleDtos;
using System.Linq.Expressions;

namespace Business.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<List<VehicleGetDto>> GetAllAsync(Expression<Func<Vehicle, bool>>? exp, params string[]? includes);
        Task<VehicleGetDto> GetByIdAsync(int id);
        Task CreateAsync(VehiclePostDto postDto);
        Task UpdateAsync(VehicleUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
