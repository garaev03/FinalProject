using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.BanDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class BanService : IBanService
    {
        private readonly IBanRepository _repository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _env;
        public BanService(IBanRepository repository, IMapper mapper, IImageService imageService, IWebHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
            _env = env;
        }

        public async Task<List<BanGetDto>> GetAllAsync()
            =>_mapper.Map<List<BanGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));

        public async Task<BanGetDto> GetByIdAsync(int id)
        {
            BanGetDto? ban = _mapper.Map<BanGetDto>(await _repository.GetByIdAsync(id));
            if (ban is null)
                throw new NotFoundException("Ban növü tapılmadı.");
            return ban;
        }

        public async Task CreateAsync(BanPostDto postDto)
        {
            if (postDto.formFile is null)
                throw new ImageException("Zəhmət olmasa şəkil daxil edin.");
            Ban newBan = _mapper.Map<Ban>(postDto);
            newBan.Image = await CheckAndCreateImageAsync(postDto.formFile);
            await _repository.CreateAsync(newBan);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Ban? ban = await _repository.GetByIdAsync(id);
            if (ban is null)
                throw new NotFoundException("Ban növü tapılmadı.");
            _repository.DeleteAsync(ban);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(BanUpdateDto updateDto)
        {
            Ban? ban = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (ban is null)
                throw new NotFoundException("Ban növü tapılmadı.");
            if (updateDto.postDto.formFile is not null)
                ban.Image = await CheckAndCreateImageAsync(updateDto.postDto.formFile);
            ban.Name = updateDto.postDto.Name;
            await _repository.SaveChangesAsync();
        }
        private async Task<string> CheckAndCreateImageAsync(IFormFile formFile)
        {
            _imageService.CheckType(formFile);
            _imageService.CheckSize(formFile, 2);
            return await _imageService.CreateFileAsync("ban-images", formFile);
        }
    }
}
