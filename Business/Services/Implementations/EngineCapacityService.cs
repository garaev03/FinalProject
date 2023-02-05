using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.EngineCapacityDtos;

namespace Business.Services.Implementations
{
    public class EngineCapacityService:IEngineCapacityService
    {
        private readonly IEngineCapacityRepository _repository;
        private readonly IMapper _mapper;

        public EngineCapacityService(IEngineCapacityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EngineCapacityGetDto>> GetAllAsync()
            => _mapper.Map<List<EngineCapacityGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));

        public async Task<EngineCapacityGetDto> GetByIdAsync(int id)
        {
            EngineCapacityGetDto? capacity = _mapper.Map<EngineCapacityGetDto>(await _repository.GetByIdAsync(id));
            if (capacity is null)
                throw new NotFoundException("Həcm tapılmadı.");
            return capacity;
        }

        public async Task CreateAsync(EngineCapacityPostDto postDto)
        {
            EngineCapacity newCapacity = _mapper.Map<EngineCapacity>(postDto);
            await _repository.CreateAsync(newCapacity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            EngineCapacity? capacity = await _repository.GetByIdAsync(id);
            if (capacity is null)
                throw new NotFoundException("Həcm tapılmadı.");
            _repository.DeleteAsync(capacity);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(EngineCapacityUpdateDto updateDto)
        {
            EngineCapacity? capacity = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (capacity is null)
                throw new NotFoundException("Həcm tapılmadı.");
            capacity.Value = updateDto.postDto.Value;
            await _repository.SaveChangesAsync();
        }
    }
}
