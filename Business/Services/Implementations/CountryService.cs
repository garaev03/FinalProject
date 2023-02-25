namespace Business.Services.Implementations;
public class CountryService : ICountryService
{
    private readonly ICountryRepository _repository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;
    public CountryService(ICountryRepository repository, IMapper mapper, IImageService imageService)
    {
        _repository = repository;
        _mapper = mapper;
        _imageService = imageService;
    }

    public async Task<List<CountryGetDto>> GetAllAsync()
        => _mapper.Map<List<CountryGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));
    public async Task<CountryGetDto> GetByIdAsync(int id)
    {
        CountryGetDto? country = _mapper.Map<CountryGetDto>(await _repository.GetByIdAsync(id));
        if (country is null)
            throw new NotFoundException(Messages.NotFoundCountry);
        return country;
    }
    public async Task CreateAsync(CountryPostDto postDto)
    {
        if (postDto.formFile is null)
            throw new ImageException(Messages.NullImage);
        Country newCountry = _mapper.Map<Country>(postDto);
        newCountry.Image = await CheckAndCreateImageAsync(postDto.formFile);
        await _repository.CreateAsync(newCountry);
        await _repository.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        Country? country = await _repository.GetByIdAsync(id);
        if (country is null)
            throw new NotFoundException(Messages.NotFoundCountry);
        _repository.DeleteAsync(country);
        await _repository.SaveChangesAsync();
    }
    public async Task UpdateAsync(CountryUpdateDto updateDto)
    {
        Country? country = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (country is null)
            throw new NotFoundException(Messages.NotFoundCountry);
        if (updateDto.postDto.formFile is not null)
            country.Image = await CheckAndCreateImageAsync(updateDto.postDto.formFile);
        country.Name = updateDto.postDto.Name;
        await _repository.SaveChangesAsync();

    }
    private async Task<string> CheckAndCreateImageAsync(IFormFile formFile)
    {
        _imageService.CheckType(formFile);
        _imageService.CheckSize(formFile, 2);
        return await _imageService.CreateFileAsync("country-images", formFile);
    }
}