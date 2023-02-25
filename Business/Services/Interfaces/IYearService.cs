namespace Business.Services.Interfaces;
public interface IYearService
{
    Task<List<YearGetDto>> GetAllAsync();
    Task<YearGetDto> GetByIdAsync(int id);
    Task CreateAsync(YearPostDto postDto);
    Task UpdateAsync(YearUpdateDto updateDto);
    Task DeleteAsync(int id);
}