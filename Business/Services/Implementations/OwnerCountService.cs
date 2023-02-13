using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.OwnerCountDtos;

namespace Business.Services.Implementations
{
    public class OwnerCountService:IOwnerCountService
    {
        private readonly IOwnerCountRepository _repository;
        private readonly IMapper _mapper;

        public OwnerCountService(IOwnerCountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OwnerCountGetDto>> GetAllAsync()
            => _mapper.Map<List<OwnerCountGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));

        public async Task<OwnerCountGetDto> GetByIdAsync(int id)
        {
            OwnerCountGetDto? OwnerCount = _mapper.Map<OwnerCountGetDto>(await _repository.GetByIdAsync(id));
            if (OwnerCount is null)
                throw new NotFoundException("Sahib sayı tapılmadı.");
            return OwnerCount;
        }

        public async Task CreateAsync(OwnerCountPostDto postDto)
        {
            OwnerCount newTrain = _mapper.Map<OwnerCount>(postDto);
            await _repository.CreateAsync(newTrain);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            OwnerCount? OwnerCount = await _repository.GetByIdAsync(id);
            if (OwnerCount is null)
                throw new NotFoundException("Sahib sayı tapılmadı.");
            _repository.DeleteAsync(OwnerCount);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(OwnerCountUpdateDto updateDto)
        {
            OwnerCount? OwnerCount = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (OwnerCount is null)
                throw new NotFoundException("Sahib sayı tapılmadı.");
            OwnerCount.Name = updateDto.postDto.Name;
            await _repository.SaveChangesAsync();
        }
    }
}
