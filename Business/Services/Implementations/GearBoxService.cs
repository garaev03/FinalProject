namespace Business.Services.Implementations;
public class GearBoxService:IGearBoxService
{
    private readonly IGearBoxRepository _repository;
    private readonly IMapper _mapper;
    public GearBoxService(IGearBoxRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GearBoxGetDto>> GetAllAsync()
        => _mapper.Map<List<GearBoxGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));
    public async Task<GearBoxGetDto> GetByIdAsync(int id)
    {
        GearBoxGetDto? GearBox = _mapper.Map<GearBoxGetDto>(await _repository.GetByIdAsync(id));
        if (GearBox is null)
            throw new NotFoundException(Messages.NotFoundGearBox);
        return GearBox;
    }
    public async Task CreateAsync(GearBoxPostDto postDto)
    {
        GearBox newTrain = _mapper.Map<GearBox>(postDto);
        await _repository.CreateAsync(newTrain);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        GearBox? GearBox = await _repository.GetByIdAsync(id);
        if (GearBox is null)
            throw new NotFoundException(Messages.NotFoundGearBox);
        _repository.DeleteAsync(GearBox);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(GearBoxUpdateDto updateDto)
    {
        GearBox? GearBox = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (GearBox is null)
            throw new NotFoundException(Messages.NotFoundGearBox);
        GearBox.Name = updateDto.postDto.Name;
        await _repository.SaveChangesAsync();
    }
}