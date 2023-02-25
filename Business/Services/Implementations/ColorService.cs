namespace Business.Services.Implementations;
public class ColorService : IColorService
{
    private readonly IColorRepository _repository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;
    public ColorService(IColorRepository repository, IMapper mapper, IImageService imageService)
    {
        _repository = repository;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<List<ColorGetDto>> GetAllAsync()
      => _mapper.Map<List<ColorGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));
    public async Task<ColorGetDto> GetByIdAsync(int id)
    {
        ColorGetDto? color = _mapper.Map<ColorGetDto>(await _repository.GetByIdAsync(id));
        if (color is null)
            throw new NotFoundException(Messages.NotFoundColor);
        return color;
    }
    public async Task CreateAsync(ColorPostDto postDto)
    {
        if (postDto.formFile is null)
            throw new ImageException(Messages.NullImage);
        Color newColor = _mapper.Map<Color>(postDto);
        newColor.Image = await CheckAndCreateImageAsync(postDto.formFile);
        await _repository.CreateAsync(newColor);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        Color? color = await _repository.GetByIdAsync(id);
        if (color is null)
            throw new NotFoundException(Messages.NotFoundColor);
        _repository.DeleteAsync(color);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(ColorUpdateDto updateDto)
    {
        Color? color = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (color is null)
            throw new NotFoundException(Messages.NotFoundColor);
        if (updateDto.postDto.formFile is not null)
            color.Image = await CheckAndCreateImageAsync(updateDto.postDto.formFile);
        color.Name = updateDto.postDto.Name;
        await _repository.SaveChangesAsync();

    }
    private async Task<string> CheckAndCreateImageAsync(IFormFile formFile)
    {
        _imageService.CheckType(formFile);
        _imageService.CheckSize(formFile, 2);
        return await _imageService.CreateFileAsync("color-images", formFile);
    }
}