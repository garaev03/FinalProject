namespace DAL.Repositories.Implementations;
public class VehicleReportRepository:TEntityRepository<VehicleReport,AppDbContext>,IVehicleReportRepository
{
    public VehicleReportRepository(AppDbContext db):base(db){}         
}