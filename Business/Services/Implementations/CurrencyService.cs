namespace Business.Services.Implementations;
public class CurrencyService : ICurrencyService
{
    private readonly ICurrencyRepository _repository;
    private readonly IMapper _mapper;
    public CurrencyService(ICurrencyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CurrencyGetDto>> GetAllAsync()
        => _mapper.Map<List<CurrencyGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));
    public async Task<CurrencyGetDto> GetByIdAsync(int id)
    {
        CurrencyGetDto? currency = _mapper.Map<CurrencyGetDto>(await _repository.GetByIdAsync(id));
        if (currency is null)
            throw new NotFoundException(Messages.NotFoundCurrency);
        return currency;
    }
    public async Task CreateAsync(CurrencyPostDto postDto)
    {
        Currency newCurrency = _mapper.Map<Currency>(postDto);
        await _repository.CreateAsync(newCurrency);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        Currency? currency = await _repository.GetByIdAsync(id);
        if (currency is null)
            throw new NotFoundException(Messages.NotFoundCurrency);
        _repository.DeleteAsync(currency);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(CurrencyUpdateDto updateDto)
    {
        Currency? currency = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (currency is null)
            throw new NotFoundException(Messages.NotFoundCurrency);
        currency.Name = updateDto.postDto.Name;
        await _repository.SaveChangesAsync();
    }
}