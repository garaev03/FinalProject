using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.DriveTrainDtos;

namespace Business.Services.Implementations
{
    public class DriveTrainService:IDriveTrainService
    {
        private readonly IDriveTrainRepository _repository;
        private readonly IMapper _mapper;

        public DriveTrainService(IDriveTrainRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DriveTrainGetDto>> GetAllAsync()
            => _mapper.Map<List<DriveTrainGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));

        public async Task<DriveTrainGetDto> GetByIdAsync(int id)
        {
            DriveTrainGetDto? train = _mapper.Map<DriveTrainGetDto>(await _repository.GetByIdAsync(id));
            if (train is null)
                throw new NotFoundException("Ötürücü tapılmadı.");
            return train;
        }

        public async Task CreateAsync(DriveTrainPostDto postDto)
        {
            DriveTrain newTrain = _mapper.Map<DriveTrain>(postDto);
            await _repository.CreateAsync(newTrain);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            DriveTrain? train = await _repository.GetByIdAsync(id);
            if (train is null)
                throw new NotFoundException("Ötürücü tapılmadı.");
            _repository.DeleteAsync(train);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(DriveTrainUpdateDto updateDto)
        {
            DriveTrain? train = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (train is null)
                throw new NotFoundException("Ötürücü tapılmadı.");
            train.Name = updateDto.postDto.Name;
            await _repository.SaveChangesAsync();
        }
    }
}
