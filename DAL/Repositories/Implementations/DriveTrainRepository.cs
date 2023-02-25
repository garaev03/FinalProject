namespace DAL.Repositories.Implementations;
public class DriveTrainRepository : TEntityRepository<DriveTrain, AppDbContext>, IDriveTrainRepository
{
    public DriveTrainRepository(AppDbContext db) : base(db) { }
}