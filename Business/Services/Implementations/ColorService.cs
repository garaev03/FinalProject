using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.ColorDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.Services.Implementations;

public class ColorService : IColorService
{
    private readonly IColorRepository _repository;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;
    private readonly IWebHostEnvironment _env;

    public ColorService(IColorRepository repository, IMapper mapper, IImageService imageService, IWebHostEnvironment env)
    {
        _repository = repository;
        _mapper = mapper;
        _imageService = imageService;
        _env = env;
    }

    public async Task<List<ColorGetDto>> GetAllAsync()
      =>_mapper.Map<List<ColorGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));

    public async Task<ColorGetDto> GetByIdAsync(int id)
    {
        ColorGetDto? color = _mapper.Map<ColorGetDto>(await _repository.GetByIdAsync(id));
        if (color is null)
            throw new NotFoundException("Rəng tapılmadı.");
        return color;
    }

    public async Task CreateAsync(ColorPostDto postDto)
    {
        if (postDto.formFile is null)
            throw new ImageException("Zəhmət olmasa şəkil daxil edin.");
        Color newColor = _mapper.Map<Color>(postDto);
        newColor.Image = await CheckAndCreateImageAsync(postDto.formFile);
        await _repository.CreateAsync(newColor);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Color? color = await _repository.GetByIdAsync(id);
        if (color is null)
            throw new NotFoundException("Rəng tapılmadı.");
        _repository.DeleteAsync(color);
        await _repository.SaveChangesAsync();
    }

    public async Task UpdateAsync(ColorUpdateDto updateDto)
    {
        Color? color = await _repository.GetByIdAsync(updateDto.getDto.Id);
        if (color is null)
            throw new NotFoundException("Rəng tapılmadı.");
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
