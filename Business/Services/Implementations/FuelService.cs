namespace Business.Services.Implementations;
public class FuelService:IFuelService
{
    private readonly IFuelRepository _repository;
    private readonly IMapper _mapper;
    public FuelService(IFuelRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<FuelGetDto>> GetAllAsync()
        => _mapper.Map<List<FuelGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));
    public async Task<FuelGetDto> GetByIdAsync(int id)
    {
        FuelGetDto? fuel = _mapper.Map<FuelGetDto>(await _repository.GetByIdAsync(id));
        if (fuel is null)
            throw new NotFoundException(Messages.NotFoundFuel);
        return fuel;
    }
    public async Task CreateAsync(FuelPostDto postDto)
    {
        Fuel newTrain = _mapper.Map<Fuel>(postDto);
        await _repository.CreateAsync(newTrain);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        Fuel? fuel = await _repository.GetByIdAsync(id);
        if (fuel is null)
            throw new NotFoundException(Messages.NotFoundFuel);
        _repository.DeleteAsync(fuel);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(FuelUpdateDto updateDto)
    {
        Fuel? fuel = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (fuel is null)
            throw new NotFoundException(Messages.NotFoundFuel);
        fuel.Name = updateDto.postDto.Name;
        await _repository.SaveChangesAsync();
    }
}