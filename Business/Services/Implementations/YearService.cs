namespace Business.Services.Implementations;
public class YearService:IYearService
{
    private readonly IYearRepository _repository;
    private readonly IMapper _mapper;
    public YearService(IYearRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<YearGetDto>> GetAllAsync()
        => _mapper.Map<List<YearGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));
    public async Task<YearGetDto> GetByIdAsync(int id)
    {
        YearGetDto? Year = _mapper.Map<YearGetDto>(await _repository.GetByIdAsync(id));
        if (Year is null)
            throw new NotFoundException(Messages.NotFoundYear);
        return Year;
    }
    public async Task CreateAsync(YearPostDto postDto)
    {
        Year newYear = _mapper.Map<Year>(postDto);
        await _repository.CreateAsync(newYear);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        Year? Year = await _repository.GetByIdAsync(id);
        if (Year is null)
            throw new NotFoundException(Messages.NotFoundYear);
        _repository.DeleteAsync(Year);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(YearUpdateDto updateDto)
    {
        Year? Year = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (Year is null)
            throw new NotFoundException(Messages.NotFoundYear);
        Year.Value = updateDto.postDto.Value;
        await _repository.SaveChangesAsync();
    }
}