namespace Business.Services.Implementations;
public class CityService : ICityService
{
    private readonly ICityRepository _repository;
    private readonly IMapper _mapper;

    public CityService(ICityRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<CityGetDto>> GetAllAsync()
        => _mapper.Map<List<CityGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));
    public async Task<CityGetDto> GetByIdAsync(int id)
    {
        CityGetDto? City = _mapper.Map<CityGetDto>(await _repository.GetByIdAsync(id));
        if (City is null)
            throw new NotFoundException(Messages.NotFoundCity);
        return City;
    }
    public async Task CreateAsync(CityPostDto postDto)
    {
        City newCity = _mapper.Map<City>(postDto);
        await _repository.CreateAsync(newCity);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        City? City = await _repository.GetByIdAsync(id);
        if (City is null)
            throw new NotFoundException(Messages.NotFoundCity);
        _repository.DeleteAsync(City);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(CityUpdateDto updateDto)
    {
        City? City = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (City is null)
            throw new NotFoundException(Messages.NotFoundCity);
        City.Name = updateDto.postDto.Name;
        City.Code = updateDto.postDto.Code;
        await _repository.SaveChangesAsync();
    }
}