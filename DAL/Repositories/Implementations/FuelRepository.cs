namespace DAL.Repositories.Implementations;
public class FuelRepository:TEntityRepository<Fuel,AppDbContext>,IFuelRepository
{
    public FuelRepository(AppDbContext db):base(db){}         
}