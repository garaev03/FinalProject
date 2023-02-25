namespace Business.Services.Interfaces;
public interface IBanService
{
    Task<List<BanGetDto>> GetAllAsync();
    Task<BanGetDto> GetByIdAsync(int id);
    Task CreateAsync(BanPostDto postDto);
    Task UpdateAsync(BanUpdateDto updateDto);
    Task DeleteAsync(int id);
}
