using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.CountryDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Business.Services.Implementations
{
    public class CountryService:ICountryService
    {
        private readonly ICountryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;

        public CountryService(ICountryRepository repository, IMapper mapper, IImageService imageService, IWebHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
            _env = env;
        }

        public async Task<List<CountryGetDto>> GetAllAsync()
            =>_mapper.Map<List<CountryGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));

        public async Task<CountryGetDto> GetByIdAsync(int id)
        {
            CountryGetDto? country = _mapper.Map<CountryGetDto>(await _repository.GetByIdAsync(id));
            if (country is null)
                throw new NotFoundException("Ölkə tapılmadı.");
            return country;
        }

        public async Task CreateAsync(CountryPostDto postDto)
        {
            if (postDto.formFile is null)
                throw new ImageException("Zəhmət olmasa şəkil daxil edin.");
            Country newCountry = _mapper.Map<Country>(postDto);
            newCountry.Image = await CheckAndCreateImageAsync(postDto.formFile);
            await _repository.CreateAsync(newCountry);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Country? country = await _repository.GetByIdAsync(id);
            if (country is null)
                throw new NotFoundException("Ölkə tapılmadı.");
            _repository.DeleteAsync(country);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(CountryUpdateDto updateDto)
        {
            Country? country = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (country is null)
                throw new NotFoundException("Ölkə tapılmadı.");
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
}
