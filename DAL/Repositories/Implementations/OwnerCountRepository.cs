namespace DAL.Repositories.Implementations;
public class OwnerCountRepository:TEntityRepository<OwnerCount,AppDbContext>,IOwnerCountRepository
{
    public OwnerCountRepository(AppDbContext db):base(db){}         
}