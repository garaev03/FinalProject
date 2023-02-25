namespace Business.Services.Implementations;
public class ModelService : IModelService
{
    private readonly IModelRepository _repository;
    private readonly IMakeService _makeService;
    private readonly IMapper _mapper;
    public ModelService(IModelRepository repository, IMapper mapper, IMakeService makeService)
    {
        _repository = repository;
        _mapper = mapper;
        _makeService = makeService;
    }

    public async Task<List<ModelGetDto>> GetAllAsync(Expression<Func<Model, bool>>? exp = null, params string[]? includes)
    {
        if(exp is null) exp = x => !x.isDeleted;
        return _mapper.Map<List<ModelGetDto>>(await _repository.GetAllAsync(exp, includes));
    }
    public async Task<ModelGetDto> GetByIdAsync(int id)
    {
        ModelGetDto? Model = _mapper.Map<ModelGetDto>(await _repository.GetByIdAsync(id));
        if (Model is null)
            throw new NotFoundException(Messages.NotFoundModel);
        return Model;
    }
    public async Task CreateAsync(ModelPostDto postDto)
    {
        await _makeService.GetByIdAsync(postDto.MakeId);
        Model newTrain = _mapper.Map<Model>(postDto);
        await _repository.CreateAsync(newTrain);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        Model? Model = await _repository.GetByIdAsync(id);
        if (Model is null)
            throw new NotFoundException(Messages.NotFoundModel);
        _repository.DeleteAsync(Model);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(ModelUpdateDto updateDto)
    {
        Model? Model = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (Model is null)
            throw new NotFoundException(Messages.NotFoundModel);
        await _makeService.GetByIdAsync(updateDto.postDto.MakeId);
        Model.Name = updateDto.postDto.Name;
        Model.MakeId = updateDto.postDto.MakeId;
        await _repository.SaveChangesAsync();
    }
}