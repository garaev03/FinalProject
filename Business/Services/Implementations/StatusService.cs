using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.StatusDtos;

namespace Business.Services.Implementations
{
    public class StatusService:IStatusService
    {
        private readonly IStatusRepository _repository;
        private readonly IMapper _mapper;

        public StatusService(IStatusRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<StatusGetDto>> GetAllAsync()
            => _mapper.Map<List<StatusGetDto>>(await _repository.GetAllAsync(x => !x.isDeleted));

        public async Task<StatusGetDto> GetByIdAsync(int id)
        {
            StatusGetDto? Status = _mapper.Map<StatusGetDto>(await _repository.GetByIdAsync(id));
            if (Status is null)
                throw new NotFoundException("Oturacaq sayı tapılmadı.");
            return Status;
        }

        public async Task CreateAsync(StatusPostDto postDto)
        {
            Status newStatus = _mapper.Map<Status>(postDto);
            await _repository.CreateAsync(newStatus);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Status? Status = await _repository.GetByIdAsync(id);
            if (Status is null)
                throw new NotFoundException("Oturacaq sayı tapılmadı.");
            _repository.DeleteAsync(Status);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(StatusUpdateDto updateDto)
        {
            Status? Status = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (Status is null)
                throw new NotFoundException("Oturacaq sayı tapılmadı.");
            Status.Name = updateDto.postDto.Name;
            await _repository.SaveChangesAsync();
        }
    }
}
