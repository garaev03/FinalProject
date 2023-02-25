namespace DAL.Repositories.Implementations;
public class VehicleRepository : TEntityRepository<Vehicle, AppDbContext>, IVehicleRepository
{
    public VehicleRepository(AppDbContext db) : base(db) { }
}