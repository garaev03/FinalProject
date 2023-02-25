namespace Business.Services.Implementations;
public class EngineCapacityService : IEngineCapacityService
{
    private readonly IEngineCapacityRepository _repository;
    private readonly IMapper _mapper;
    public EngineCapacityService(IEngineCapacityRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<EngineCapacityGetDto>> GetAllAsync()
        => _mapper.Map<List<EngineCapacityGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));
    public async Task<EngineCapacityGetDto> GetByIdAsync(int id)
    {
        EngineCapacityGetDto? capacity = _mapper.Map<EngineCapacityGetDto>(await _repository.GetByIdAsync(id));
        if (capacity is null)
            throw new NotFoundException(Messages.NotFoundEngineCapacity);
        return capacity;
    }
    public async Task CreateAsync(EngineCapacityPostDto postDto)
    {
        EngineCapacity newCapacity = _mapper.Map<EngineCapacity>(postDto);
        newCapacity.ConvertedValue = (newCapacity.Value / 1000).ToString("N1");
        await _repository.CreateAsync(newCapacity);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        EngineCapacity? capacity = await _repository.GetByIdAsync(id);
        if (capacity is null)
            throw new NotFoundException(Messages.NotFoundEngineCapacity);
        _repository.DeleteAsync(capacity);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(EngineCapacityUpdateDto updateDto)
    {
        EngineCapacity? capacity = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (capacity is null)
            throw new NotFoundException(Messages.NotFoundEngineCapacity);
        capacity.Value = updateDto.postDto.Value;
        capacity.ConvertedValue = (capacity.Value / 1000).ToString("N1");
        await _repository.SaveChangesAsync();
    }
}