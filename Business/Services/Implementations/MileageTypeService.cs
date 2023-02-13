using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.MileageTypeDtos;

namespace Business.Services.Implementations
{
    public class MileageTypeService:IMileageTypeService
    {
        private readonly IMileageTypeRepository _repository;
        private readonly IMapper _mapper;

        public MileageTypeService(IMileageTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MileageTypeGetDto>> GetAllAsync()
            => _mapper.Map<List<MileageTypeGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));

        public async Task<MileageTypeGetDto> GetByIdAsync(int id)
        {
            MileageTypeGetDto? mileageType = _mapper.Map<MileageTypeGetDto>(await _repository.GetByIdAsync(id));
            if (mileageType is null)
                throw new NotFoundException("Kilometraj tapılmadı.");
            return mileageType;
        }

        public async Task CreateAsync(MileageTypePostDto postDto)
        {
            MileageType newMileageType = _mapper.Map<MileageType>(postDto);
            await _repository.CreateAsync(newMileageType);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            MileageType? mileageType = await _repository.GetByIdAsync(id);
            if (mileageType is null)
                throw new NotFoundException("Kilometraj tapılmadı.");
            _repository.DeleteAsync(mileageType);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(MileageTypeUpdateDto updateDto)
        {
            MileageType? mileageType = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (mileageType is null)
                throw new NotFoundException("Kilometraj tapılmadı.");
            mileageType.Name = updateDto.postDto.Name;
            await _repository.SaveChangesAsync();
        }
    }
}
