namespace Business.Services.Implementations;
public class SettingService : ISettingService
{
    private readonly ISettingRepository _repository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;
    public SettingService(ISettingRepository repository, IMapper mapper, IImageService imageService)
    {
        _repository = repository;
        _mapper = mapper;
        _imageService = imageService;
    }

    public SettingGetDto Get()
        => _mapper.Map<SettingGetDto>(_repository.GetAllAsync(x => !x.isDeleted).Result.FirstOrDefault());
    public SettingUpdateDto GetUpdate()
       => _mapper.Map<SettingUpdateDto>(_repository.GetAllAsync(x => !x.isDeleted).Result.FirstOrDefault());
    public async Task UpdateAsync(SettingUpdateDto updateDto)
    {
        Setting setting = _repository.GetAllAsync(x => !x.isDeleted).Result.FirstOrDefault();
        if (updateDto.formFile is not null)
            setting.Logo = await CreateImage(updateDto.formFile);
        setting.TelephoneNumber = updateDto.TelephoneNumber;
        setting.Email = updateDto.Email;
        setting.FacebookLink = updateDto.FacebookLink;
        setting.InstagramLink = updateDto.InstagramLink;
        setting.FooterLeft = updateDto.FooterLeft;
        setting.FooterRight = updateDto.FooterRight;
        await _repository.SaveChangesAsync();
    }

    private async Task<string> CreateImage(IFormFile formFile)
    {
        _imageService.CheckType(formFile);
        _imageService.CheckSize(formFile, 2);
        return await _imageService.CreateFileAsync("logos", formFile);
    }
}