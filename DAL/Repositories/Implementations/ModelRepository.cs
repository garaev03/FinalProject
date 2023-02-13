using Entities.Concrets;
using DAL.Repositories.Interfaces;
using Core.Repositories.Implementations;

namespace DAL.Repositories.Implementations{
    public class ModelRepository:TEntityRepository<Model,AppDbContext>,IModelRepository
    {
        public ModelRepository(AppDbContext db):base(db){}         
    }
}