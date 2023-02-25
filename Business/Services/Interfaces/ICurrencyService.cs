namespace Business.Services.Interfaces;
public interface ICurrencyService
{
    Task<List<CurrencyGetDto>> GetAllAsync();
    Task<CurrencyGetDto> GetByIdAsync(int id);
    Task CreateAsync(CurrencyPostDto postDto);
    Task UpdateAsync(CurrencyUpdateDto updateDto);
    Task DeleteAsync(int id);
}
