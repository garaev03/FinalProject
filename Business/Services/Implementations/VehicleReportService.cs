namespace Business.Services.Implementations;
public class VehicleReportService:IVehicleReportService
{
    private readonly IVehicleReportRepository _repository;
    private readonly IMapper _mapper;
    public VehicleReportService(IVehicleReportRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<VehicleReportGetDto>> GetAllAsync()
        => _mapper.Map<List<VehicleReportGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));
    public async Task<VehicleReportGetDto> GetByIdAsync(int id)
    {
        VehicleReportGetDto? VehicleReport = _mapper.Map<VehicleReportGetDto>(await _repository.GetByIdAsync(id));
        if (VehicleReport is null)
            throw new NotFoundException(Messages.NotFoundVehicleReport);
        return VehicleReport;
    }
    public async Task CreateAsync(VehicleReportPostDto postDto)
    {
        VehicleReport newVehicleReport = _mapper.Map<VehicleReport>(postDto);
        await _repository.CreateAsync(newVehicleReport);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        VehicleReport? VehicleReport = await _repository.GetByIdAsync(id);
        if (VehicleReport is null)
            throw new NotFoundException(Messages.NotFoundVehicleReport);
        _repository.DeleteAsync(VehicleReport);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(VehicleReportUpdateDto updateDto)
    {
        VehicleReport? VehicleReport = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (VehicleReport is null)
            throw new NotFoundException(Messages.NotFoundVehicleReport);
        VehicleReport.Name = updateDto.postDto.Name;
        VehicleReport.Description = updateDto.postDto.Description;
        await _repository.SaveChangesAsync();
    }
}