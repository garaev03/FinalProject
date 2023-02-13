using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.VehicleConditionDtos;

namespace Business.Services.Implementations
{
    public class VehicleConditionService:IVehicleConditionService
    {
        private readonly IVehicleConditionRepository _repository;
        private readonly IMapper _mapper;

        public VehicleConditionService(IVehicleConditionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<VehicleConditionGetDto>> GetAllAsync()
            => _mapper.Map<List<VehicleConditionGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));

        public async Task<VehicleConditionGetDto> GetByIdAsync(int id)
        {
            VehicleConditionGetDto? VehicleCondition = _mapper.Map<VehicleConditionGetDto>(await _repository.GetByIdAsync(id));
            if (VehicleCondition is null)
                throw new NotFoundException("Nəqliyyat mövcudluğu tapılmadı.");
            return VehicleCondition;
        }

        public async Task CreateAsync(VehicleConditionPostDto postDto)
        {
            VehicleCondition newVehicleCondition = _mapper.Map<VehicleCondition>(postDto);
            await _repository.CreateAsync(newVehicleCondition);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            VehicleCondition? VehicleCondition = await _repository.GetByIdAsync(id);
            if (VehicleCondition is null)
                throw new NotFoundException("Nəqliyyat mövcudluğu tapılmadı.");
            _repository.DeleteAsync(VehicleCondition);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(VehicleConditionUpdateDto updateDto)
        {
            VehicleCondition? VehicleCondition = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (VehicleCondition is null)
                throw new NotFoundException("Nəqliyyat mövcudluğu tapılmadı.");
            VehicleCondition.Name = updateDto.postDto.Name;
            await _repository.SaveChangesAsync();
        }
    }
}
