namespace DAL.Repositories.Implementations;
public class MakeRepository:TEntityRepository<Make,AppDbContext>,IMakeRepository
{
    public MakeRepository(AppDbContext db):base(db){}         
}