using AutoMapper;
using Business.Services.Interfaces;
using Business.Utilities.Exceptions;
using DAL.Repositories.Interfaces;
using Entities.Concrets;
using Entities.DTOs.ModelDtos;
using System.Linq.Expressions;

namespace Business.Services.Implementations
{
    public class ModelService:IModelService
    {
        private readonly IModelRepository _repository;
        private readonly IMakeService _makeService;
        private readonly IMapper _mapper;

        public ModelService(IModelRepository repository, IMapper mapper, IMakeService makeService)
        {
            _repository = repository;
            _mapper = mapper;
            _makeService = makeService;
        }

        public async Task<List<ModelGetDto>> GetAllAsync(int makeId = 0,params string[]? includes)
        {
            Expression<Func<Model,bool>> exp = x => !x.isDeleted;
            if(makeId is not 0)
                exp= x => !x.isDeleted && x.MakeId == makeId;
            return _mapper.Map<List<ModelGetDto>>(await _repository.GetAllAsync(exp, includes));
        }

        public async Task<ModelGetDto> GetByIdAsync(int id)
        {
            ModelGetDto? Model = _mapper.Map<ModelGetDto>(await _repository.GetByIdAsync(id));
            if (Model is null)
                throw new NotFoundException("Model tapılmadı.");
            return Model;
        }

        public async Task CreateAsync(ModelPostDto postDto)
        {
            await _makeService.GetByIdAsync(postDto.MakeId);
            Model newTrain = _mapper.Map<Model>(postDto);
            await _repository.CreateAsync(newTrain);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Model? Model = await _repository.GetByIdAsync(id);
            if (Model is null)
                throw new NotFoundException("Model tapılmadı.");
            _repository.DeleteAsync(Model);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ModelUpdateDto updateDto)
        {
            Model? Model = await _repository.GetByIdAsync(updateDto.getDto.Id);
            if (Model is null)
                throw new NotFoundException("Model tapılmadı.");
            await _makeService.GetByIdAsync(updateDto.postDto.MakeId);
            Model.Name = updateDto.postDto.Name;
            Model.MakeId=updateDto.postDto.MakeId;
            await _repository.SaveChangesAsync();
        }
    }
}
