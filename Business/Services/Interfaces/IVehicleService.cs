namespace Business.Services.Interfaces;
public interface IVehicleService
{
    Task<List<VehicleGetDto>> GetAllAsync(Expression<Func<Vehicle, bool>>? exp, bool include);
    Task<VehicleGetDto> GetByIdAsync(int id, bool include);
    Task ValidatePIN(int id, string PINCode);
    Task ConfirmAsync(int id);
    Task CancelAsync(int id);
    Task AwaitAsync(int id);
    Task RenewExpireDateAsync(int id);
    Task<string> CreateAsync(VehiclePostDto postDto);
    Task UpdateAsync(VehicleUpdateDto updateDto);
    Task DeleteAsync(int id);
}