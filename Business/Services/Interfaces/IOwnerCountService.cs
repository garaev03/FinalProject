namespace Business.Services.Interfaces;
public interface IOwnerCountService
{
    Task<List<OwnerCountGetDto>> GetAllAsync();
    Task<OwnerCountGetDto> GetByIdAsync(int id);
    Task CreateAsync(OwnerCountPostDto postDto);
    Task UpdateAsync(OwnerCountUpdateDto updateDto);
    Task DeleteAsync(int id);
}