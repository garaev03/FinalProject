namespace Business.Services.Interfaces;
public interface ICountryService
{
    Task<List<CountryGetDto>> GetAllAsync();
    Task<CountryGetDto> GetByIdAsync(int id);
    Task CreateAsync(CountryPostDto postDto);
    Task UpdateAsync(CountryUpdateDto updateDto);
    Task DeleteAsync(int id);
}
