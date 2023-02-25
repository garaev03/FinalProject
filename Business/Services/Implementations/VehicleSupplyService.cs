namespace Business.Services.Implementations;
public class VehicleSupplyService:IVehicleSupplyService
{
    private readonly IVehicleSupplyRepository _repository;
    private readonly IMapper _mapper;
    public VehicleSupplyService(IVehicleSupplyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<VehicleSupplyGetDto>> GetAllAsync()
        => _mapper.Map<List<VehicleSupplyGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));
    public async Task<VehicleSupplyGetDto> GetByIdAsync(int id)
    {
        VehicleSupplyGetDto? VehicleSupply = _mapper.Map<VehicleSupplyGetDto>(await _repository.GetByIdAsync(id));
        if (VehicleSupply is null)
            throw new NotFoundException(Messages.NotFoundVehicleSupply);
        return VehicleSupply;
    }
    public async Task CreateAsync(VehicleSupplyPostDto postDto)
    {
        VehicleSupply newVehicleSupply = _mapper.Map<VehicleSupply>(postDto);
        await _repository.CreateAsync(newVehicleSupply);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        VehicleSupply? VehicleSupply = await _repository.GetByIdAsync(id);
        if (VehicleSupply is null)
            throw new NotFoundException(Messages.NotFoundVehicleSupply);
        _repository.DeleteAsync(VehicleSupply);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(VehicleSupplyUpdateDto updateDto)
    {
        VehicleSupply? VehicleSupply = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (VehicleSupply is null)
            throw new NotFoundException(Messages.NotFoundVehicleSupply);
        VehicleSupply.Name = updateDto.postDto.Name;
        await _repository.SaveChangesAsync();
    }
}