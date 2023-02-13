using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.MakeDtos;
using Microsoft.AspNetCore.Http;

namespace Business.Services.Implementations
{
    public class MakeService:IMakeService
    {
        private readonly IMakeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public MakeService(IMakeRepository repository, IMapper mapper, IImageService imageService)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<List<MakeGetDto>> GetAllAsync()
            => _mapper.Map<List<MakeGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));

        public async Task<MakeGetDto> GetByIdAsync(int id)
        {
            MakeGetDto? Make = _mapper.Map<MakeGetDto>(await _repository.GetByIdAsync(id));
            if (Make is null)
                throw new NotFoundException("Marka tapılmadı.");
            return Make;
        }

        public async Task CreateAsync(MakePostDto postDto)
        {
            if (postDto.formFile is null)
                throw new ImageException("Zəhmət olmasa şəkil daxil edin.");
            Make newMake = _mapper.Map<Make>(postDto);
            newMake.Image = await CheckAndCreateImageAsync(postDto.formFile);
            await _repository.CreateAsync(newMake);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Make? Make = await _repository.GetByIdAsync(id);
            if (Make is null)
                throw new NotFoundException("Marka tapılmadı.");
            _repository.DeleteAsync(Make);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(MakeUpdateDto updateDto)
        {
            Make? Make = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (Make is null)
                throw new NotFoundException("Marka tapılmadı.");
            if (updateDto.postDto.formFile is not null)
                Make.Image = await CheckAndCreateImageAsync(updateDto.postDto.formFile);
            Make.Name = updateDto.postDto.Name;
            await _repository.SaveChangesAsync();

        }
        private async Task<string> CheckAndCreateImageAsync(IFormFile formFile)
        {
            _imageService.CheckType(formFile);
            _imageService.CheckSize(formFile, 2);
            return await _imageService.CreateFileAsync("make-images", formFile);
        }
    }
}
