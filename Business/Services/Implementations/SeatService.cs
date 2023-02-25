namespace Business.Services.Implementations;
public class SeatService:ISeatService
{
    private readonly ISeatRepository _repository;
    private readonly IMapper _mapper;
    public SeatService(ISeatRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<SeatGetDto>> GetAllAsync()
        => _mapper.Map<List<SeatGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));
    public async Task<SeatGetDto> GetByIdAsync(int id)
    {
        SeatGetDto? seat = _mapper.Map<SeatGetDto>(await _repository.GetByIdAsync(id));
        if (seat is null)
            throw new NotFoundException(Messages.NotFoundSeat);
        return seat;
    }
    public async Task CreateAsync(SeatPostDto postDto)
    {
        Seat newSeat = _mapper.Map<Seat>(postDto);
        await _repository.CreateAsync(newSeat);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        Seat? seat = await _repository.GetByIdAsync(id);
        if (seat is null)
            throw new NotFoundException(Messages.NotFoundSeat);
        _repository.DeleteAsync(seat);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(SeatUpdateDto updateDto)
    {
        Seat? seat = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (seat is null)
            throw new NotFoundException(Messages.NotFoundSeat);
        seat.Value = updateDto.postDto.Value;
        await _repository.SaveChangesAsync();
    }
}